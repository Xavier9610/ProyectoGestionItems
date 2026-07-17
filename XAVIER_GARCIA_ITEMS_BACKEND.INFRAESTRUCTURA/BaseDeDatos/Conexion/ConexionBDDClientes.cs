using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;
using System.IO.Pipes;
using Dapper;


namespace XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Conexion
{
    public class ConexionBDDClientes : IConexionBDDClientes
    {
        private SqlConnection sql;
        private readonly string _connectionString;

        public ConexionBDDClientes(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DbClientes")!;
        }

        public IDbConnection CrearConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
