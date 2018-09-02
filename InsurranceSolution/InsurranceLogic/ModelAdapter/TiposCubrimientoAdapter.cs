

using InsurranceLogic.DataAccess.EFDataBaseConecction;
using InsurranceLogic.Model;
using InsurranceLogic.ModelAdapter;

namespace TiposCubrimientoLogic.ModelAdapter
{
    internal class TiposCubrimientoAdapter : IAdapter
    {
        public DTO adapt(DBO dbo)
        {
            InsurranceLogic.EFDataBaseConecction.TiposCubrimiento TiposCubrimientoDBO = (InsurranceLogic.EFDataBaseConecction.TiposCubrimiento)dbo;
            InsurranceLogic.Model.TiposCubrimiento TiposCubrimientoDTO = new TiposCubrimiento();
            TiposCubrimientoDTO.Nombre = TiposCubrimientoDBO.Nombre;
            TiposCubrimientoDTO.descripcion = TiposCubrimientoDBO.descripcion;
            TiposCubrimientoDTO.id = TiposCubrimientoDBO.id;
            
            return TiposCubrimientoDTO;
        }

        public DBO adapt(DTO dto)
        {
            InsurranceLogic.Model.TiposCubrimiento TiposCubrimientoDTO = (InsurranceLogic.Model.TiposCubrimiento)dto;
            InsurranceLogic.EFDataBaseConecction.TiposCubrimiento TiposCubrimientoDBO = new InsurranceLogic.EFDataBaseConecction.TiposCubrimiento();
            TiposCubrimientoDBO.Nombre = TiposCubrimientoDTO.Nombre;
            TiposCubrimientoDBO.descripcion = TiposCubrimientoDTO.descripcion;
            TiposCubrimientoDBO.id = TiposCubrimientoDTO.id;
            return TiposCubrimientoDBO;
        }
    }
}