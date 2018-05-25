using System;

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
			this.datosCajaAgrupacion = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.BotonCrearCuadricula = new System.Windows.Forms.Button();
			this.CajaTextoCuadrosBase = new System.Windows.Forms.TextBox();
			this.CajaTextoCuadrosAltura = new System.Windows.Forms.TextBox();
			this.modalidadesCajaAgrupacion = new System.Windows.Forms.GroupBox();
			this.BotonCasa = new System.Windows.Forms.Button();
			this.BotonAvatar = new System.Windows.Forms.Button();
			this.BotonObstaculo = new System.Windows.Forms.Button();
			this.BotonLineaRectaReconocimiento = new System.Windows.Forms.Button();
			this.movimientoCajaAgrupacion = new System.Windows.Forms.GroupBox();
			this.BotonMejorRuta = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.CajaTextoVisibles = new System.Windows.Forms.TextBox();
			this.CajaTextoOcultos = new System.Windows.Forms.TextBox();
			this.BotonRandomReconocimiento = new System.Windows.Forms.Button();
			this.BotonLineaRectaSimple = new System.Windows.Forms.Button();
			this.partidaCajaAgrupacion = new System.Windows.Forms.GroupBox();
			this.BotonCargar = new System.Windows.Forms.Button();
			this.BotonGuardar = new System.Windows.Forms.Button();
			this.datosCajaAgrupacion.SuspendLayout();
			this.modalidadesCajaAgrupacion.SuspendLayout();
			this.movimientoCajaAgrupacion.SuspendLayout();
			this.partidaCajaAgrupacion.SuspendLayout();
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
			// datosCajaAgrupacion
			// 
			this.datosCajaAgrupacion.Controls.Add(this.label2);
			this.datosCajaAgrupacion.Controls.Add(this.label1);
			this.datosCajaAgrupacion.Controls.Add(this.BotonCrearCuadricula);
			this.datosCajaAgrupacion.Controls.Add(this.CajaTextoCuadrosBase);
			this.datosCajaAgrupacion.Controls.Add(this.CajaTextoCuadrosAltura);
			this.datosCajaAgrupacion.Location = new System.Drawing.Point(695, 15);
			this.datosCajaAgrupacion.Margin = new System.Windows.Forms.Padding(4);
			this.datosCajaAgrupacion.Name = "datosCajaAgrupacion";
			this.datosCajaAgrupacion.Padding = new System.Windows.Forms.Padding(4);
			this.datosCajaAgrupacion.Size = new System.Drawing.Size(340, 100);
			this.datosCajaAgrupacion.TabIndex = 1;
			this.datosCajaAgrupacion.TabStop = false;
			this.datosCajaAgrupacion.Text = "Datos del Mapa";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(157, 30);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Base  /  Altura";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 30);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Cuadros";
			// 
			// BotonCrearCuadricula
			// 
			this.BotonCrearCuadricula.Location = new System.Drawing.Point(7, 57);
			this.BotonCrearCuadricula.Margin = new System.Windows.Forms.Padding(4);
			this.BotonCrearCuadricula.Name = "BotonCrearCuadricula";
			this.BotonCrearCuadricula.Size = new System.Drawing.Size(325, 28);
			this.BotonCrearCuadricula.TabIndex = 2;
			this.BotonCrearCuadricula.Text = "Generar";
			this.BotonCrearCuadricula.UseVisualStyleBackColor = true;
			this.BotonCrearCuadricula.Click += new System.EventHandler(this.BotonCrearCuadricula_Click);
			// 
			// CajaTextoCuadrosBase
			// 
			this.CajaTextoCuadrosBase.Location = new System.Drawing.Point(80, 27);
			this.CajaTextoCuadrosBase.Margin = new System.Windows.Forms.Padding(4);
			this.CajaTextoCuadrosBase.Name = "CajaTextoCuadrosBase";
			this.CajaTextoCuadrosBase.Size = new System.Drawing.Size(73, 22);
			this.CajaTextoCuadrosBase.TabIndex = 0;
			this.CajaTextoCuadrosBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaCuadrosX_KeyPress);
			// 
			// CajaTextoCuadrosAltura
			// 
			this.CajaTextoCuadrosAltura.Location = new System.Drawing.Point(259, 27);
			this.CajaTextoCuadrosAltura.Margin = new System.Windows.Forms.Padding(4);
			this.CajaTextoCuadrosAltura.Name = "CajaTextoCuadrosAltura";
			this.CajaTextoCuadrosAltura.Size = new System.Drawing.Size(73, 22);
			this.CajaTextoCuadrosAltura.TabIndex = 1;
			this.CajaTextoCuadrosAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaCuadrosY_KeyPress);
			// 
			// modalidadesCajaAgrupacion
			// 
			this.modalidadesCajaAgrupacion.Controls.Add(this.BotonCasa);
			this.modalidadesCajaAgrupacion.Controls.Add(this.BotonAvatar);
			this.modalidadesCajaAgrupacion.Controls.Add(this.BotonObstaculo);
			this.modalidadesCajaAgrupacion.Location = new System.Drawing.Point(695, 125);
			this.modalidadesCajaAgrupacion.Margin = new System.Windows.Forms.Padding(4);
			this.modalidadesCajaAgrupacion.Name = "modalidadesCajaAgrupacion";
			this.modalidadesCajaAgrupacion.Padding = new System.Windows.Forms.Padding(4);
			this.modalidadesCajaAgrupacion.Size = new System.Drawing.Size(340, 125);
			this.modalidadesCajaAgrupacion.TabIndex = 2;
			this.modalidadesCajaAgrupacion.TabStop = false;
			this.modalidadesCajaAgrupacion.Text = "Modalidades";
			// 
			// BotonCasa
			// 
			this.BotonCasa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonCasa.BackgroundImage")));
			this.BotonCasa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BotonCasa.Enabled = false;
			this.BotonCasa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BotonCasa.Location = new System.Drawing.Point(249, 27);
			this.BotonCasa.Margin = new System.Windows.Forms.Padding(4);
			this.BotonCasa.Name = "BotonCasa";
			this.BotonCasa.Size = new System.Drawing.Size(83, 83);
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
			this.BotonAvatar.Location = new System.Drawing.Point(131, 27);
			this.BotonAvatar.Margin = new System.Windows.Forms.Padding(4);
			this.BotonAvatar.Name = "BotonAvatar";
			this.BotonAvatar.Size = new System.Drawing.Size(83, 83);
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
			this.BotonObstaculo.Location = new System.Drawing.Point(10, 27);
			this.BotonObstaculo.Margin = new System.Windows.Forms.Padding(4);
			this.BotonObstaculo.Name = "BotonObstaculo";
			this.BotonObstaculo.Size = new System.Drawing.Size(83, 83);
			this.BotonObstaculo.TabIndex = 3;
			this.BotonObstaculo.UseVisualStyleBackColor = true;
			this.BotonObstaculo.Click += new System.EventHandler(this.BotonObstaculo_Click);
			// 
			// BotonLineaRectaReconocimiento
			// 
			this.BotonLineaRectaReconocimiento.Enabled = false;
			this.BotonLineaRectaReconocimiento.Location = new System.Drawing.Point(7, 68);
			this.BotonLineaRectaReconocimiento.Margin = new System.Windows.Forms.Padding(4);
			this.BotonLineaRectaReconocimiento.Name = "BotonLineaRectaReconocimiento";
			this.BotonLineaRectaReconocimiento.Size = new System.Drawing.Size(325, 28);
			this.BotonLineaRectaReconocimiento.TabIndex = 3;
			this.BotonLineaRectaReconocimiento.Text = "Linea Recta con Reconocimiento";
			this.BotonLineaRectaReconocimiento.UseVisualStyleBackColor = true;
			this.BotonLineaRectaReconocimiento.Click += new System.EventHandler(this.BotonLineaRectaReconocimiento_Click);
			// 
			// movimientoCajaAgrupacion
			// 
			this.movimientoCajaAgrupacion.Controls.Add(this.BotonMejorRuta);
			this.movimientoCajaAgrupacion.Controls.Add(this.label3);
			this.movimientoCajaAgrupacion.Controls.Add(this.label4);
			this.movimientoCajaAgrupacion.Controls.Add(this.CajaTextoVisibles);
			this.movimientoCajaAgrupacion.Controls.Add(this.CajaTextoOcultos);
			this.movimientoCajaAgrupacion.Controls.Add(this.BotonRandomReconocimiento);
			this.movimientoCajaAgrupacion.Controls.Add(this.BotonLineaRectaSimple);
			this.movimientoCajaAgrupacion.Controls.Add(this.BotonLineaRectaReconocimiento);
			this.movimientoCajaAgrupacion.Location = new System.Drawing.Point(695, 260);
			this.movimientoCajaAgrupacion.Name = "movimientoCajaAgrupacion";
			this.movimientoCajaAgrupacion.Size = new System.Drawing.Size(340, 259);
			this.movimientoCajaAgrupacion.TabIndex = 4;
			this.movimientoCajaAgrupacion.TabStop = false;
			this.movimientoCajaAgrupacion.Text = "Movimiento";
			// 
			// BotonMejorRuta
			// 
			this.BotonMejorRuta.Enabled = false;
			this.BotonMejorRuta.Location = new System.Drawing.Point(8, 178);
			this.BotonMejorRuta.Margin = new System.Windows.Forms.Padding(4);
			this.BotonMejorRuta.Name = "BotonMejorRuta";
			this.BotonMejorRuta.Size = new System.Drawing.Size(325, 28);
			this.BotonMejorRuta.TabIndex = 11;
			this.BotonMejorRuta.Text = "Mejor Ruta del Reconocimiento Random";
			this.BotonMejorRuta.UseVisualStyleBackColor = true;
			this.BotonMejorRuta.Visible = false;
			this.BotonMejorRuta.Click += new System.EventHandler(this.BotonMejorRuta_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(183, 148);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "Ocultos";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 148);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "Visibles";
			// 
			// CajaTextoVisibles
			// 
			this.CajaTextoVisibles.Enabled = false;
			this.CajaTextoVisibles.Location = new System.Drawing.Point(80, 145);
			this.CajaTextoVisibles.Margin = new System.Windows.Forms.Padding(4);
			this.CajaTextoVisibles.Name = "CajaTextoVisibles";
			this.CajaTextoVisibles.Size = new System.Drawing.Size(73, 22);
			this.CajaTextoVisibles.TabIndex = 7;
			this.CajaTextoVisibles.Text = "10";
			// 
			// CajaTextoOcultos
			// 
			this.CajaTextoOcultos.Enabled = false;
			this.CajaTextoOcultos.Location = new System.Drawing.Point(258, 145);
			this.CajaTextoOcultos.Margin = new System.Windows.Forms.Padding(4);
			this.CajaTextoOcultos.Name = "CajaTextoOcultos";
			this.CajaTextoOcultos.Size = new System.Drawing.Size(73, 22);
			this.CajaTextoOcultos.TabIndex = 8;
			this.CajaTextoOcultos.Text = "100";
			// 
			// BotonRandomReconocimiento
			// 
			this.BotonRandomReconocimiento.Enabled = false;
			this.BotonRandomReconocimiento.Location = new System.Drawing.Point(7, 106);
			this.BotonRandomReconocimiento.Margin = new System.Windows.Forms.Padding(4);
			this.BotonRandomReconocimiento.Name = "BotonRandomReconocimiento";
			this.BotonRandomReconocimiento.Size = new System.Drawing.Size(325, 28);
			this.BotonRandomReconocimiento.TabIndex = 5;
			this.BotonRandomReconocimiento.Text = "Random con Reconocimiento";
			this.BotonRandomReconocimiento.UseVisualStyleBackColor = true;
			this.BotonRandomReconocimiento.Click += new System.EventHandler(this.BotonRandomReconocimiento_Click);
			// 
			// BotonLineaRectaSimple
			// 
			this.BotonLineaRectaSimple.Enabled = false;
			this.BotonLineaRectaSimple.Location = new System.Drawing.Point(7, 30);
			this.BotonLineaRectaSimple.Margin = new System.Windows.Forms.Padding(4);
			this.BotonLineaRectaSimple.Name = "BotonLineaRectaSimple";
			this.BotonLineaRectaSimple.Size = new System.Drawing.Size(325, 28);
			this.BotonLineaRectaSimple.TabIndex = 4;
			this.BotonLineaRectaSimple.Text = "Linea Recta Simple";
			this.BotonLineaRectaSimple.UseVisualStyleBackColor = true;
			this.BotonLineaRectaSimple.Click += new System.EventHandler(this.BotonLineaRectaSimple_Click);
			// 
			// partidaCajaAgrupacion
			// 
			this.partidaCajaAgrupacion.Controls.Add(this.BotonCargar);
			this.partidaCajaAgrupacion.Controls.Add(this.BotonGuardar);
			this.partidaCajaAgrupacion.Location = new System.Drawing.Point(695, 530);
			this.partidaCajaAgrupacion.Name = "partidaCajaAgrupacion";
			this.partidaCajaAgrupacion.Size = new System.Drawing.Size(340, 100);
			this.partidaCajaAgrupacion.TabIndex = 5;
			this.partidaCajaAgrupacion.TabStop = false;
			this.partidaCajaAgrupacion.Text = "Partida";
			// 
			// BotonCargar
			// 
			this.BotonCargar.Location = new System.Drawing.Point(7, 58);
			this.BotonCargar.Margin = new System.Windows.Forms.Padding(4);
			this.BotonCargar.Name = "BotonCargar";
			this.BotonCargar.Size = new System.Drawing.Size(325, 28);
			this.BotonCargar.TabIndex = 5;
			this.BotonCargar.Text = "Cargar";
			this.BotonCargar.UseVisualStyleBackColor = true;
			this.BotonCargar.Click += new System.EventHandler(this.BotonCargar_Click);
			// 
			// BotonGuardar
			// 
			this.BotonGuardar.Enabled = false;
			this.BotonGuardar.Location = new System.Drawing.Point(7, 22);
			this.BotonGuardar.Margin = new System.Windows.Forms.Padding(4);
			this.BotonGuardar.Name = "BotonGuardar";
			this.BotonGuardar.Size = new System.Drawing.Size(325, 28);
			this.BotonGuardar.TabIndex = 4;
			this.BotonGuardar.Text = "Guardar";
			this.BotonGuardar.UseVisualStyleBackColor = true;
			this.BotonGuardar.Click += new System.EventHandler(this.BotonGuardar_Click);
			// 
			// Ventana
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1045, 647);
			this.Controls.Add(this.partidaCajaAgrupacion);
			this.Controls.Add(this.movimientoCajaAgrupacion);
			this.Controls.Add(this.modalidadesCajaAgrupacion);
			this.Controls.Add(this.datosCajaAgrupacion);
			this.Controls.Add(this.PanelAmbiente);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "Ventana";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Prueba 1 - Nuevo";
			this.datosCajaAgrupacion.ResumeLayout(false);
			this.datosCajaAgrupacion.PerformLayout();
			this.modalidadesCajaAgrupacion.ResumeLayout(false);
			this.movimientoCajaAgrupacion.ResumeLayout(false);
			this.movimientoCajaAgrupacion.PerformLayout();
			this.partidaCajaAgrupacion.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelAmbiente;
        private System.Windows.Forms.GroupBox datosCajaAgrupacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BotonCrearCuadricula;
        private System.Windows.Forms.TextBox CajaTextoCuadrosBase;
        private System.Windows.Forms.TextBox CajaTextoCuadrosAltura;
        private System.Windows.Forms.GroupBox modalidadesCajaAgrupacion;
        private System.Windows.Forms.Button BotonCasa;
        private System.Windows.Forms.Button BotonAvatar;
        private System.Windows.Forms.Button BotonObstaculo;
		private System.Windows.Forms.Button BotonLineaRectaReconocimiento;
		private System.Windows.Forms.GroupBox movimientoCajaAgrupacion;
		private System.Windows.Forms.GroupBox partidaCajaAgrupacion;
		private System.Windows.Forms.Button BotonCargar;
		private System.Windows.Forms.Button BotonGuardar;
		private System.Windows.Forms.Button BotonLineaRectaSimple;
		private System.Windows.Forms.Button BotonRandomReconocimiento;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox CajaTextoVisibles;
		private System.Windows.Forms.TextBox CajaTextoOcultos;
		private System.Windows.Forms.Button BotonMejorRuta;
	}
}

