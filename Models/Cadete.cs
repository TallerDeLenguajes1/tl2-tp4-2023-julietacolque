namespace Web_Api
{
  public class Cadete
  {
    public int Id { get; set; }
    public string Nombre { get; set; }

    public string Telefono { get; set; }



    public Cadete(int id, string nombre, string telefono)
    {
      Id = id;
      Nombre = nombre;
      Telefono = telefono;
    }
 
  }

}
