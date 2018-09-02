using InsurranceLogic.EFDataBaseConecction;
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
        
        public Insurrance Post([FromBody]string Nombre, [FromBody]string descripcion, [FromBody]int idTipoCubrimiento,
            [FromBody]DateTime inicioVigenciaPoliza, [FromBody]int periodoCobertura, [FromBody]decimal precioPoliza,
            [FromBody]int tipoRiesgo, [FromBody]TiposCubrimiento TiposCubrimiento)
        {

            return InsurranceLogic.LogicFacade.Instance.AddInsurrance(Nombre, descripcion, idTipoCubrimiento,
            inicioVigenciaPoliza, periodoCobertura, precioPoliza, tipoRiesgo, TiposCubrimiento);
        }
        
        public void Put(int id, [FromBody]string Nombre, [FromBody]string descripcion, [FromBody]int idTipoCubrimiento,
            [FromBody]DateTime inicioVigenciaPoliza, [FromBody]int periodoCobertura, [FromBody]decimal precioPoliza,
            [FromBody]int tipoRiesgo, [FromBody]TiposCubrimiento TiposCubrimiento)
        {
            InsurranceLogic.LogicFacade.Instance.UpdateInsurrance(id, Nombre, descripcion, idTipoCubrimiento,
            inicioVigenciaPoliza, periodoCobertura, precioPoliza, tipoRiesgo, TiposCubrimiento);
        }
        
        public void Delete(int id)
        {
            InsurranceLogic.LogicFacade.Instance.DeleteInsurrance(id);
        }
    }
}
