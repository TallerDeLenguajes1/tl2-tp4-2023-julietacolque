using Microsoft.AspNetCore.Mvc;
using Web_Api;
namespace tl2_tp4_2023_julietacolque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CadeteriaController:ControllerBase{
// [HttpGet (Name="ListarPedidos")]

// public ActionResult<Pedido> GetListaPedidos(){

// }
    private Cadeteria cadeteria;

    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.GetCadeteria(); //get cadeteria es un metodo estatico debo acceder desde la clase
    } 
   
   
};