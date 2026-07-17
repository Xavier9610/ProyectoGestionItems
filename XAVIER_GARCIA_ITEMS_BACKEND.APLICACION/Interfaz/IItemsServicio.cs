using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;

namespace XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Interfaz
{
    public interface IItemsServicio
    {
        public Task<IEnumerable<ItemModelo>> ConsultarItems();
        public Task<bool> InsertarItem(ItemModelo item);
        public Task<bool> AsignarItem(ItemUsuarioModelo itemUsuario);
        public Task<ResultadoDeAsignaciones> AsignarItemAutomatico();
        public Task<IEnumerable<ItemUsuarioModelo>> ConsultarItemsPorUsuario(int idUsuario);
    }
}
