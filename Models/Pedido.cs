namespace Web_Api
{
  public class Pedido
  {
    public int Id { get; set; }
    public string Observacion { get; set; }

    public Cliente Cliente { get; set; }

    public Estados Estado { get; set; }

    public int IdCadete{get;set;}

    //constructor
    public Pedido(string observacion, Cliente cliente){
      Id = 0;
      Observacion = observacion;
      Cliente = cliente;

    }

    public Pedido(){
  
      
    }

     public string DireccionCliente(){
      return Cliente.Domicilio;
     }
     public string VerDatosCliente(){
      return Cliente.DatosReferenciaDireccion;
     }

     public void CambiarEstado(Estados estado){
          Estado = estado;
     }
  }
}
public enum Estados
{
  EnCurso,
  Entregado,
  Cancelado
}