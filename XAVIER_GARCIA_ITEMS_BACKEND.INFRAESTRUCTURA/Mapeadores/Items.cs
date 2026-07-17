using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;

namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores
{
    public static class Items
    {
        public static ItemModelo MapeaItem(ItemEntidad item)
        {
            return new ItemModelo()
            {
                IdItem = item.IdItem, Descripcion = item.Descripcion, FechaEntrega = item.FechaEntrega, Nombre = item.Nombre, Relevancia = item.Relevancia
            };
        }
    }
}
