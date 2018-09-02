using InsurranceLogic.DataAccess.Repository;
using InsurranceLogic.EFDataBaseConecction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurranceLogic.DataAccess
{
    class DataAccessFacade
    {
        private static DataAccessFacade instance;

        public static DataAccessFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccessFacade();
                }
                return instance;
            }
        }

        private DataAccessFacade() { }

        public List<Insurrance> GetInsurrances()
        {
            using (var dataContext = new InsurranceDBModel())
            {
                var insurranceRepository = new Repository<Insurrance>(dataContext);

                List<Insurrance> insurrances = insurranceRepository.All();

                return insurrances;
            }
        }

        public List<TiposCubrimiento> GetTiposCubrimientos()
        {
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

                Insurrance insurrance = insurranceRepository.Find(id);

                return insurrance;
            }
        }

        public int UpdateInsurrance(int id, string Nombre, string descripcion, int idTipoCubrimiento,
            DateTime inicioVigenciaPoliza, int periodoCobertura, decimal precioPoliza, int tipoRiesgo)
        {
            using (var dataContext = new InsurranceDBModel())
            {
                var insurranceRepository = new Repository<Insurrance>(dataContext);
                Insurrance insurrance = insurranceRepository.Find(id);
                insurrance.Nombre = Nombre;
                insurrance.descripcion = descripcion;
                insurrance.idTipoCubrimiento = idTipoCubrimiento;
                insurrance.inicioVigenciaPoliza = inicioVigenciaPoliza;
                insurrance.periodoCobertura = periodoCobertura;
                insurrance.precioPoliza = precioPoliza;
                insurrance.tipoRiesgo = tipoRiesgo;

                return insurranceRepository.Update(insurrance);
            }
        }


        public Insurrance AddInsurrance(string Nombre, string descripcion, int idTipoCubrimiento,
            DateTime inicioVigenciaPoliza, int periodoCobertura, decimal precioPoliza, int tipoRiesgo)
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

                return insurranceRepository.Create(insurrance);
            }
        }

        public int DeleteInsurrance(int  id)
        {
            using (var dataContext = new InsurranceDBModel())
            {
                var insurranceRepository = new Repository<Insurrance>(dataContext);
                Insurrance insurrance = insurranceRepository.Find(id);

                return insurranceRepository.Delete(insurrance);
            }
        }
    }
}