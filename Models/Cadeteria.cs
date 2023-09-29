namespace Web_Api
{
    public class Cadeteria
    {
        private static Cadeteria CadeteriaSingleton;


        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public List<Cadete> ListaCadetes { get; set; }
        public List<Pedido> ListaPedidos { get; set; }


        public static Cadeteria GetCadeteria()
        { //Sirve para crear una unica instancia de la clase cadeteria para que perduren los datos.Cuando se ejecuta una vez la aplicacion la instancia queda creada para el resto de vida de la app.
            if (CadeteriaSingleton == null)
            {
                CadeteriaSingleton = new Cadeteria();
            }

            return CadeteriaSingleton;
        }

        // public Cadeteria()
        // {
        //     ListaPedidos = new();
        //     ListaCadetes = new();
        // }

        // public Cadeteria(string nombre, string telefono)
        // {
        //     Nombre = nombre;
        //     Telefono = telefono;
        //     ListaCadetes = new();
        //     ListaPedidos = new();
        //     Cadete cadete= new(1,"as","asdasd");
        //     ListaCadetes.Add(cadete);

        // }

        public Cadeteria()
        {
            ListaPedidos = new List<Pedido>();
            ListaCadetes = new List<Cadete>();
            Nombre = "Cadeteria la prueba";
            Cadete cadete = new(1, "juan", "3876");
            Cadete cadete2 = new(2, "juanito", "381");
            // Cliente cliente = new("raquel", 232323, "calle falsa123", "porton verde");
            // Cliente cliente2 = new("perri", 232323, "santarosa", "porton negro");

            ListaCadetes.Add(cadete);
            ListaCadetes.Add(cadete2);
            // Pedido pedido1 = new("2 hamburguesas", cliente);
            // Pedido pedido2 = new("2 sandwich", cliente2);
            // ListaPedidos.Add(pedido1);
            // ListaPedidos.Add(pedido2);

        }




        public Cliente CrearCliente(string nombre, int telefono, string domicilio, string datosRef)
        {
            Cliente cliente = new(nombre, telefono, domicilio, datosRef);
            return cliente;
        }
        public Pedido CrearPedido(string obs, string nombre, int telefono, string direccion, string datosRef)
        {
            var cliente = new Cliente(nombre, telefono, direccion, datosRef);
            var pedido = new Pedido(obs, cliente);
            return pedido;
        }
        public Pedido AsignarPedido(int idCadete, int idPedido)
        {//ponerle al pedido el id del cadete, nada mas
            Pedido pedidoV = new();
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Id == idPedido)
                {
                    pedido.IdCadete = idCadete;
                    return pedido;
                }
            }
            return pedidoV;
        }

        public Pedido CambiarEstado(int idPedido, Estados estado)
        {
            Pedido pedidoB = ListaPedidos.FirstOrDefault(p => p.Id == idPedido);
            pedidoB.Estado = estado;
            return pedidoB;
        }
        public Pedido ReasignarPedido(int idPedido, int idCadeteNuevo)
        {

            var pedido = AsignarPedido(idCadeteNuevo, idPedido);
            return pedido;

        }

        public void CargarCadete(int id, string telefono, string nombre)
        {
            Cadete cadete = new(id, nombre, telefono);
            ListaCadetes.Add(cadete);
        }
        public Pedido AñadirPedido(Pedido pedido)
        {
            pedido.Id = ListaPedidos.Count() + 1;
            pedido.IdCadete = -1;
            pedido.Estado = Estados.EnCurso;
            ListaPedidos.Add(pedido);


            return pedido;

        }

        public Cadete BuscarCadete(int idC)
        {
            var cadete = ListaCadetes.FirstOrDefault(c=> c.Id == idC);
            return cadete;

        }
        
        public float JornalACobrar(int idCadete)
        {
            float jornal = 500;
            int entregaRealizada = 0;
            entregaRealizada = ListaPedidos.Count(p=>p.Estado==Estados.Entregado && p.IdCadete==idCadete);
            return jornal * entregaRealizada;
        }


        public string GenerarInforme(int idC)
        {
            string informe = $"IdCadete:{idC}\nPedidos:0\nJornal:0\n";

            var pedidos = ListaPedidos.Where(x => x.Estado == Estados.Entregado && x.IdCadete == idC).ToList(); //en la lista de pedidos busca aquellos que esten realizadosy ademas coincida cn el id del cadete.

            if (pedidos.Count() > 0)
            {

                informe = $"ID:{pedidos[0].IdCadete}\nPedidos:{pedidos.Count()}\nJornal:{JornalACobrar(idC)}\n";

            }


            return informe;
        }
    }

}
