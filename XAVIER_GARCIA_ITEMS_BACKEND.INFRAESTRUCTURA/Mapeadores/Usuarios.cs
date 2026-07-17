using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;

namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores
{
    public static class Usuarios
    {
        public static UsuarioModelo MapeaItemUsuario(UsuarioEntidad item)
        {
            return new UsuarioModelo()
            {
                IdCliente = item.IdCliente,
                IdUsuario = item.IdUsuario,
                NombreUsuario = item.NombreUsuario,
                Tareas = new List<ItemUsuarioModelo>()
            };
        }
    }
}
