using System.Text.Json;
namespace Web_Api
{

  public  class AccesoADatosCadetes
    {
        public static List<Cadete> Obtener(string path)
        {
            string texto;
            var lista = new List<Cadete>();

            using (var archivo = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(archivo))
                {
                    texto = sr.ReadToEnd();
                }
                lista = JsonSerializer.Deserialize<List<Cadete>>(texto);
            }
            return lista;
        }

        public void GuardarCadetes(List<Cadete>lista){
            string path = "Cadetes.json";
            string texto = JsonSerializer.Serialize(lista);
            if(File.Exists(path)){
                File.WriteAllText(path,texto);
            }
        }
    }
}