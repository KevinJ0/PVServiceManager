using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SystemTray.helpers
{
    public class Utils
    {

        static public  Icon BitmapToIcon(Bitmap bitmap)
        {
            try
            {
                // Convertir el Bitmap a un Icono
                Icon icono = Icon.FromHandle(bitmap.GetHicon());
                return icono;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir el Bitmap a Icono: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static string GetIp()
        {
            try
            {
                string ethernetInterfaceName = "Ethernet"; // Nombre de la interfaz de Ethernet

                // Obtener todas las interfaces de red
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                // Filtrar las interfaces de Ethernet
                var ethernetInterfaces = networkInterfaces
                    .Where(ni => ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet && ni.OperationalStatus == OperationalStatus.Up)
                    .ToList();

                if (ethernetInterfaces.Count == 0)
                {
                    throw new Exception("No se encontraron interfaces de Ethernet activas.");
                }
                else
                {
                    // Obtener la primera dirección IP de la primera interfaz de Ethernet
                    var ipAddress = ethernetInterfaces[0].GetIPProperties().UnicastAddresses
                        .FirstOrDefault(ip => ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.Address;

                    if (ipAddress != null)
                    {

                        Console.WriteLine($"Dirección IP de la interfaz de Ethernet: {ipAddress}");
                        return ipAddress.ToString();
                    }
                    else
                    {
                    throw new Exception("No se encontró una dirección IP para la interfaz de Ethernet.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
