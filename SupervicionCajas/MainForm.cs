using SupervicionCajas.Services;
using SupervicionCajas._helpers;
using PVServiceManager.Data.Models;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRService.Data.Models;
using ConcurrentCollections;
using System.ComponentModel;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms;

namespace SupervicionCajas
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeHub();
            InitializeNotifyIcon();

        }
        private void InitializeHub()
        {

            hubConnection = new HubConnectionBuilder()
             .WithUrl(config.SignalRUrl)
             .WithAutomaticReconnect(new SignalRRetryPolicy())
             .Build();

            hubConnection.ServerTimeout = TimeSpan.FromDays(15);

        }
        private async Task InitializeSignalRConnection()
        {
            //bool isSucceed = Util.Ping("192.172.1.53").Result;

            //Esto se realiza solo una vez hasta que conecta
            try
            {
                if (hubConnection.State == HubConnectionState.Disconnected)
                    await hubConnection.StartAsync();

                if (hubConnection.State == HubConnectionState.Connected)
                {
                    await ResfreshCajasDictionary();
                }
            }
            catch (Exception)
            {
                Invoke((Action)(() =>
                {
                    textBox1.Text = hubConnection.State.ToString();
                }));
                InitializeSignalRConnection();
            }
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.dashboard;
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseClick;
            void notifyIcon_MouseClick(object sender, EventArgs e)
            {
                Show();
                WindowState = FormWindowState.Normal;
                BringToFront();
            }
            ToolStripMenuItem salirMenuItem = new ToolStripMenuItem("Salir");
            salirMenuItem.Click += btnSalir_Click;
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            contextMenuStrip.Items.Add(salirMenuItem);

            notifyIcon.ContextMenuStrip = contextMenuStrip;
            void btnSalir_Click(object sender, EventArgs e)
            {
                Environment.Exit(0);
            }
        }

        #region VarsDeclared 

        readonly Properties.Config config = new Properties.Config();
        List<Cashier> cajasLst = new List<Cashier>();
        Dictionary<string, FlowLayoutPanel> panelCashierDic = new Dictionary<string, FlowLayoutPanel>();
        Dictionary<string, System.Timers.Timer> timers = new Dictionary<string, System.Timers.Timer>();
        ConcurrentHashSet<string> timersFinished = new ConcurrentHashSet<string>();
        int totalTimers = 0;
        private HubConnection hubConnection;
        private NotifyIcon notifyIcon;
        private bool completedLoad = false, _isLoadingPanelShowed = false;
        public ObservableDictionary<string, ConfigurationCaja> cajaDictionary = new ObservableDictionary<string, ConfigurationCaja>();
        private CenterPanel centerPanel;
        private string _signalRStatus;

        #endregion


        private async void MainForm_Load(object sender, EventArgs e)
        {
            cajaDictionary.DictionaryChanged += DictionaryChangedHandler;
            cajaDictionary.DictionaryCleared += DictionaryClearedHandler;


            hubConnection.On("ChangeOrAddCajaConfig", (Action<ConfigurationCaja>)((configData) => ChangeOrAddCajaConfig(configData)));
            hubConnection.On<string>("DisconnectedCaja", (ipCaja) =>
            {
                if (cajaDictionary.ContainsKey(ipCaja))
                    cajaDictionary.Remove(ipCaja);

            });

            hubConnection.Reconnected += async connectionId => await ResfreshCajasDictionary();
            hubConnection.Closed += async connectionId => cajaDictionary.Clear();
            hubConnection.Reconnecting += async connectionId => cajaDictionary.Clear();


            await Task.Run(async () =>
            {

                try
                {
                    InitializeSignalRConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al conectar con el servicio de cajas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });

            LoadAllCajas();

        }

        private void ChangeOrAddCajaConfig(ConfigurationCaja configData)
        {
            if (cajaDictionary.ContainsKey(configData.ip))
                cajaDictionary.Remove(configData.ip);

            cajaDictionary.Add(configData.ip, configData);

            MostrarCarga(false);
        }

        private void RefreshCurrentStatusCashier()
        {

            Invoke(new Action(() =>
            {
                if (cajaDictionary.ContainsKey(txtIp.Text))
                    txtEstadoServicio.Text = "Activo";
                else
                    txtEstadoServicio.Text = "Sin respuesta";
            }));

        }


        private async void LoadAllCajas()
        {
            MostrarCarga(true);

            var companiasLst = await CompaniaServices.ObtenerDatosApiAsync(
                                    urlApi: config.ApiURL
                                );

            foreach (var item in companiasLst)
            {
                panelCashierDic.Add(item.Sucursal.ToString(), addTabAndPanelSucursal(item));
            }

            foreach (var item in panelCashierDic)
            {
                var cajaLstByCompania = await CashiersServices.ObtenerDatosApiAsync(
                                                    sucursal: item.Key,
                                                    urlApi: config.ApiURL
                                                );

                cajasLst.AddRange(cajaLstByCompania);

                totalTimers += cajaLstByCompania.Count;

                foreach (var cashier in cajaLstByCompania)
                {
                    addCashierPanel(cashier, item.Value);
                }

            }

        }

        private FlowLayoutPanel addTabAndPanelSucursal(Compania item)
        {
            TabPage newTab = new TabPage(item.Nombre);
            newTab.Name = "tapPage" + item.Sucursal.ToString();
            //----------
            FlowLayoutPanel panelCashier = new();
            panelCashier.Name = "panelCashier" + item.Sucursal.ToString();
            panelCashier.Dock = DockStyle.Fill;
            //----------
            tabControl1.TabPages.Add(newTab);
            newTab.Controls.Add(panelCashier);

            return panelCashier;

        }

        private void addCashierPanel(Cashier cashier, FlowLayoutPanel mainFlowPanel)
        {

            PictureBox pictureBox = new PictureBox();
            FlowLayoutPanel panelButton = new FlowLayoutPanel();
            Label label = new Label();
            label.Text = cashier.Nombre;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = true;
            label.Font = new Font(label.Font.FontFamily, 8, FontStyle.Bold);
            //label.Dock = DockStyle.Fill;
            label.Margin = new Padding(0, 0, 0, 0);
            label.MouseEnter += panel_MouseEnter;
            label.MouseLeave += pictureBox_MouseLeave;
            label.MouseClick += pictureBox_MouseClick;
            label.MouseDoubleClick += pictureBox_MouseDoubleClick;

            label.Cursor = Cursors.Hand;
            label.Anchor = AnchorStyles.None;
            pictureBox.Image = Properties.Resources.cashier_machine;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Cursor = Cursors.Hand;
            //pictureBox.Dock = DockStyle.Fill;

            pictureBox.MouseEnter += panel_MouseEnter;
            pictureBox.MouseLeave += pictureBox_MouseLeave;
            pictureBox.MouseClick += pictureBox_MouseClick;
            pictureBox.MouseDoubleClick += pictureBox_MouseDoubleClick;

            panelButton.AutoSize = true;
            panelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelButton.MinimumSize = new Size(70, 0);
            panelButton.Padding = new Padding(0);
            panelButton.WrapContents = false;
            panelButton.FlowDirection = FlowDirection.TopDown;
            panelButton.Tag = cashier;
            panelButton.MouseEnter += panel_MouseEnter;
            panelButton.MouseLeave += pictureBox_MouseLeave;
            panelButton.MouseClick += pictureBox_MouseClick;
            panelButton.MouseDoubleClick += pictureBox_MouseDoubleClick;
            panelButton.Cursor = Cursors.Hand;

            void pictureBox_MouseLeave(object sender, EventArgs e)
            {
                panelButton.BackColor = Color.Transparent;
            }

            void panel_MouseEnter(object sender, EventArgs e)
            {
                panelButton.BackColor = Color.LightGray;
            }

            void pictureBox_MouseClick(object sender, EventArgs e)
            {
                showData(cashier);
            }

            void pictureBox_MouseDoubleClick(object sender, EventArgs e)
            {

                if (cajaDictionary.ContainsKey(cashier.Ip))
                {
                    ConfigCajaForm form = new ConfigCajaForm(cajaDictionary.GetValueOrDefault(cashier.Ip), hubConnection, this);
                    form.ShowDialog();
                }
                else
                    MessageBox.Show("No se pudo hacer conexión con el servicio de esta caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



            panelButton.Controls.Add(pictureBox);
            panelButton.Controls.Add(label);

            System.Timers.Timer timer = new System.Timers.Timer(500);

            timer.Elapsed += async (sender, e) =>
            {
                await Task.Run(async () =>
                 {
                     timer.Stop();

                     await checkConnection(panelButton);
                     if (timersFinished.Count >= totalTimers && !completedLoad)
                     {
                         completedLoad = true;
                         MostrarCarga(false);

                     }

                     timer.Start();

                 });
            };
            timer.Start();

            timers.Add(cashier.Ip, timer);
            mainFlowPanel.AutoScroll = true;
            mainFlowPanel.Controls.Add(panelButton);

        }

        private void showData(Cashier cashier)
        {
            bool isCashierAlive = cajaDictionary.ContainsKey(cashier.Ip);
            txtEstadoServicio.Text = isCashierAlive ? "Activo" : "Sin respuesta";
            txtNombre.Text = cashier.Nombre;
            txtIp.Text = cashier.Ip;
            txtRuta.Text = cashier.Ruta;
        }


        async Task checkConnection(Panel panel)
        {
            await Task.Run(async () =>
            {
                if (!IsDisposed)
                {
                    Cashier cashier = panel.Tag as Cashier;

                    bool isSucceed = await Util.Ping(cashier.Ip);

                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            foreach (Control control in panel.Controls)
                                if (control is PictureBox pictureBox)
                                    pictureBox.Image = isSucceed ? Properties.Resources.cashier_machine : Properties.Resources.cashier_off;
                        }));
                    }
                    else
                    {
                        foreach (Control control in panel.Controls)
                            if (control is PictureBox pictureBox)
                                pictureBox.Image = isSucceed ? Properties.Resources.cashier_machine : Properties.Resources.cashier_off;
                    }

                    timersFinished.Add(cashier.Ip);
                }
            });
        }



        public void MostrarCarga(bool mostrar)
        {
            _isLoadingPanelShowed = mostrar;
            if (mostrar)
            {
                if (tabControl1.InvokeRequired)
                {
                    tabControl1.Invoke((MethodInvoker)delegate
                    {
                        setEnablePanels(false);
                        AddCenteredPanel();
                    });
                }
                else
                {
                    setEnablePanels(false);
                    AddCenteredPanel();
                }
            }
            else
            {
                RemoveCenteredPanel();

                if (tabControl1.InvokeRequired)
                {
                    tabControl1.Invoke((MethodInvoker)delegate
                    {
                        setEnablePanels(true);
                    });
                }
                else
                {
                    setEnablePanels(true);
                }
            }
        }

        private void setEnablePanels(bool v)
        {

            foreach (Control control in panelTop.Controls)
                control.Enabled = v;

            foreach (Control control in panelMiddle.Controls)
                control.Enabled = v;

            foreach (Control control in panelBottom.Controls)
                control.Enabled = v;

        }

        private void AddCenteredPanel()
        {

            centerPanel = new CenterPanel(ClientSize.Width, ClientSize.Height);
            //se lo agrego al formulario principal
            Controls.Add(centerPanel);
            centerPanel.BringToFront();

        }
        private void RemoveCenteredPanel()
        {
            if (centerPanel != null && !centerPanel.IsDisposed && centerPanel.InvokeRequired)
            {
                centerPanel.Invoke((MethodInvoker)delegate
                {
                    if (!centerPanel.IsDisposed)
                        Controls.Remove(centerPanel);
                });
            }
            else
            {
                if (centerPanel != null)
                    if (!centerPanel.IsDisposed)
                        Controls.Remove(centerPanel);
            }
        }

        private void RefreshCajasServiceBtn_Click(object sender, EventArgs e)
        {
            ConnectSignalR();
        }
        async Task ConnectSignalR()
        {
            MostrarCarga(true);
            //stopTimers();

            try
            {
                if (hubConnection.State == HubConnectionState.Disconnected)
                    await hubConnection.StartAsync();

                while (hubConnection.State == HubConnectionState.Connecting)
                { }

                if (hubConnection.State == HubConnectionState.Connected)
                {
                    MessageBox.Show("Conexión creada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await ResfreshCajasDictionary();

                }
                else
                    MessageBox.Show("Error al intentar conectar con los servicios de las cajas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar conectar con los servicios de las cajas. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //StartTimers();
                MostrarCarga(false);

                Invoke((Action)(() =>
                {

                    textBox1.Text = hubConnection.State.ToString();

                }));
            }
        }



        private async Task ResfreshCajasDictionary()
        {


            try
            {
                var cajas = await hubConnection.InvokeAsync<ObservableDictionary<string, ConfigurationCaja>>("GetAllCajas");
                cajaDictionary.Clear();
                foreach (var kvp in cajas) cajaDictionary.Add(kvp.Key, kvp.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar obtener las configuraciones de las cajas. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Invoke((Action)(() =>
            {
                textBox1.Text = hubConnection.State.ToString();

            }));

        }
        private void DictionaryChangedHandler(object sender, DictionaryChangedEventArgs<string, ConfigurationCaja> e)
        {
            RefreshCurrentStatusCashier();
        }
        private void DictionaryClearedHandler(object sender, EventArgs e)
        {
            RefreshCurrentStatusCashier();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // bool isSucceed =  Util.Ping("192.172.1.53").Result;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
