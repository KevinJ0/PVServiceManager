using Microsoft.AspNetCore.SignalR;
using SignalRService.Data.Models;
using System.Collections.Concurrent;

namespace SignalRService.Hubs
{
    public class MainHub : Hub
    {
        public static ConcurrentDictionary<string, ConfigurationCaja> cajaDictionary = new ConcurrentDictionary<string, ConfigurationCaja>();

        public async Task SendConfigurationToCaja(ConfigurationCaja configCaja)
        {
            string cajaId = "";

            if (cajaDictionary.ContainsKey(configCaja.ip))
                cajaId = cajaDictionary[configCaja.ip].ConnectionId;
            else
                await Clients.Caller.SendAsync("HandleError", "Esta IP no se encuentra registrada.");

            await Clients.Client(cajaId).SendAsync("ReceiveConfiguration", configCaja);
        }

        public async Task AddOrUpdate(ConfigurationCaja configCaja)
        {

            configCaja.ConnectionId = Context.ConnectionId;

            cajaDictionary.AddOrUpdate(
               configCaja.ip,
               configCaja,
               (key, existingValue) => configCaja
           );

            await Clients.All.SendAsync("ChangeOrAddCajaConfig", configCaja);

        }
        

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;


            foreach (var caja in cajaDictionary.Values)
            {
                if (caja.ConnectionId == connectionId)
                {
                    cajaDictionary.TryRemove(caja.ip, out _);
                    await Clients.All.SendAsync("DisconnectedCaja", caja.ip);
                }
            }



            await base.OnDisconnectedAsync(exception);
        }
        public string GetConnectionId() => Context.ConnectionId;

        public Dictionary<string, ConfigurationCaja> GetAllCajas()
        {
            return cajaDictionary.ToDictionary(x => x.Key, x => x.Value); ;
        }
    }
}