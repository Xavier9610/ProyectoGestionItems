using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;

namespace XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Interfaz
{
    public interface IUsuarioServicio
    {
        public Task<IEnumerable<UsuarioModelo>> ConsultarUsuarios();
    }
}
