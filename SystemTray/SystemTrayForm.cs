using System.Drawing;
using System.Security.Principal;
using System.ServiceProcess;
using System.Windows.Forms;
using SystemTray.helpers;

namespace SystemTray
{
    public partial class SystemTrayForm : Form
    {

        private ServiceController serviceController;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;

        public SystemTrayForm()
        {
            InitializeComponent();
            SetVisibleCore(false);
            serviceController = new ServiceController("PVService");
            // Inicializa el NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.captcha;
            notifyIcon.Visible = true;

            // Crea el menú contextual
            contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem iniciarMenuItem = new ToolStripMenuItem("Iniciar");
            iniciarMenuItem.Click += btnIniciar_Click;
            contextMenuStrip.Items.Add(iniciarMenuItem);

            ToolStripMenuItem reiniciarMenuItem = new ToolStripMenuItem("Reiniciar");
            reiniciarMenuItem.Click += btnReiniciar_Click;
            contextMenuStrip.Items.Add(reiniciarMenuItem);

            ToolStripMenuItem detenerMenuItem = new ToolStripMenuItem("Detener");
            detenerMenuItem.Click += btnDetener_Click;
            contextMenuStrip.Items.Add(detenerMenuItem);


            ToolStripMenuItem salirMenuItem = new ToolStripMenuItem("Salir");
            salirMenuItem.Click += btnSalir_Click;
            contextMenuStrip.Items.Add(salirMenuItem);

            notifyIcon.ContextMenuStrip = contextMenuStrip;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {

                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    MessageBox.Show("El servicio está corriendo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (serviceController.Status == ServiceControllerStatus.StartPending)
                {
                    MessageBox.Show("El servicio se está iniciando, espere un momento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Inicia el servicio
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
                MessageBox.Show("El servicio se ha iniciado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar el servicio: " + ex.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceController.Status == ServiceControllerStatus.Stopped)
                {
                    MessageBox.Show("El servicio ya está detenido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (serviceController.Status == ServiceControllerStatus.StopPending)
                {
                    MessageBox.Show("El servicio se está deteniendo, por favor espere.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Detiene el servicio
                serviceController.Stop();
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                MessageBox.Show("El servicio se ha detenido correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar detener el servicio: " + ex.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            try
            {
                // Detiene el servicio si está en ejecución
                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                }

                // Inicia el servicio
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);

                MessageBox.Show("El servicio se reinició correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reiniciar el servicio: " + ex.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static bool IsServiceInstalled(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController service in services)
            {
                if (service.ServiceName.Equals(serviceName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private void SystemTrayForm_Load(object sender, EventArgs e)
        {

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!isAdmin)
            {
                MessageBox.Show("Esta aplicación necesita ser ejecutada con permiso de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
           

            string serviceName = "PVService";
            bool isInstalled = IsServiceInstalled(serviceName);
            if (!isInstalled)
            {
                MessageBox.Show("El servicio PVService no se encuentra instalado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   Environment.Exit(1);
            }
           
        }
    }
}

