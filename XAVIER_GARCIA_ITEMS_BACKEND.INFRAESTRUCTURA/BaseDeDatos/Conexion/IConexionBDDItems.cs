using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;

namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Conexion
{
    public interface IConexionBDDItems
    {
        IDbConnection CrearConexion();
    }
}
