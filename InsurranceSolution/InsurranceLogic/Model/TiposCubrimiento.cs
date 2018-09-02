using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurranceLogic.Model
{
    public class TiposCubrimiento: DTO
    {

        public int id { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
    }
}
