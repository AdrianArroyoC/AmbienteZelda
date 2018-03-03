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
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.BotonCrearCuadricula = new System.Windows.Forms.Button();
			this.CajaCuadrosX = new System.Windows.Forms.TextBox();
			this.CajaCuadrosY = new System.Windows.Forms.TextBox();
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
			this.PanelAmbiente.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.PanelAmbiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelAmbiente.BackgroundImage")));
			this.PanelAmbiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.PanelAmbiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelAmbiente.Location = new System.Drawing.Point(16, 15);
			this.PanelAmbiente.Margin = new System.Windows.Forms.Padding(4);
			this.PanelAmbiente.Name = "PanelAmbiente";
			this.PanelAmbiente.Size = new System.Drawing.Size(666, 615);
			this.PanelAmbiente.TabIndex = 0;
			this.PanelAmbiente.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAmbiente_Paint);
			this.PanelAmbiente.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PanelAmbiente_PreviewKeyDown);
			// 
			// datos
			// 
			this.datos.Controls.Add(this.label2);
			this.datos.Controls.Add(this.label1);
			this.datos.Controls.Add(this.BotonCrearCuadricula);
			this.datos.Controls.Add(this.CajaCuadrosX);
			this.datos.Controls.Add(this.CajaCuadrosY);
			this.datos.Location = new System.Drawing.Point(695, 7);
			this.datos.Margin = new System.Windows.Forms.Padding(4);
			this.datos.Name = "datos";
			this.datos.Padding = new System.Windows.Forms.Padding(4);
			this.datos.Size = new System.Drawing.Size(339, 126);
			this.datos.TabIndex = 1;
			this.datos.TabStop = false;
			this.datos.Text = "Datos";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(187, 40);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "X";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 38);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Cuadros";
			// 
			// BotonCrearCuadricula
			// 
			this.BotonCrearCuadricula.Location = new System.Drawing.Point(99, 76);
			this.BotonCrearCuadricula.Margin = new System.Windows.Forms.Padding(4);
			this.BotonCrearCuadricula.Name = "BotonCrearCuadricula";
			this.BotonCrearCuadricula.Size = new System.Drawing.Size(199, 28);
			this.BotonCrearCuadricula.TabIndex = 2;
			this.BotonCrearCuadricula.Text = "Empezar";
			this.BotonCrearCuadricula.UseVisualStyleBackColor = true;
			this.BotonCrearCuadricula.Click += new System.EventHandler(this.BotonCrearCuadricula_Click);
			// 
			// CajaCuadrosX
			// 
			this.CajaCuadrosX.Location = new System.Drawing.Point(99, 35);
			this.CajaCuadrosX.Margin = new System.Windows.Forms.Padding(4);
			this.CajaCuadrosX.Name = "CajaCuadrosX";
			this.CajaCuadrosX.Size = new System.Drawing.Size(73, 22);
			this.CajaCuadrosX.TabIndex = 0;
			this.CajaCuadrosX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaCuadrosX_KeyPress);
			// 
			// CajaCuadrosY
			// 
			this.CajaCuadrosY.Location = new System.Drawing.Point(225, 35);
			this.CajaCuadrosY.Margin = new System.Windows.Forms.Padding(4);
			this.CajaCuadrosY.Name = "CajaCuadrosY";
			this.CajaCuadrosY.Size = new System.Drawing.Size(73, 22);
			this.CajaCuadrosY.TabIndex = 1;
			this.CajaCuadrosY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaCuadrosY_KeyPress);
			// 
			// botones
			// 
			this.botones.Controls.Add(this.BotonCasa);
			this.botones.Controls.Add(this.BotonAvatar);
			this.botones.Controls.Add(this.BotonObstaculo);
			this.botones.Location = new System.Drawing.Point(695, 140);
			this.botones.Margin = new System.Windows.Forms.Padding(4);
			this.botones.Name = "botones";
			this.botones.Padding = new System.Windows.Forms.Padding(4);
			this.botones.Size = new System.Drawing.Size(339, 123);
			this.botones.TabIndex = 2;
			this.botones.TabStop = false;
			this.botones.Text = "Botones";
			// 
			// BotonCasa
			// 
			this.BotonCasa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonCasa.BackgroundImage")));
			this.BotonCasa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BotonCasa.Enabled = false;
			this.BotonCasa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BotonCasa.Location = new System.Drawing.Point(240, 30);
			this.BotonCasa.Margin = new System.Windows.Forms.Padding(4);
			this.BotonCasa.Name = "BotonCasa";
			this.BotonCasa.Size = new System.Drawing.Size(80, 74);
			this.BotonCasa.TabIndex = 5;
			this.BotonCasa.UseVisualStyleBackColor = true;
			this.BotonCasa.Click += new System.EventHandler(this.BotonCasa_Click);
			// 
			// BotonAvatar
			// 
			this.BotonAvatar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonAvatar.BackgroundImage")));
			this.BotonAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BotonAvatar.Enabled = false;
			this.BotonAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BotonAvatar.Location = new System.Drawing.Point(130, 31);
			this.BotonAvatar.Margin = new System.Windows.Forms.Padding(4);
			this.BotonAvatar.Name = "BotonAvatar";
			this.BotonAvatar.Size = new System.Drawing.Size(80, 74);
			this.BotonAvatar.TabIndex = 4;
			this.BotonAvatar.UseVisualStyleBackColor = true;
			this.BotonAvatar.Click += new System.EventHandler(this.BotonAvatar_Click);
			// 
			// BotonObstaculo
			// 
			this.BotonObstaculo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonObstaculo.BackgroundImage")));
			this.BotonObstaculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BotonObstaculo.Enabled = false;
			this.BotonObstaculo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BotonObstaculo.Location = new System.Drawing.Point(21, 30);
			this.BotonObstaculo.Margin = new System.Windows.Forms.Padding(4);
			this.BotonObstaculo.Name = "BotonObstaculo";
			this.BotonObstaculo.Size = new System.Drawing.Size(80, 74);
			this.BotonObstaculo.TabIndex = 3;
			this.BotonObstaculo.UseVisualStyleBackColor = true;
			this.BotonObstaculo.Click += new System.EventHandler(this.BotonObstaculo_Click);
			// 
			// Ventana
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1045, 647);
			this.Controls.Add(this.botones);
			this.Controls.Add(this.datos);
			this.Controls.Add(this.PanelAmbiente);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "Ventana";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Prueba 1";
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
        private System.Windows.Forms.TextBox CajaCuadrosX;
        private System.Windows.Forms.TextBox CajaCuadrosY;
        private System.Windows.Forms.GroupBox botones;
        private System.Windows.Forms.Button BotonCasa;
        private System.Windows.Forms.Button BotonAvatar;
        private System.Windows.Forms.Button BotonObstaculo;
    }
}

