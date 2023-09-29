using System.Text.Json;
namespace Web_Api{


   public class AccesoADatosPedidos
    {
        public static List<Pedido>Obtener(string path){
            string texto;
            var lista = new List<Pedido>();

            using (var archivo = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(archivo))
                {
                    texto = sr.ReadToEnd();
                }
                lista = JsonSerializer.Deserialize<List<Pedido>>(texto);
            }
            return lista;
        }

        public void GuardarPedidos(List<Pedido>lista){ 
            //recibo lista, serializar y escribir en el JSON;
            string path = "Pedidos.json";
            string texto = JsonSerializer.Serialize(lista);
            if(File.Exists(path)){
                File.WriteAllText(path,texto);
            }
        }
    }
}