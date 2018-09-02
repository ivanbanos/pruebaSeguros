using InsurranceLogic.DataAccess.EFDataBaseConecction;
using InsurranceLogic.Model;

namespace InsurranceLogic.ModelAdapter
{
    internal class InsurranceAdapter : IAdapter
    {
        public DTO adapt(DBO dbo)
        {
            InsurranceLogic.EFDataBaseConecction.Insurrance insurranceDBO = (InsurranceLogic.EFDataBaseConecction.Insurrance)dbo;
            InsurranceLogic.Model.Insurrance insurranceDTO = new Insurrance();
            insurranceDTO.Nombre = insurranceDBO.Nombre;
            insurranceDTO.descripcion = insurranceDBO.descripcion;
            insurranceDTO.id = insurranceDBO.id;
            insurranceDTO.inicioVigenciaPoliza = insurranceDBO.inicioVigenciaPoliza;
            insurranceDTO.periodoCobertura = insurranceDBO.periodoCobertura;
            insurranceDTO.cobertura = insurranceDBO.cobertura;
            insurranceDTO.precioPoliza = insurranceDBO.precioPoliza;
            insurranceDTO.tipoRiesgo = insurranceDBO.tipoRiesgo;
            insurranceDTO.TiposCubrimiento = new TiposCubrimiento();
            insurranceDTO.TiposCubrimiento.id = insurranceDBO.idTipoCubrimiento;
            return insurranceDTO;
        }

        public DBO adapt(DTO dto)
        {
            InsurranceLogic.Model.Insurrance insurranceDTO = (InsurranceLogic.Model.Insurrance)dto;
            InsurranceLogic.EFDataBaseConecction.Insurrance insurranceDBO = new EFDataBaseConecction.Insurrance();
            insurranceDBO.Nombre = insurranceDTO.Nombre;
            insurranceDBO.descripcion = insurranceDTO.descripcion;
            insurranceDBO.cobertura = insurranceDTO.cobertura;
            insurranceDBO.id = insurranceDTO.id;
            insurranceDBO.inicioVigenciaPoliza = insurranceDTO.inicioVigenciaPoliza;
            insurranceDBO.periodoCobertura = insurranceDTO.periodoCobertura;
            insurranceDBO.precioPoliza = insurranceDTO.precioPoliza;
            insurranceDBO.tipoRiesgo = insurranceDTO.tipoRiesgo;
            insurranceDBO.idTipoCubrimiento = insurranceDTO.TiposCubrimiento.id;
            return insurranceDBO;
        }
    }
}