using InsurranceLogic.EFDataBaseConecction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurranceLogic.DataAccess.EFDataBaseConecction
{
    class InsurranceDBModelSeeder : DropCreateDatabaseIfModelChanges<InsurranceDBModel>
    {
        protected override void Seed(InsurranceDBModel context)
        {
            IList<TiposCubrimiento> defaultTiposCubrimiento = new List<TiposCubrimiento>();
            defaultTiposCubrimiento.Add(new TiposCubrimiento() { Nombre = "Terremoto", descripcion = "En caso de Terremoto" });
            defaultTiposCubrimiento.Add(new TiposCubrimiento() { Nombre = "Incendio", descripcion = "En caso de Incendio" });
            defaultTiposCubrimiento.Add(new TiposCubrimiento() { Nombre = "Robo", descripcion = "En caso de String" });
            defaultTiposCubrimiento.Add(new TiposCubrimiento() { Nombre = "Perdida", descripcion = "En caso de Perdida" });

            foreach (TiposCubrimiento tc in defaultTiposCubrimiento)
                context.TiposCubrimientos.Add(tc);

            Perfil perfil = new Perfil();
            perfil.Nombre = "Administrador";
            context.perfiles.Add(perfil);

            Usuario usuario = new Usuario();
            usuario.NombreUsuario = "gapuser";
            usuario.perfil = perfil;
            usuario.salt = LogicFacade.getSalt();
            usuario.Contrasena = LogicFacade.getHashSha256("123456" + usuario.salt);
            
            context.usuarios.Add(usuario);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
