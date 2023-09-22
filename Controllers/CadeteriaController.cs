using Microsoft.AspNetCore.Mvc;
using Web_Api;
namespace tl2_tp4_2023_julietacolque.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{

    private Cadeteria cadeteria;

    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.GetCadeteria(); //get cadeteria es un metodo estatico debo acceder desde la clase
    }



    [HttpGet("ListarPedidos")]

    public ActionResult<Pedido> GetListaPedidos()
    {
        var pedidos = cadeteria.ListaPedidos;
        if (pedidos.Count() > 0)
        {
            return Ok(pedidos);
        }
        else
        {
            return NoContent();
        }

    }
    [HttpGet("ListaCadetes")]
    public ActionResult<Cadete> GetListaCadete()
    {
        var cadetes = cadeteria.ListaCadetes;
        if (cadetes.Count() > 0)
        {
            return Ok(cadetes);
        }
        else
        {
            return NoContent();
        }

    }
    [HttpPost("AddPedido")]
    public ActionResult<Pedido> AddPedido(int id, string obs, string nombre, string telefono, string direccion, string datosRef)
    {

        var nuevoPedido = cadeteria.AñadirPedido(id, obs, nombre, telefono, direccion, datosRef);
        if (nuevoPedido != null)
        {
            return Ok(nuevoPedido);
        }
        else
        {
            return BadRequest();
        }


    }
    [HttpPut("AsignarPedido")]

    public ActionResult<Pedido> AsignarPedido(int idP, int idC)
    {
        var pedido = cadeteria.AsignarPedido(idC, idP);
        if (pedido != null)
        {
            return Ok(pedido);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut("ReasignarPedido")]
    public ActionResult<Pedido> ReasignarPedido(int idC, int idP)
    {
        var pedido = cadeteria.ReasignarPedido(idP, idC);
        if (pedido != null)
        {
            return Ok(pedido);
        }
        else
        {
            return BadRequest();
        }
    }
}