﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurranceLogic.EFDataBaseConecction;


namespace InsurranceLogic.Model
{
    public partial class Usuario : DTO
    {
        public int id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string salt { get; set; }
    }
}
