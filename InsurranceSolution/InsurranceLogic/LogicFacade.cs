using InsurranceLogic.DataAccess.Repository;
using InsurranceLogic.EFDataBaseConecction;
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
            using (var dataContext = new InsurranceDBModel())
            {
                var insurranceRepository = new Repository<Insurrance>(dataContext);

                List<Insurrance> insurrances = insurranceRepository.All();

                return insurrances;
            }
        }

        public List<TiposCubrimiento> GetTiposCubrimientos() {
            using (var dataContext = new InsurranceDBModel())
            {
                var TiposCubrimientoRepository = new Repository<TiposCubrimiento>(dataContext);

                List<TiposCubrimiento> insurrances = TiposCubrimientoRepository.All();

                return insurrances;
            }
        }

        public Insurrance GetInsurrance(int id)
        {
            using (var dataContext = new InsurranceDBModel())
            {
                var insurranceRepository = new Repository<Insurrance>(dataContext);

                Insurrance insurrance = insurranceRepository.Find(c => c.id == id);

                return insurrance;
            }
        }

        public int UpdateInsurrance(int id, string Nombre, string descripcion, int idTipoCubrimiento, 
            DateTime inicioVigenciaPoliza, int periodoCobertura, decimal precioPoliza, int tipoRiesgo,
            TiposCubrimiento TiposCubrimiento) {
            using (var dataContext = new InsurranceDBModel())
            {
                var insurranceRepository = new Repository<Insurrance>(dataContext);
                Insurrance insurrance = insurranceRepository.Find(c => c.id == id);
                insurrance.Nombre = Nombre;
                insurrance.descripcion = descripcion;
                insurrance.idTipoCubrimiento = idTipoCubrimiento;
                insurrance.inicioVigenciaPoliza = inicioVigenciaPoliza;
                insurrance.periodoCobertura = periodoCobertura;
                insurrance.precioPoliza = precioPoliza;
                insurrance.tipoRiesgo = tipoRiesgo;
                insurrance.TiposCubrimiento = TiposCubrimiento;

                return insurranceRepository.Update(insurrance);
            }
        }


        public Insurrance AddInsurrance(string Nombre, string descripcion, int idTipoCubrimiento,
            DateTime inicioVigenciaPoliza, int periodoCobertura, decimal precioPoliza, int tipoRiesgo,
            TiposCubrimiento TiposCubrimiento)
        {
            using (var dataContext = new InsurranceDBModel())
            {
                var insurranceRepository = new Repository<Insurrance>(dataContext);
                Insurrance insurrance = new Insurrance();
                insurrance.Nombre = Nombre;
                insurrance.descripcion = descripcion;
                insurrance.idTipoCubrimiento = idTipoCubrimiento;
                insurrance.inicioVigenciaPoliza = inicioVigenciaPoliza;
                insurrance.periodoCobertura = periodoCobertura;
                insurrance.precioPoliza = precioPoliza;
                insurrance.tipoRiesgo = tipoRiesgo;
                insurrance.TiposCubrimiento = TiposCubrimiento;

                return insurranceRepository.Create(insurrance);
            }
        }

        public int DeleteInsurrance(int id) {
            using (var dataContext = new InsurranceDBModel())
            {
                var insurranceRepository = new Repository<Insurrance>(dataContext);
                

                return insurranceRepository.Delete(c => c.id == id);
            }
        }
    }
}
