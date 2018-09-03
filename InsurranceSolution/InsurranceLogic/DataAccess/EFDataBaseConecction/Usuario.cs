using InsurranceLogic.DataAccess.EFDataBaseConecction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace InsurranceLogic.EFDataBaseConecction
{
    [Table("Usuarios")]
    public partial class Usuario : DBO
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(500)]
        public string Contrasena { get; set; }

        [Required]
        [StringLength(100)]
        public string salt { get; set; }

        public int idPerfil { get; set; }

        public virtual Perfil perfil { get; set; }
    }
}
