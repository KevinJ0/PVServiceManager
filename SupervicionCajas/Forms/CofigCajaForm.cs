using Microsoft.AspNetCore.SignalR.Client;
using PVServiceManager.Data.Models;
using SupervicionCajas._helpers.Enums;
using SupervicionCajas.Services;
using SignalRService.Data.Models;

namespace SupervicionCajas
{
    public partial class ConfigCajaForm : Form
    {
        readonly Properties.Config config = new Properties.Config();
        private Dictionary<string, ConfigurationCaja> cajaDictionary = new Dictionary<string, ConfigurationCaja>();
        private HubConnection _hubConnection;
        ConfigurationCaja _configData;
        private readonly MainForm _mainForm;
        public ConfigCajaForm(ConfigurationCaja configData, HubConnection hubConnection, MainForm mainForm)
        {
            _hubConnection = hubConnection;
            _configData = configData;
            InitializeComponent();
            _mainForm = mainForm;


        }


        private async void MainForm_Load(object sender, EventArgs e)
        {


            IpBox.Text = _configData.ip;
            ClientConnectionBox.Text = _configData.ConnectionStrings.ClientConnection;
            ServerConnectionBox.Text = _configData.ConnectionStrings.ServerConnection;
            DelayTimeNumeric.Value = int.Parse(_configData.DelayTime);
            NoCajaBox.Text = _configData.NoCaja;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(IpBox.Text))
            {
                MessageBox.Show("Debe digitar la IP de la caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(NoCajaBox.Text))
            {
                MessageBox.Show("Debe digitar la el número de caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(ServerConnectionBox.Text))
            {
                MessageBox.Show("Debe digitar la conexión al servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(ClientConnectionBox.Text))
            {
                MessageBox.Show("Debe digitar la conexión de la caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(DelayTimeNumeric.Value.ToString()))
            {
                MessageBox.Show("Debe digitar el tiempo de ejecución.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var configCaja = new ConfigurationCaja()
            {
                ip = IpBox.Text.Trim(),
                ConnectionStrings = new ConnectionStrings()
                {
                    ClientConnection = ClientConnectionBox.Text.Trim(),
                    ServerConnection = ServerConnectionBox.Text.Trim(),
                },
                DelayTime = DelayTimeNumeric.Value.ToString(),
                NoCaja = NoCajaBox.Text.Trim(),
            };

            if (_hubConnection.State == HubConnectionState.Connected)
            {
                try
                {
                    _mainForm.MostrarCarga(true);
                    Task.Run(() =>
                    {
                        _hubConnection.InvokeAsync("SendConfigurationToCaja", configCaja);
                    });

                }
                catch (Exception ex)
                {
                    _mainForm.MostrarCarga(false);
                    MessageBox.Show("Error al intentar enviar los datos al servidor. Error: "+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                Close();
            }
            else
            {
                MessageBox.Show("Error al intentar conectar con el servidor. El servicio parece estar sin conexión actualmente, comprueba la conexión a dicho servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
