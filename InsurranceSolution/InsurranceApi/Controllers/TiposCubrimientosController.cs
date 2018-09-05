
using InsurranceLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsurranceApi.Controllers
{
    [Authorize]
    public class TiposCubrimientosController : ApiController
    {
        public List<TiposCubrimiento> Get()
        {
            return InsurranceLogic.LogicFacade.Instance.GetTiposCubrimientos();
        }
    }
}
