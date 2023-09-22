namespace Web_Api
{
    public class Cliente
    {
        public Cliente(string nombre, string telefono, string domicilio,string datosRef)
        {
            Nombre = nombre;
            Telefono = telefono;
            Domicilio = domicilio;
            DatosReferenciaDireccion = datosRef;
        }

        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public string Domicilio { get; set; }

        public string DatosReferenciaDireccion{get;set;}
        
        public string DatosCliente(Cliente cliente){
            
            string datos = $"Nombre: {cliente.Nombre}\nTelefono: {cliente.Telefono}\nDomicilio: {cliente.Domicilio}";
            return datos;
        }
    }
}