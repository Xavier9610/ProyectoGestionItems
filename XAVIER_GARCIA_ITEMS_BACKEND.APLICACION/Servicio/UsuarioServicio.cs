using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_GESTOR_ITEMS_BACKEND.BaseDeDatos.Acceso;
using XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Interfaz;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Repositorios;

namespace XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Servicio
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private IBDDClientes clientes;
        private IBDDItems items;

        public UsuarioServicio(IBDDClientes clientes, IBDDItems items)
        {
            this.clientes = clientes;
            this.items = items;
        }

        public async Task<IEnumerable<DOMINIO.Modelos.UsuarioModelo>> ConsultarUsuarios()
        {
            List<UsuarioModelo> usuarios = new List<UsuarioModelo>();
            var clientesRespuesta = await clientes.ConsultarUsuarios();
            foreach (var usuario in clientesRespuesta)
            {
                usuario.Tareas = await items.ConsultarItemsPorUsuario(usuario.IdUsuario);
                usuarios.Add(usuario);
            }
            return usuarios;
        }
    }
}
