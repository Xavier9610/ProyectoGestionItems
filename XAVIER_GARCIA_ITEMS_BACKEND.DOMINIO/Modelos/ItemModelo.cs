using System;
using System.Collections.Generic;
using System.Text;

namespace XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos
{
    public class ItemModelo
    {
        public int IdItem { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Relevancia { get; set; }
    }
}
