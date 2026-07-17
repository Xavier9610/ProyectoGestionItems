using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades
{
    public class ItemEntidad
    {
        public int IdItem {  get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime	FechaEntrega { get; set; }
        public bool Relevancia { get; set; }
    }
}
