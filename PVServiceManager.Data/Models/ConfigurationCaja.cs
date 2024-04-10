using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRService.Data.Models
{
    [Serializable]
    public class ConfigurationCaja
    {
        public string NoCaja { get; set; }
        public string DelayTime { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public string ip { get; set; }
        [NotMapped]
        public string ConnectionId { get; set; }
        

    }

    public class ConnectionStrings
    {
        public string ServerConnection { get; set; }
        public string ClientConnection { get; set; }
    }
}
