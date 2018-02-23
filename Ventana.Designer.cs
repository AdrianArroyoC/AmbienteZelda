namespace AmbienteZelda
{
    partial class Ventana
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana));
            this.PanelAmbiente = new System.Windows.Forms.Panel();
            this.datos = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BotonCrearCuadricula = new System.Windows.Forms.Button();
            this.CajaAltura = new System.Windows.Forms.TextBox();
            this.CajaBase = new System.Windows.Forms.TextBox();
            this.botones = new System.Windows.Forms.GroupBox();
            this.BotonCasa = new System.Windows.Forms.Button();
            this.BotonAvatar = new System.Windows.Forms.Button();
            this.BotonObstaculo = new System.Windows.Forms.Button();
            this.datos.SuspendLayout();
            this.botones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelAmbiente
            // 
            this.PanelAmbiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelAmbiente.BackgroundImage")));
            this.PanelAmbiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelAmbiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelAmbiente.Location = new System.Drawing.Point(12, 12);
            this.PanelAmbiente.Name = "PanelAmbiente";
            this.PanelAmbiente.Size = new System.Drawing.Size(500, 500);
            this.PanelAmbiente.TabIndex = 0;
            // 
            // datos
            // 
            this.datos.Controls.Add(this.label4);
            this.datos.Controls.Add(this.label3);
            this.datos.Controls.Add(this.label2);
            this.datos.Controls.Add(this.label1);
            this.datos.Controls.Add(this.BotonCrearCuadricula);
            this.datos.Controls.Add(this.CajaAltura);
            this.datos.Controls.Add(this.CajaBase);
            this.datos.Location = new System.Drawing.Point(521, 6);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(254, 102);
            this.datos.TabIndex = 1;
            this.datos.TabStop = false;
            this.datos.Text = "Datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Altura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Medidas";
            // 
            // BotonCrearCuadricula
            // 
            this.BotonCrearCuadricula.Location = new System.Drawing.Point(74, 62);
            this.BotonCrearCuadricula.Name = "BotonCrearCuadricula";
            this.BotonCrearCuadricula.Size = new System.Drawing.Size(149, 23);
            this.BotonCrearCuadricula.TabIndex = 2;
            this.BotonCrearCuadricula.Text = "Aceptar";
            this.BotonCrearCuadricula.UseVisualStyleBackColor = true;
            this.BotonCrearCuadricula.Click += new System.EventHandler(this.BotonCrearCuadricula_Click);
            // 
            // CajaAltura
            // 
            this.CajaAltura.Location = new System.Drawing.Point(167, 32);
            this.CajaAltura.Name = "CajaAltura";
            this.CajaAltura.Size = new System.Drawing.Size(56, 20);
            this.CajaAltura.TabIndex = 1;
            this.CajaAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaAncho_KeyPress);
            // 
            // CajaBase
            // 
            this.CajaBase.Location = new System.Drawing.Point(74, 32);
            this.CajaBase.Name = "CajaBase";
            this.CajaBase.Size = new System.Drawing.Size(56, 20);
            this.CajaBase.TabIndex = 0;
            this.CajaBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaLargo_KeyPress);
            // 
            // botones
            // 
            this.botones.Controls.Add(this.BotonCasa);
            this.botones.Controls.Add(this.BotonAvatar);
            this.botones.Controls.Add(this.BotonObstaculo);
            this.botones.Location = new System.Drawing.Point(521, 114);
            this.botones.Name = "botones";
            this.botones.Size = new System.Drawing.Size(254, 100);
            this.botones.TabIndex = 2;
            this.botones.TabStop = false;
            this.botones.Text = "Botones";
            // 
            // BotonCasa
            // 
            this.BotonCasa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonCasa.BackgroundImage")));
            this.BotonCasa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotonCasa.Enabled = false;
            this.BotonCasa.Location = new System.Drawing.Point(179, 22);
            this.BotonCasa.Name = "BotonCasa";
            this.BotonCasa.Size = new System.Drawing.Size(60, 60);
            this.BotonCasa.TabIndex = 5;
            this.BotonCasa.UseVisualStyleBackColor = true;
            this.BotonCasa.Click += new System.EventHandler(this.BotonCasa_Click);
            // 
            // BotonAvatar
            // 
            this.BotonAvatar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonAvatar.BackgroundImage")));
            this.BotonAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotonAvatar.Enabled = false;
            this.BotonAvatar.Location = new System.Drawing.Point(97, 23);
            this.BotonAvatar.Name = "BotonAvatar";
            this.BotonAvatar.Size = new System.Drawing.Size(60, 60);
            this.BotonAvatar.TabIndex = 4;
            this.BotonAvatar.UseVisualStyleBackColor = true;
            this.BotonAvatar.Click += new System.EventHandler(this.BotonAvatar_Click);
            // 
            // BotonObstaculo
            // 
            this.BotonObstaculo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonObstaculo.BackgroundImage")));
            this.BotonObstaculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotonObstaculo.Enabled = false;
            this.BotonObstaculo.Location = new System.Drawing.Point(15, 22);
            this.BotonObstaculo.Name = "BotonObstaculo";
            this.BotonObstaculo.Size = new System.Drawing.Size(60, 60);
            this.BotonObstaculo.TabIndex = 3;
            this.BotonObstaculo.UseVisualStyleBackColor = true;
            this.BotonObstaculo.Click += new System.EventHandler(this.BotonObstaculo_Click);
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 526);
            this.Controls.Add(this.botones);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.PanelAmbiente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ventana";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prueba 1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_KeyDown);
            this.datos.ResumeLayout(false);
            this.datos.PerformLayout();
            this.botones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelAmbiente;
        private System.Windows.Forms.GroupBox datos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BotonCrearCuadricula;
        private System.Windows.Forms.TextBox CajaAltura;
        private System.Windows.Forms.TextBox CajaBase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox botones;
        private System.Windows.Forms.Button BotonCasa;
        private System.Windows.Forms.Button BotonAvatar;
        private System.Windows.Forms.Button BotonObstaculo;
    }
}

