using System.Text.Json;
namespace Web_Api
{

   public class AccesoADatosCadeteria
    {
        public static Cadeteria Obtener(string path)
        {
            Cadeteria cadeteria;
            string texto;
            using (var archivo = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(archivo))
                {
                    texto = sr.ReadToEnd();

                     archivo.Close();
                }
                cadeteria = JsonSerializer.Deserialize<Cadeteria>(texto);

            }
            return cadeteria;
        }
    }
  

}