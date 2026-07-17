using System;
using System.Collections.Generic;
using System.Text;

namespace XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos
{
    public class ItemUsuarioModelo
    {
        public int IdItemUsuario { get; set; }
        public int IdItem { get; set; }
        public int IdUsuario { get; set; }
        public bool Completado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Relevancia { get; set; }
    }
}
