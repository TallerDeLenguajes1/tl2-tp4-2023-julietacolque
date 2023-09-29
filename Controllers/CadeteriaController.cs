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
    public ActionResult<Pedido> AddPedido([FromForm] Pedido pedido)
    {

        if (pedido == null) { return BadRequest(); }
        var pedidoN = cadeteria.AñadirPedido(pedido);
        return Ok(pedidoN);


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

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstado(int idP, Estados estado)
    {
        var pedido = cadeteria.CambiarEstado(idP, estado);
        return Ok(pedido);
    }

    [HttpGet("Cadete/{id}")]
    public ActionResult<Cadete> BuscarCadeteID(int id){
    var cadete = cadeteria.ListaCadetes.FirstOrDefault(c=> c.Id == id);
    return cadete;

    }

    [HttpGet("Cadete/Jornal/{id}")]
    public ActionResult<float>JornalACobrar(int id){
        return Ok(cadeteria.JornalACobrar(id));
        
    }

    [HttpGet("Pedido/{id}")]
    public ActionResult<Pedido>BuscarPedido(int id){
        Pedido pedido = cadeteria.ListaPedidos.FirstOrDefault(p=>p.Id==id);
        return pedido;
    }
}