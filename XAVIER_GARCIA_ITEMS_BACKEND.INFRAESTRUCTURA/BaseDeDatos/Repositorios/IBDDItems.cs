using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;

namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Repositorios
{
    public interface IBDDItems
    {
        public Task<IEnumerable<ItemModelo>> ConsultarItems();
        public Task<bool> InsertarItem(ItemModelo item);
        public Task<bool> AsignarItem(ItemUsuarioModelo itemUsuario);
        public Task<IEnumerable<ItemUsuarioModelo>> ConsultarItemsPorUsuario(int idUsuario);
        public Task<IEnumerable<ItemUsuarioModelo>> ConsultarItemsPorUsuarioMasivo();
    }
}
