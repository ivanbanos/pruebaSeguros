using InsurranceLogic.Model;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace InsurranceApi.Authentication
{

    public class Authentication
    {
        private static Authentication instance;
        private JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        public static Authentication Instance
        {
            get { return instance ?? (instance = new Authentication()); }
        }

        //public object GetAuthToken(Usuario user)
        //{
        //    var token = GenerateToken(user);

        //    return new
        //    {
        //        accessToken = token
        //    };
        //}

        public string GenerateToken(Usuario user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.NombreUsuario, "TokenAuth"),
                new[]
                {
                    new Claim("NombreUsuario", user.NombreUsuario),
                    new Claim("Contrasena", user.Contrasena), 
                }
            );

            RsaSecurityKey Key = new RsaSecurityKey(RSAKeyHelper.GenerateKey());

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = user.NombreUsuario,
                Audience = user.Contrasena,
                SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature),
                Subject = identity
            });
            return handler.WriteToken(securityToken);
        }

        public Usuario GetUserByToken(string token)
        {
            try
            {
                var tokenS = handler.ReadToken(token) as JwtSecurityToken;

                var user = tokenS.Claims.First(claim => claim.Type == "NombreUsuario").Value;
                var passValue = tokenS.Claims.First(claim => claim.Type == "Contrasena").Value;

                return new Usuario
                {
                    NombreUsuario = user,
                    Contrasena = passValue
                };
            }
            catch (Exception)
            {
                return new Usuario
                {
                    NombreUsuario = string.Empty,
                    Contrasena = string.Empty
                };
            }
            
        }
    }
}