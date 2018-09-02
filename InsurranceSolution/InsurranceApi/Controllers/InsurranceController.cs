﻿
using InsurranceLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsurranceApi.Controllers
{
    public class InsurranceController : ApiController
    {
        public List<Insurrance> Get()
        {
            return InsurranceLogic.LogicFacade.Instance.GetInsurrances();
        }
        
        public Insurrance Get(int id)
        {
            return InsurranceLogic.LogicFacade.Instance.GetInsurrance(id);
        }
        
        public Insurrance Post([FromBody]Insurrance elemento)
        {

            return InsurranceLogic.LogicFacade.Instance.AddInsurrance(elemento.Nombre, elemento.descripcion,
            elemento.inicioVigenciaPoliza, elemento.periodoCobertura, elemento.precioPoliza, elemento.tipoRiesgo, elemento.TiposCubrimiento);
        }
        
        public void Put(int id, [FromBody]Insurrance elemento)
        {
            InsurranceLogic.LogicFacade.Instance.UpdateInsurrance(id, elemento.Nombre, elemento.descripcion,
            elemento.inicioVigenciaPoliza, elemento.periodoCobertura, elemento.precioPoliza, elemento.tipoRiesgo, elemento.TiposCubrimiento);
        }
        
        public void Delete(int id)
        {
            InsurranceLogic.LogicFacade.Instance.DeleteInsurrance(id);
        }
    }
}
