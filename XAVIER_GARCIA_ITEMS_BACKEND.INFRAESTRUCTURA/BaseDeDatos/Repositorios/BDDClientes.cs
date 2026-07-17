using Dapper;
using System.Data;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Conexion;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Repositorios;

namespace XAVIER_GARCIA_GESTOR_ITEMS_BACKEND.BaseDeDatos.Acceso
{
    public class BDDClientes : IBDDClientes
    {
        private readonly IConexionBDDClientes conexionBDDClientes;
        public BDDClientes(IConexionBDDClientes db)
        {
            this.conexionBDDClientes = db;
        }
        public async Task<IEnumerable<UsuarioModelo>> ConsultarUsuarios()
        {
            List<UsuarioModelo> resultado = new List<UsuarioModelo>();
            DynamicParameters parametros = new DynamicParameters();
            var sql = conexionBDDClientes.CrearConexion();
            var resultadoSp = await sql.QueryAsync<UsuarioEntidad>("sps_usuario", parametros, commandType: CommandType.StoredProcedure);
            foreach (var item in resultadoSp.ToList()) {
                resultado.Add(XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores.Usuarios.MapeaItemUsuario(item));
            }
            return resultado.ToList();
        }
    }
}
