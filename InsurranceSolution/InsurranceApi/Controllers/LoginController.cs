using InsurranceLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Security.Claims;
using System.Web;

namespace InsurranceApi.Controllers
{
    public class LoginController : ApiController
    {
        public IHttpActionResult Post([FromBody]Usuario elemento)
        {
            string token =  InsurranceLogic.LogicFacade.Instance.Authenticate(elemento);
            if(token != "401")
                return Ok<string>(token);
            IHttpActionResult response;
            HttpResponseMessage responseMsg = new HttpResponseMessage();
            responseMsg.StatusCode = HttpStatusCode.Unauthorized;
            response = ResponseMessage(responseMsg);
            return response;
        }

        
    }
}
