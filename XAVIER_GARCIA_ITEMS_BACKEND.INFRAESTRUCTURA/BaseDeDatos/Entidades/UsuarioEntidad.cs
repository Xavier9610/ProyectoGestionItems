using System;
using System.Collections.Generic;
using System.Text;

namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades
{
    public class UsuarioEntidad
    {
        public int IdUsuario { get; set; } 
        public string NombreUsuario { get; set; }
        public int IdCliente { get; set; }
    }
}
