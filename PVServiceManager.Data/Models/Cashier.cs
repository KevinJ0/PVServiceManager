using Newtonsoft.Json;


namespace PVServiceManager.Data.Models;

[Serializable]
public class Cashier
{
    [JsonProperty("nombre")]
    public string Nombre { get; set; }

    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("ruta")]
    public string Ruta { get; set; }

    [JsonProperty("idExterno")]
    public String? IdExterno { get; set; }
}