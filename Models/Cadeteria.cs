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

        public Cadeteria()
        {
            ListaPedidos = new();
            ListaCadetes = new();
        }

        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
            ListaCadetes = new();
            ListaPedidos = new();
        }
        public Cliente CrearCliente(string nombre, string telefono, string domicilio, string datosRef)
        {
            Cliente cliente = new(nombre, telefono, domicilio, datosRef);
            return cliente;
        }
        public Pedido CrearPedido(int id, string obs, string nombre, string telefono, string direccion, string datosRef)
        {
            var cliente = new Cliente(nombre, telefono, direccion, datosRef);
            var pedido = new Pedido(id, obs, cliente);
            return pedido;
        }
        public string AsignarPedido(int idCadete, int idPedido)
        {//ponerle al pedido el id del cadete, nada mas
            string respuesta = "Algo fallo el pedido no fue asignado";
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Id == idPedido)
                {
                    pedido.IdCadete = idCadete;
                    respuesta = "Pedido Asignado";
                }
            }
            return respuesta;
        }

        public string CambiarEstado(int idPedido, Estados estado)
        {
            string res = "pedido o cadete no encontrado";
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Id == idPedido)
                {
                    pedido.Estado = estado;
                    res = $"El estado del pedido {idPedido} ha sido modificado";
                    break;
                }
            }
            return res;
        }
        public string ReasignarPedido(int idPedido, int idCadeteNuevo)
        {

            string respuesta = AsignarPedido(idCadeteNuevo, idPedido);
            return respuesta;

        }

        public void CargarCadete(int id, string telefono, string nombre)
        {
            Cadete cadete = new(id, nombre, telefono);
            ListaCadetes.Add(cadete);
        }
        public string AñadirPedido(int id, string obs, string nombre, string telefono, string direccion, string datosRef)
        {
            Pedido pedido = CrearPedido(id, obs, nombre, telefono, direccion, datosRef);
            string res = "Añadido con exito";
            if (pedido != null)
            {
                ListaPedidos.Add(pedido);
            }
            else
            {
                res = "No pudo ser añadido el pedido";
            }
            return res;

        }

        public List<Cadete> BuscarCadete(int idCadete)
        {
            var cadetes = ListaCadetes.Where(x => x.Id == idCadete).ToList();
            return cadetes;

        }

        public float JornalACobrar(int idCadete)
        {
            float jornal = 500;
            int entregaRealizada = 0;
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Estado == Estados.Entregado && pedido.IdCadete == idCadete)
                {
                    entregaRealizada++;
                }
            }

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
