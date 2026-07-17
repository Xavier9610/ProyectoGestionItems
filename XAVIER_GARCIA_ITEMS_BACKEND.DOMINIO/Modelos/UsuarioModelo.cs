using System;
using System.Collections.Generic;
using System.Text;

namespace XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos
{
    public class UsuarioModelo
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int IdCliente { get; set; }
        public IEnumerable<ItemUsuarioModelo> Tareas { get; set; }
    }
}
