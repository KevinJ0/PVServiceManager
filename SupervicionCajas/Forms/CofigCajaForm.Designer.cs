namespace SupervicionCajas
{
    partial class ConfigCajaForm
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
            button1 = new Button();
            NoCajaBox = new TextBox();
            ServerConnectionBox = new TextBox();
            DelayTimeNumeric = new NumericUpDown();
            ClientConnectionBox = new TextBox();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            IpBox = new TextBox();
            panelBottom = new Panel();
            ((System.ComponentModel.ISupportInitialize)DelayTimeNumeric).BeginInit();
            panel1.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(676, 8);
            button1.Name = "button1";
            button1.Size = new Size(111, 34);
            button1.TabIndex = 1;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NoCajaBox
            // 
            NoCajaBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NoCajaBox.Location = new Point(163, 43);
            NoCajaBox.MinimumSize = new Size(200, 0);
            NoCajaBox.Name = "NoCajaBox";
            NoCajaBox.Size = new Size(209, 27);
            NoCajaBox.TabIndex = 4;
            // 
            // ServerConnectionBox
            // 
            ServerConnectionBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ServerConnectionBox.Location = new Point(163, 75);
            ServerConnectionBox.MinimumSize = new Size(500, 0);
            ServerConnectionBox.Name = "ServerConnectionBox";
            ServerConnectionBox.Size = new Size(623, 27);
            ServerConnectionBox.TabIndex = 5;
            // 
            // DelayTimeNumeric
            // 
            DelayTimeNumeric.Location = new Point(163, 139);
            DelayTimeNumeric.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            DelayTimeNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DelayTimeNumeric.MinimumSize = new Size(60, 0);
            DelayTimeNumeric.Name = "DelayTimeNumeric";
            DelayTimeNumeric.Size = new Size(80, 27);
            DelayTimeNumeric.TabIndex = 6;
            DelayTimeNumeric.TextAlign = HorizontalAlignment.Center;
            DelayTimeNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ClientConnectionBox
            // 
            ClientConnectionBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ClientConnectionBox.Location = new Point(163, 107);
            ClientConnectionBox.MinimumSize = new Size(500, 0);
            ClientConnectionBox.Name = "ClientConnectionBox";
            ClientConnectionBox.Size = new Size(623, 27);
            ClientConnectionBox.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(IpBox);
            panel1.Controls.Add(NoCajaBox);
            panel1.Controls.Add(ClientConnectionBox);
            panel1.Controls.Add(ServerConnectionBox);
            panel1.Controls.Add(DelayTimeNumeric);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 204);
            panel1.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(133, 14);
            label6.Name = "label6";
            label6.Size = new Size(24, 20);
            label6.TabIndex = 13;
            label6.Text = "IP:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 78);
            label5.Name = "label5";
            label5.Size = new Size(147, 20);
            label5.TabIndex = 12;
            label5.Text = "Conexión al servidor:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 142);
            label4.Name = "label4";
            label4.Size = new Size(151, 20);
            label4.TabIndex = 11;
            label4.Text = "Tiempo de ejecución:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 110);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 10;
            label3.Text = "Conexión de la caja:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 46);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 9;
            label2.Text = "No. Caja:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // IpBox
            // 
            IpBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            IpBox.Location = new Point(163, 11);
            IpBox.MinimumSize = new Size(200, 0);
            IpBox.Name = "IpBox";
            IpBox.ReadOnly = true;
            IpBox.Size = new Size(209, 27);
            IpBox.TabIndex = 8;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(button1);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.ForeColor = SystemColors.ActiveCaptionText;
            panelBottom.Location = new Point(0, 198);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(798, 55);
            panelBottom.TabIndex = 9;
            // 
            // ConfigCajaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 253);
            Controls.Add(panelBottom);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "ConfigCajaForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configuración de caja";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)DelayTimeNumeric).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private TextBox NoCajaBox;
        private TextBox ServerConnectionBox;
        private NumericUpDown DelayTimeNumeric;
        private TextBox ClientConnectionBox;
        private Panel panel1;
        private TextBox IpBox;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panelBottom;
    }
}