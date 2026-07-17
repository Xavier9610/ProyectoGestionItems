using System;
using System.Collections.Generic;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;

namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Repositorios
{
    public interface IBDDClientes
    {
        public Task<IEnumerable<UsuarioModelo>> ConsultarUsuarios();
    }
}
