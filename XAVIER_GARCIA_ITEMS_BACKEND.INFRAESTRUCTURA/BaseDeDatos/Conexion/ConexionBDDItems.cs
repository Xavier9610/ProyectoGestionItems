using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Conexion
{
    public class ConexionBDDItems : IConexionBDDItems
    {
        private readonly string _connectionString;

        public ConexionBDDItems(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DbItems")!;
        }


        public IDbConnection CrearConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
