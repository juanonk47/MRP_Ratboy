using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Ratboy.Models
{
    public class EUsuarioPersona
    {
        public string nombre { get; set; }
        public string apePaterno { get; set; }
        public string apeMaterno { get; set; }
        public int edad { get; set; }
        public string direccion {get; set;}
        public string correo { get; set; }

        //VARIABLES PARA EL USO DEL USUARIO
        public string username { get; set; }
        public string password { get; set; }

    }
}