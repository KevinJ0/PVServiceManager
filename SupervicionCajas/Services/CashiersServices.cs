using PVServiceManager.Data.Models;
using SupervicionCajas._helpers;

namespace SupervicionCajas.Services
{
    public class CashiersServices
    {
        public static async Task<List<Cashier>> ObtenerDatosApiAsync(string urlApi, String sucursal)
        {
            String url = $"{urlApi}/POS/{sucursal}";
            string res = await Util.GetHttp(url);

            List<Cashier> cajasLst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cashier>>(res);
            return cajasLst;


        }
    }
}
