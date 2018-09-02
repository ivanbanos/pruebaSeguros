using InsurranceLogic.DataAccess;
using InsurranceLogic.DataAccess.Repository;
using InsurranceLogic.Model;
using InsurranceLogic.ModelAdapter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
    }
}
