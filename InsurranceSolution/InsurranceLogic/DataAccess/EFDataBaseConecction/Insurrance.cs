namespace InsurranceLogic.EFDataBaseConecction
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Insurrance")]
    public partial class Insurrance
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string descripcion { get; set; }

        public int idTipoCubrimiento { get; set; }

        public DateTime inicioVigenciaPoliza { get; set; }

        public int periodoCobertura { get; set; }

        [Column(TypeName = "money")]
        public decimal precioPoliza { get; set; }

        public int tipoRiesgo { get; set; }

        public virtual TiposCubrimiento TiposCubrimiento { get; set; }
    }
}
