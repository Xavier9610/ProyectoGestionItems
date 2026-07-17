using Microsoft.AspNetCore.Mvc;
using XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Interfaz;
using XAVIER_GARCIA_ITEMS_BACKEND.DOMINIO.Modelos;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private IItemsServicio items;
    public ItemsController (IItemsServicio controller)
    {
        this.items = controller;   
    }

    [HttpGet]
    public async Task<IEnumerable<ItemModelo>> GetItems()
    {
        return await items.ConsultarItems();
    }

    [HttpPost("asignar")]
    public async Task<bool> AsignarItemAutomatico(ItemUsuarioModelo modelo)
    {
        return await items.AsignarItem(modelo);
    }

    [HttpPost("asignar-automatico")]
    public async Task<ResultadoDeAsignaciones> AsignarItemAutomatico()
    {
        return await items.AsignarItemAutomatico();
    }

    [HttpPut("insertar")]
    public async Task<bool> InsertarItem(ItemModelo modelo)
    {
        return await items.InsertarItem(modelo);
    }

    [HttpGet("usuario/{idUsuario}")]
    public async Task<IEnumerable<ItemUsuarioModelo>> PorUsuario(int idUsuario)
    {
        return await items.ConsultarItemsPorUsuario(idUsuario);
    }
}