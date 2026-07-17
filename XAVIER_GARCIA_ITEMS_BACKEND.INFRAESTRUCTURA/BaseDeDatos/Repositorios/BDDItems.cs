using Dapper;
using System.Data;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Conexion;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Entidades;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Repositorios;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores;

namespace XAVIER_GARCIA_GESTOR_ITEMS_BACKEND.BaseDeDatos.Acceso
{
    public class BDDItems: IBDDItems
    {

        private readonly IConexionBDDItems conexionBDDItems;
        public BDDItems(IConexionBDDItems db)
        {
            this.conexionBDDItems = db;
        }
        public async Task<IEnumerable<ItemModelo>> ConsultarItems()
        {
            List<ItemModelo> resultado = new List<ItemModelo>();
            DynamicParameters parametros = new DynamicParameters();
            var sql = conexionBDDItems.CrearConexion();
            var resultadoSp = await sql.QueryAsync<ItemEntidad>("sps_item", parametros, commandType: CommandType.StoredProcedure);
            foreach (var item in resultadoSp.ToList())
            {
                resultado.Add(XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores.Items.MapeaItem(item));
            }
            return resultado.ToList();
        }
        public async Task<bool> InsertarItem(ItemModelo item)
        {
            bool resultado = false;
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@nombre", item.Nombre);
            parametros.Add("@descripcion", item.Descripcion);
            parametros.Add("@fechaEntrega", item.FechaEntrega);
            parametros.Add("@relevncia", item.Relevancia);
            try
            {
                var sql = conexionBDDItems.CrearConexion();
                await sql.ExecuteAsync("spi_item", parametros, commandType: CommandType.StoredProcedure);
                resultado = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return resultado;
        }

        public async Task<bool> AsignarItem(ItemUsuarioModelo itemUsuario)
        {
            bool resultado = false;
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@idItem", itemUsuario.IdItem);
            parametros.Add("@idUsuario", itemUsuario.IdUsuario);
            parametros.Add("@estadoTarea", itemUsuario.Completado);
            parametros.Add("@fechaEntrega", itemUsuario.FechaEntrega);
            parametros.Add("@relevancia", itemUsuario.Relevancia);
            try
            {
                var sql = conexionBDDItems.CrearConexion();
                await sql.ExecuteAsync("spi_item_usuario", parametros, commandType: CommandType.StoredProcedure);
                resultado = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return resultado;
        }

        public async Task<IEnumerable<ItemUsuarioModelo>> ConsultarItemsPorUsuario(int idUsuario)
        {
            List<ItemUsuarioModelo> resultado = new List<ItemUsuarioModelo>();
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@idUsuario", idUsuario);
            var sql = conexionBDDItems.CrearConexion();
            var resultadoSp = await sql.QueryAsync<ItemUsuarioEntidad>("sps_item_usuario", parametros, commandType: CommandType.StoredProcedure);
            foreach (var item in resultadoSp.ToList())
            {
                resultado.Add(XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores.ItemUsuario.MapeaItemUsuario(item));
            }
            return resultado.ToList();
        }

        public async Task<IEnumerable<ItemUsuarioModelo>> ConsultarItemsPorUsuarioMasivo()
        {
            List<ItemUsuarioModelo> resultado = new List<ItemUsuarioModelo>();
            DynamicParameters parametros = new DynamicParameters();
            var sql = conexionBDDItems.CrearConexion();
            var resultadoSp = await sql.QueryAsync<ItemUsuarioEntidad>("sps_item_usuario_todo", parametros, commandType: CommandType.StoredProcedure);
            foreach (var item in resultadoSp.ToList())
            {
                resultado.Add(XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.Mapeadores.ItemUsuario.MapeaItemUsuario(item));
            }
            return resultado.ToList();
        }
    }
}
