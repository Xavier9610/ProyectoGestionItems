using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;

namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores
{
    public static class ItemUsuario
    {
        public static ItemUsuarioModelo MapeaItemUsuario(ItemUsuarioEntidad item)
        {
            return new ItemUsuarioModelo()
            {
                IdItem = item.IdItem,
                IdItemUsuario = item.IdItemUsuario,
                Completado  = item.Completado,
                FechaEntrega = item.FechaEntrega,
                IdUsuario = item.IdUsuario,
                Relevancia = item.Relevancia
            };
        }
    }
}
