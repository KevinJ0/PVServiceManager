using PVServiceManager.Data.Models;
using SupervicionCajas._helpers;

namespace SupervicionCajas.Services
{
    public class CompaniaServices
    {
       
        public static async Task<List<Compania>> ObtenerDatosApiAsync(string urlApi)
        {
            String url = $"{urlApi}/Compania/4";
            string res = await Util.GetHttp(url);

            List<Compania> companiasLst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Compania>>(res);
            return companiasLst;


        }
    }
}
