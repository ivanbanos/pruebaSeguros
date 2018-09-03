using InsurranceLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsurranceApi.Controllers
{
    public class LoginController : ApiController
    {
        public Usuario Post([FromBody]Usuario elemento)
        {
            return InsurranceLogic.LogicFacade.Instance.login(elemento.NombreUsuario, elemento.Contrasena);
        }
    }
}
