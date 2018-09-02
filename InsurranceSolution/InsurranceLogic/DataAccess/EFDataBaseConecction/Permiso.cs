using InsurranceLogic.DataAccess.EFDataBaseConecction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace InsurranceLogic.DataAccess.EFDataBaseConecction
{
    [Table("Permisos")]
    public partial class Permiso : DBO
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perfil> perfiles { get; set; }
    }
}
