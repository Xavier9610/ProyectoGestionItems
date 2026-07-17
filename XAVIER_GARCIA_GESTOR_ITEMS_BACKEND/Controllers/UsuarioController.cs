using Microsoft.AspNetCore.Mvc;
using XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Interfaz;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;

namespace XAVIER_GARCIA_GESTOR_ITEMS_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioServicio usuario;

        [HttpGet(Name = "Usuarios")]
        public async Task<IEnumerable<UsuarioModelo>> GetUsuarios()
        {
            return await usuario.ConsultarUsuarios();
        }
    }
}
