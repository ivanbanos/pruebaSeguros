using InsurranceApi.Authentication;
using InsurranceLogic.DataAccess;
using InsurranceLogic.DataAccess.Repository;
using InsurranceLogic.Model;
using InsurranceLogic.ModelAdapter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InsurranceLogic
{
    public class LogicFacade
    {
        private static LogicFacade instance;

        public static LogicFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogicFacade();
                }
                return instance;
            }
        }

        private LogicFacade() { }

        public List<Insurrance> GetInsurrances() {
            List<InsurranceLogic.EFDataBaseConecction.Insurrance> insurrancesDBO = DataAccessFacade.Instance.GetInsurrances();
            IAdapter adapter = AdapterCreatorImpl.getInstance().getAdapter("Insurrance");
            List<Insurrance> insurrancesDTO = new List<Insurrance>();
            foreach(InsurranceLogic.EFDataBaseConecction.Insurrance dbo in insurrancesDBO)
            {
                insurrancesDTO.Add((Insurrance)adapter.adapt(dbo));
            }
            return insurrancesDTO;
        }

        public List<TiposCubrimiento> GetTiposCubrimientos() {
            List<InsurranceLogic.EFDataBaseConecction.TiposCubrimiento> TiposCubrimientosDBO = DataAccessFacade.Instance.GetTiposCubrimientos();
            IAdapter adapter = AdapterCreatorImpl.getInstance().getAdapter("TiposCubrimiento");
            List<TiposCubrimiento> TiposCubrimientosDTO = new List<TiposCubrimiento>();
            foreach (InsurranceLogic.EFDataBaseConecction.TiposCubrimiento dbo in TiposCubrimientosDBO)
            {
                TiposCubrimientosDTO.Add((TiposCubrimiento)adapter.adapt(dbo));
            }
            return TiposCubrimientosDTO;
        }

        public Insurrance GetInsurrance(int id)
        {
            InsurranceLogic.EFDataBaseConecction.Insurrance insurranceDBO = DataAccessFacade.Instance.GetInsurrance(id);
            IAdapter adapter = AdapterCreatorImpl.getInstance().getAdapter("Insurrance");
            return (Insurrance)adapter.adapt(insurranceDBO);
        }

        public int UpdateInsurrance(int id, string Nombre, string descripcion, 
            DateTime inicioVigenciaPoliza, float cobertura, int periodoCobertura, decimal precioPoliza, int tipoRiesgo,
            TiposCubrimiento TiposCubrimiento) {

            IAdapter adapter = AdapterCreatorImpl.getInstance().getAdapter("TiposCubrimiento");
            return DataAccessFacade.Instance.UpdateInsurrance(id, Nombre, descripcion, TiposCubrimiento.id,
            inicioVigenciaPoliza, cobertura, periodoCobertura, precioPoliza, tipoRiesgo);
        }


        public Insurrance AddInsurrance(string Nombre, string descripcion,
            DateTime inicioVigenciaPoliza, float cobertura, int periodoCobertura, decimal precioPoliza, int tipoRiesgo,
            TiposCubrimiento TiposCubrimiento)
        {

            IAdapter adapter = AdapterCreatorImpl.getInstance().getAdapter("TiposCubrimiento");
            InsurranceLogic.EFDataBaseConecction.Insurrance insurranceDBO = DataAccessFacade.Instance.AddInsurrance(
                Nombre, descripcion, TiposCubrimiento.id, inicioVigenciaPoliza, cobertura, periodoCobertura, precioPoliza, 
                tipoRiesgo);
            adapter = AdapterCreatorImpl.getInstance().getAdapter("Insurrance");
            return (Insurrance)adapter.adapt(insurranceDBO);
        }

        public int DeleteInsurrance(int id) {
            return DataAccessFacade.Instance.DeleteInsurrance(id);
        }

        public Usuario login(string nombreUsuario, string contrasena)
        {
            try
            {
                InsurranceLogic.EFDataBaseConecction.Usuario usuario = DataAccessFacade.Instance.getUsuario(nombreUsuario);
                string hashedPass = getHashSha256(contrasena + usuario.salt);
                if (usuario.Contrasena == hashedPass)
                {
                    Usuario usuarioDTO = new Usuario() { Contrasena = "", NombreUsuario = nombreUsuario };
                    //usuarioDTO.Token = getTokenSesion(usuarioDTO);
                    return usuarioDTO;
                }
                else
                {
                    return new Usuario() { Token = "" };
                }
            }
            catch (Exception) {
                return new Usuario() { Token = ""};
            }
        }
        
        public string Authenticate(Usuario login)
        {
            try
            {
                InsurranceLogic.EFDataBaseConecction.Usuario usuario = DataAccessFacade.Instance.getUsuario(login.NombreUsuario);
                string hashedPass = getHashSha256(login.Contrasena + usuario.salt);
                bool isUsernamePasswordValid = usuario.Contrasena == hashedPass;
                if (isUsernamePasswordValid)
                {
                    string token = createToken(login.NombreUsuario);
                    return token;
                }
                else
                {


                    return "401";
                }
            }
            catch (Exception e) {
                return "401";
            }
        }

        private string createToken(string username)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddDays(7);
            
            var tokenHandler = new JwtSecurityTokenHandler();
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:50191", audience: "http://localhost:50191",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public static string getSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            int max_length = 4;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }

        public bool IsValidUser(string nombreUsuario, string contrasena)
        {
            try
            {
                InsurranceLogic.EFDataBaseConecction.Usuario usuario = DataAccessFacade.Instance.getUsuario(nombreUsuario);
                string hashedPass = getHashSha256(contrasena + usuario.salt);
                if (usuario.Contrasena == hashedPass)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
