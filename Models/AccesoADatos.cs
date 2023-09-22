using System.Text.Json;
namespace Web_Api
{
    public abstract class AccesoADatos
    {
        public abstract Cadeteria AccederCadeteria(string path, Cadeteria cadeteria);

    }

    class AccesoJson : AccesoADatos
    {
        public override Cadeteria AccederCadeteria(string path, Cadeteria cadeteria)
        {
            string texto;
            using (var archivo = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(archivo))
                {
                    texto = sr.ReadToEnd();

                    //  archivo.Close();
                }
                cadeteria = JsonSerializer.Deserialize<Cadeteria>(texto);

            }
            return cadeteria;

        }

    }

    class AccesoCSV : AccesoADatos
    {
        public override Cadeteria AccederCadeteria(string path, Cadeteria cadeteria)
        {
            string linea, delimitador = ",";
            using (var archivo = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(archivo))
                {
                    linea = sr.ReadLine(); //primera linea
                    linea = sr.ReadLine();
                    if (linea != null)
                    {
                        // a esta linea la separo 
                        string[] cadena = linea.Split(delimitador);
                        cadeteria.Nombre = cadena[0];
                        cadeteria.Telefono = cadena[1];
                        AccederCadetes(cadena[2], cadeteria);

                    }
                    sr.Close();
                    archivo.Close();


                }

            }
            return cadeteria;
        }
        private void AccederCadetes(string path, Cadeteria cadeteria)
        {
            string linea, delimitador = ",";
            string[] cadena;
            using (var archivo = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(archivo))
                {
                    sr.ReadLine();
                    linea = sr.ReadLine();
                    while (linea != null)
                    {
                        cadena = linea.Split(delimitador);
                        cadeteria.CargarCadete(Convert.ToInt32(cadena[0]), cadena[1], cadena[2]);
                        linea = sr.ReadLine();
                    }
                }
            }
        }
    }

}