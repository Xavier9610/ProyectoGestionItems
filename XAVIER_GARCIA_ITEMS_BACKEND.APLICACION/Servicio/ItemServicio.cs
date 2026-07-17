using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_GESTOR_ITEMS_BACKEND.BaseDeDatos.Acceso;
using XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Interfaz;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Repositorios;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores;

namespace XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Servicio
{
    public class ItemServicio : IItemsServicio
    {
        private IBDDItems items;
        private IBDDClientes clientes;

        public ItemServicio(IBDDClientes clientes, IBDDItems items)
        {
            this.clientes = clientes;
            this.items = items;
        }

        public async Task<bool> AsignarItem(ItemUsuarioModelo itemUsuario)
        {
            return await items.AsignarItem(itemUsuario);
        }

        /// <summary>
        /// Todo el proceso
        /// </summary>
        /// <returns></returns>
        public async Task<ResultadoDeAsignaciones> AsignarItemAutomatico()
        {
            ///obtiene todos los usuarios
            var usuarios = await clientes.ConsultarUsuarios();
            foreach (var usuario in usuarios)
            {
                usuario.Tareas = await items.ConsultarItemsPorUsuario(usuario.IdUsuario);
            }
            /// obtiene todas las tareas asignadas
            var itemsPorUsuarioGeneral = await items.ConsultarItemsPorUsuarioMasivo();
            var idUsuariosDescartados = itemsPorUsuarioGeneral.Where(x => x.Relevancia)
                .GroupBy(x => x.IdUsuario)
                .Where(x => x.Count() >= 3)
                .Select(x => x.Key).ToList();
            /// usuarios para 
            var usuariosParaAsignar = usuarios.Where(x => !idUsuariosDescartados.Contains(x.IdUsuario));
            /// ordenar en base a su tareas ya asignadas
            var idUsuariosConTareasOrdenados = itemsPorUsuarioGeneral
                .GroupBy(x => x.IdUsuario)
                .Where(x => x.Count() < 3).OrderBy( x => x.Count())
                .Select(x => x.Key).ToList();
            /// tareas aun no asignadas
            var itemsTotales = await items.ConsultarItems();
            var itemsNoAsignados = itemsTotales.Where( x => !itemsPorUsuarioGeneral.Select( i => i.IdItem).Contains(x.IdItem)).ToList();
            var itemNoAsignadosPorVencer = itemsNoAsignados.Where(x => (x.FechaEntrega - DateTime.Now).TotalDays < 3).ToList();
            var itemNoAsignadosFechaLarga = itemsNoAsignados.Where(x => (x.FechaEntrega - DateTime.Now).TotalDays >= 3).OrderByDescending( x => x.Relevancia).ToList();
            /// se ordenan los usuarios que tienen y no tareas pero pueden tomar mas tareas aun
            var usuariosConYSinTareasOrdenados = idUsuariosConTareasOrdenados
                .Select((id, indice) => new { id, indice })
                .ToDictionary(x => x.id, x => x.indice);
            var clientesOrdenados = usuariosParaAsignar
                .OrderBy(c => usuariosConYSinTareasOrdenados.ContainsKey(c.IdCliente) ? 1 : 0)
                .ThenBy(c => usuariosConYSinTareasOrdenados.GetValueOrDefault(c.IdCliente, int.MaxValue))
                .ToList();

            await AsignarTareas(clientesOrdenados, itemNoAsignadosPorVencer);
            await AsignarTareas(clientesOrdenados, itemNoAsignadosFechaLarga);
            return new ResultadoDeAsignaciones { Usuarios = usuarios };
        }

        private async Task AsignarTareas(List<UsuarioModelo> clientesOrdenados, List<ItemModelo> listaDeItems)
        {
            int indice = 0;
            UsuarioModelo usuarioModelo = clientesOrdenados[indice];
            foreach (var item in listaDeItems)
            {
                await items.AsignarItem(new ItemUsuarioModelo 
                { 
                    Completado = false, 
                    FechaEntrega = item.FechaEntrega, 
                    IdItem = item.IdItem, 
                    IdUsuario = usuarioModelo.IdUsuario, 
                    Relevancia = item.Relevancia });
                var itemUsuarios = await items.ConsultarItemsPorUsuario(usuarioModelo.IdUsuario);
                usuarioModelo.Tareas = itemUsuarios;
                clientesOrdenados[indice] = usuarioModelo;
                if (indice + 1 >= clientesOrdenados.Count)
                {
                    Console.WriteLine("Si mas usuarios para asignar tareas");
                    break;
                }
                if (itemUsuarios.Count() >= clientesOrdenados[indice + 1].Tareas.Count())
                {
                    usuarioModelo = clientesOrdenados[indice + 1];
                    indice++;
                }
            }
        }

        public async Task<IEnumerable<ItemModelo>> ConsultarItems()
        {
            return await items.ConsultarItems();
        }

        public async Task<IEnumerable<ItemUsuarioModelo>> ConsultarItemsPorUsuario(int idUsuario)
        {
            return await items.ConsultarItemsPorUsuario(idUsuario);
        }

        public async Task<bool> InsertarItem(ItemModelo item)
        {
            return await items.InsertarItem(item);
        }
    }
}
