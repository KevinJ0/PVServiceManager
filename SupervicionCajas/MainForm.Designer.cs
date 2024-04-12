namespace SupervicionCajas
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label2 = new Label();
            txtRuta = new TextBox();
            label1 = new Label();
            txtIp = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            panelBottom = new Panel();
            label4 = new Label();
            txtEstadoServicio = new TextBox();
            panelMiddle = new Panel();
            tabControl1 = new TabControl();
            BSSignalRStatus = new BindingSource(components);
            panelTop = new Panel();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            RefreshCajasServiceBtn = new Button();
            textBox1 = new TextBox();
            panelBottom.SuspendLayout();
            panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BSSignalRStatus).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 88);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 16;
            label2.Text = "Ruta:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRuta
            // 
            txtRuta.BackColor = Color.White;
            txtRuta.Location = new Point(133, 85);
            txtRuta.Name = "txtRuta";
            txtRuta.ReadOnly = true;
            txtRuta.Size = new Size(467, 27);
            txtRuta.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 55);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 14;
            label1.Text = "IP:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtIp
            // 
            txtIp.BackColor = Color.White;
            txtIp.Location = new Point(133, 52);
            txtIp.Name = "txtIp";
            txtIp.ReadOnly = true;
            txtIp.Size = new Size(278, 27);
            txtIp.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 22);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 12;
            label3.Text = "Nombre:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.Location = new Point(133, 19);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(278, 27);
            txtNombre.TabIndex = 11;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(label4);
            panelBottom.Controls.Add(txtEstadoServicio);
            panelBottom.Controls.Add(label3);
            panelBottom.Controls.Add(label2);
            panelBottom.Controls.Add(txtNombre);
            panelBottom.Controls.Add(txtRuta);
            panelBottom.Controls.Add(txtIp);
            panelBottom.Controls.Add(label1);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 429);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1203, 169);
            panelBottom.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 121);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 18;
            label4.Text = "Servicio de caja:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtEstadoServicio
            // 
            txtEstadoServicio.BackColor = Color.White;
            txtEstadoServicio.Location = new Point(133, 118);
            txtEstadoServicio.Name = "txtEstadoServicio";
            txtEstadoServicio.ReadOnly = true;
            txtEstadoServicio.Size = new Size(136, 27);
            txtEstadoServicio.TabIndex = 17;
            // 
            // panelMiddle
            // 
            panelMiddle.Controls.Add(tabControl1);
            panelMiddle.Dock = DockStyle.Fill;
            panelMiddle.Location = new Point(0, 0);
            panelMiddle.Name = "panelMiddle";
            panelMiddle.Size = new Size(1203, 429);
            panelMiddle.TabIndex = 19;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Location = new Point(0, 49);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1203, 380);
            tabControl1.TabIndex = 1;
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.Control;
            panelTop.Controls.Add(label5);
            panelTop.Controls.Add(button1);
            panelTop.Controls.Add(button2);
            panelTop.Controls.Add(RefreshCajasServiceBtn);
            panelTop.Controls.Add(textBox1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1203, 43);
            panelTop.TabIndex = 20;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(671, 10);
            label5.Name = "label5";
            label5.Size = new Size(147, 20);
            label5.TabIndex = 9;
            label5.Text = "Conexión al servidor:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Image = Properties.Resources.add__1_;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(11, 6);
            button1.Name = "button1";
            button1.Size = new Size(94, 30);
            button1.TabIndex = 6;
            button1.Text = "Agregar";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Image = Properties.Resources.delete;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(106, 6);
            button2.Name = "button2";
            button2.Size = new Size(99, 30);
            button2.TabIndex = 7;
            button2.Text = "Remover";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.TextImageRelation = TextImageRelation.TextBeforeImage;
            button2.UseVisualStyleBackColor = true;
            // 
            // RefreshCajasServiceBtn
            // 
            RefreshCajasServiceBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RefreshCajasServiceBtn.AutoSize = true;
            RefreshCajasServiceBtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RefreshCajasServiceBtn.Image = Properties.Resources.arrow__1_;
            RefreshCajasServiceBtn.ImageAlign = ContentAlignment.MiddleLeft;
            RefreshCajasServiceBtn.Location = new Point(1011, 6);
            RefreshCajasServiceBtn.Margin = new Padding(10, 3, 3, 3);
            RefreshCajasServiceBtn.Name = "RefreshCajasServiceBtn";
            RefreshCajasServiceBtn.Size = new Size(180, 30);
            RefreshCajasServiceBtn.TabIndex = 10;
            RefreshCajasServiceBtn.Text = "Actualiza conexión";
            RefreshCajasServiceBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            RefreshCajasServiceBtn.UseVisualStyleBackColor = true;
            RefreshCajasServiceBtn.Click += RefreshCajasServiceBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(823, 10);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(177, 20);
            textBox1.TabIndex = 8;
            textBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1203, 598);
            Controls.Add(panelTop);
            Controls.Add(panelMiddle);
            Controls.Add(panelBottom);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(600, 400);
            Name = "MainForm";
            Text = "Administrador de cajas";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BSSignalRStatus).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private TextBox txtRuta;
        private Label label1;
        private TextBox txtIp;
        private Label label3;
        private TextBox txtNombre;
        private Panel panelBottom;
        private Panel panelMiddle;
        private TabControl tabControl1;
        private Label label4;
        private TextBox txtEstadoServicio;
        public BindingSource BSSignalRStatus;
        private Panel panelTop;
        private Label label5;
        private Button button1;
        private Button button2;
        private Button RefreshCajasServiceBtn;
        private TextBox textBox1;
    }
}