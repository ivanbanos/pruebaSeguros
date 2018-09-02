using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurranceLogic.EFDataBaseConecction;

namespace InsurranceLogic.Model
{
    public class Insurrance: DTO
    {

        public int id { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        

        public DateTime inicioVigenciaPoliza { get; set; }

        public int periodoCobertura { get; set; }
        public decimal precioPoliza { get; set; }

        public int tipoRiesgo { get; set; }

        public virtual TiposCubrimiento TiposCubrimiento { get; set; }
    }
}
