using Newtonsoft.Json;
using SupervicionCajas._helpers.Enums;
using SupervicionCajas.Properties;
using System.Net.NetworkInformation;
using System.Text;

namespace SupervicionCajas._helpers
{

    public class Util
    {
        readonly Config config = new Config();

        public static async Task<string> GetHttp(string url)
        {
            string resultado = string.Empty;
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            HttpClient client = new HttpClient(clientHandler)
            {
                Timeout = TimeSpan.FromMinutes(360)
            };

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                resultado = await response.Content.ReadAsStringAsync();
            }

            return resultado;
        }

        public static async Task<HttpResponseMessage> PostHttp(string url, object objeto = null)
        {
            var json = JsonConvert.SerializeObject(objeto);
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            HttpClient client = new HttpClient(clientHandler)
            {
                Timeout = TimeSpan.FromMinutes(360)
            };

            HttpResponseMessage response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            return response.EnsureSuccessStatusCode();
        }

        public static async Task<HttpResponseMessage> DeleteHttp(string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            HttpClient client = new HttpClient(clientHandler)
            {
                Timeout = TimeSpan.FromMinutes(360)
            };

            HttpResponseMessage response = await client.DeleteAsync(url);

            return response.EnsureSuccessStatusCode();
        }

        public static async Task<T> PostHttp<T>(string url, object objeto, CancellationToken cancellationToken = default)
        {
            var json = JsonConvert.SerializeObject(objeto);

            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient client = new HttpClient(clientHandler)
            {
                Timeout = TimeSpan.FromMinutes(360)
            };

            HttpResponseMessage response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"), cancellationToken);


            if (response.IsSuccessStatusCode)
            {

                string _json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(_json);
                return result;

            }
            else
            {
                throw new Exception($"Error sending POST request: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }

        public static async Task<HttpResponseMessage> PutHttp(string url, object objeto = null)
        {
            var json = JsonConvert.SerializeObject(objeto);
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            HttpClient client = new HttpClient(clientHandler)
            {
                Timeout = TimeSpan.FromMinutes(360)
            };

            HttpResponseMessage response = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            return response.EnsureSuccessStatusCode();
        }

        public static async Task<T> PutHttp<T>(string url, object objeto, CancellationToken cancellationToken = default)
        {
            var json = JsonConvert.SerializeObject(objeto);
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            HttpClient client = new HttpClient(clientHandler)
            {
                Timeout = TimeSpan.FromMinutes(360)
            };

            HttpResponseMessage response = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"), cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string _json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(_json);
                return result;
            }
            else
            {
                throw new Exception($"Error sending POST request: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }


        public static List<Sucursal> SucursalesConverter(List<string> sucursales)
        {
            List<Sucursal> list = new List<Sucursal>();
            foreach (string suc in sucursales)
            {
                switch (suc)
                {
                    case "OP":
                        list.Add(Sucursal.OrensePlaza);
                        break;
                    case "HR":
                        list.Add(Sucursal.HiperRomana);
                        break;
                    case "VH":
                        list.Add(Sucursal.OrenseVillaHermosa);
                        break;
                    case "Sincronizado":
                        list.Add(Sucursal.OrensePlaza);
                        list.Add(Sucursal.HiperRomana);
                        list.Add(Sucursal.OrenseVillaHermosa);
                        break;
                    default:
                        break;
                }
            }

            return list;
        }

        /// <summary>
        /// Este método busca y compara si existe otro archivo con el mismo nombre sin importar la extension.
        /// </summary>
        /// <param name="file">ruta y nombre del nuevo archivo que se desea crear</param>
        /// <returns>Devuelve un string con el nombre y ruta del archivo que comparte el mismo nombre en la ruta del archivo pasado por parámetro. 
        /// En caso de no encontrar ningún archivo igual al original en nombre devuelve null.</returns>
        public string GetFileIgnoreExtension(string file)
        {

            string directorio = Path.GetDirectoryName(file);
            string nombreArchivo = Path.GetFileNameWithoutExtension(file);
            string[] archivosEnDirectorio = Directory.GetFiles(directorio);

            // Verificar si existe un archivo con el nombre deseado (sin importar la extensión)
            foreach (string archivo in archivosEnDirectorio)
            {
                string nombreSinExtension = Path.GetFileNameWithoutExtension(archivo);
                if (nombreSinExtension.Equals(nombreArchivo, StringComparison.OrdinalIgnoreCase))
                {
                    return archivo;
                }
            }

            return null;


        }

     
        public static async Task<bool> Ping(String ip)
        {

            try
            {
                using (Ping pingSender = new Ping())
                {
                    PingReply reply = await pingSender.SendPingAsync(ip);

                    if (reply.Status == IPStatus.Success)
                        return true;
                    else
                        return false;
                }
            }
            catch (PingException ex)
            {
                return false;
            }
        }
    }
}
