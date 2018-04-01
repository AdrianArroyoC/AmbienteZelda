﻿using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbienteZelda
{
    public partial class Ventana : Form 
    {
		private readonly String rutaImagenAvatar = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Link.jpg";
		private readonly String rutaImagenCasa = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Casa.jpg";
		private readonly String rutaImagenArbol = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Arbol.jpg";
		private readonly String rutaImagenFin = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\CasaLink.jpg";
		private readonly String rutaImagenAux1 = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\LinkAzul.jpg";
		private readonly String rutaImagenAux2 = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\LinkRojo.jpg";
		private readonly String rutaFondo = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Fondo2.jpg";
		private int CuadrosX { get; set; }
		private int CuadrosY { get; set; }
		private int Modo { get; set; } //0=Obstaculos, 1=Avatar y 2=Meta
		private bool Fin { get; set; }
		public static PictureBox[,] Ambiente { get; set; }
		private int[,] AmbienteAvatar{ get; set; }
        public static Avatar Link { get; set; }
		public static Meta Casa { get; set; }

		public Ventana()
        {
            InitializeComponent();
        }

		public void CrearCuadricula(bool[,] Obstaculos = null)
		{
			//Restablecemos el tamaño original del ambiente y calculamos el nuevo tamaño en base a los cuadros
			PanelAmbiente.Width = 500;
			PanelAmbiente.Height = 500;
			PanelAmbiente.Controls.Clear();
			int xCuadro = PanelAmbiente.Width / CuadrosX;
			int yCuadro = PanelAmbiente.Height / CuadrosY;
			PanelAmbiente.Width = CuadrosX * xCuadro;
			PanelAmbiente.Height = CuadrosY * yCuadro;
			PanelAmbiente.BackgroundImage = Image.FromFile(rutaFondo);
			BotonCasa.Enabled = false;
			BotonObstaculo.Enabled = false;
			BotonAvatar.Enabled = true;
			BotonGuardar.Enabled = true;
			Text = "Prueba 1 - Nuevo";
			Link = null;
			Casa = null;
			Modo = 1;
			Fin = false;
			//Creamos el ambiente y sus cuadros
			Ambiente = new PictureBox[CuadrosX, CuadrosY];
			AmbienteAvatar = new int[CuadrosX, CuadrosY];
			for (int i = 1; i <= CuadrosX; i++)
			{
				for (int j = 1; j <= CuadrosY; j++)
				{
					PictureBox CajaImagen = new PictureBox
					{
						Location = new Point(i * xCuadro - xCuadro, j * yCuadro - yCuadro),
						Size = new Size(xCuadro, yCuadro),
						BorderStyle = BorderStyle.None,
						Name = "CajaImagen" + (i - 1).ToString() + "-" + (j - 1).ToString() + "",
						BackColor = Color.Transparent,
						SizeMode = PictureBoxSizeMode.StretchImage
					};
					CajaImagen.MouseClick += CajaImagen_MouseClick;
					CajaImagen.Paint += CajaImagen_Paint;
					Ambiente[i - 1, j - 1] = CajaImagen;
					PanelAmbiente.Controls.Add(CajaImagen);
					AmbienteAvatar[i - 1, j - 1] = -2;
				}
			}
			//Para la carga de obstaculos //Revisar si se puede arriba
			if (Obstaculos != null)
			{
				for (int i = 0; i < CuadrosX; i++)
				{
					for (int j = 0; j < CuadrosY; j++)
					{
						if (Obstaculos[i, j] == true)
						{
							Ambiente[i, j].Image = Image.FromFile(rutaImagenArbol);
						}
					}
				}
			}
			SeleccionarBoton();
		}
        
        private void BotonCrearCuadricula_Click(object sender, EventArgs e)
        {
			if (CajaCuadrosX.Text != "" && CajaCuadrosY.Text != "")
			{
				CuadrosY = Convert.ToInt32(CajaCuadrosY.Text);
				CuadrosX = Convert.ToInt32(CajaCuadrosX.Text);
				if (CuadrosY >= 10 && CuadrosY <= 100 && CuadrosX >= 10 && CuadrosX <= 100)
				{
					CrearCuadricula();
				}
				else
				{
					MessageBox.Show("Los valores deben de ser entre 10 y 100");
				}
			}
			else
			{
				MessageBox.Show("Debes llenar ambos campos");
			}
        }

		private void CajaImagen_Paint(object sender, PaintEventArgs e)
		{
			PictureBox CajaImagen = sender as PictureBox;
			ControlPaint.DrawBorder(e.Graphics, CajaImagen.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
		}

		private void CajaImagen_MouseClick(object sender, MouseEventArgs e)
		{
			if (!Fin)
			{
				PictureBox CajaImagen = sender as PictureBox;
				string[] coordenadas = CajaImagen.Name.Replace("CajaImagen", "").Split('-');
				int x = Convert.ToInt32(coordenadas[0]);
				int y = Convert.ToInt32(coordenadas[1]);
				if (Modo == 0)
				{
					if (e.Button == MouseButtons.Left && CajaImagen.Image == null)
					{
						CajaImagen.Image = Image.FromFile(rutaImagenArbol);
					}
					else if (e.Button == MouseButtons.Right)
					{
						CajaImagen.Image = null;
					}
					Text = Text.Replace(" *","") + " *";
				}
				else if (Modo == 1 && Link == null && CajaImagen.Image == null)
				{
					Link = new Avatar(x, y, rutaImagenAvatar, rutaImagenAux1, rutaImagenAux2, AmbienteAvatar);
					BotonCasa.Enabled = true;
					PanelAmbiente.Focus();
					Text = Text.Replace(" *","") + " *";
				}
				else if (Modo == 2 && Casa == null && CajaImagen.Image == null)
				{
					Casa = new Meta(x, y, rutaImagenCasa);
					BotonLineaRecta.Enabled = true;
					BotonObstaculo.Enabled = true;
					Text = Text.Replace(" *","") + " *";
				}
			}
		}
		
		private void CajaCuadrosY_KeyPress(object sender, KeyPressEventArgs e)
        {
			if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
				e.Handled = true;
                return;
            }
        }

        private void CajaCuadrosX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
				e.Handled = true;
                return;
            }
        }

        private void SeleccionarBoton()
        {
			BotonObstaculo.FlatStyle = FlatStyle.Popup;
			BotonAvatar.FlatStyle = FlatStyle.Popup;
			BotonCasa.FlatStyle = FlatStyle.Popup;
			if (!Fin)
			{
				if (Modo == 0)
				{
					BotonObstaculo.FlatStyle = FlatStyle.Standard;
				}
				else if (Modo == 1)
				{
					BotonAvatar.FlatStyle = FlatStyle.Standard;
					PanelAmbiente.Focus();
				}
				else if (Modo == 2)
				{
					BotonCasa.FlatStyle = FlatStyle.Standard;
				}
			}
		}
		
        private void BotonObstaculo_Click(object sender, EventArgs e)
        {
            Modo = 0;
            SeleccionarBoton();
        }

        private void BotonAvatar_Click(object sender, EventArgs e)
        {
            Modo = 1;
            SeleccionarBoton();
		}

        private void BotonCasa_Click(object sender, EventArgs e)
        {
            Modo = 2;
            SeleccionarBoton();
        }

		private void PanelAmbiente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (Modo == 1 && !Fin)
			{
				Ambiente[Link.X, Link.Y].Image = null;
				Link.Mover(e);
				if (Casa != null)
				{
					if (Link.EnCasa)
					{
						BloquearEscenario();
						return;
					}
				}
			}
			//Se puede solucionar con un true en Avatar.Mover
			Text = Text.Replace(" *","") + " *";
		}

		public void BloquearEscenario()
		{
			BotonAvatar.Enabled = false;
			BotonCasa.Enabled = false;
			BotonObstaculo.Enabled = false;
			BotonLineaRecta.Enabled = false;
			Ambiente[Casa.X, Casa.Y].Image = Image.FromFile(rutaImagenFin);
			MessageBox.Show("Game Over");
		}

		private void PanelAmbiente_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, PanelAmbiente.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
		}

		private async void BotonLineaRecta_Click(object sender, EventArgs e)
		{
			await Link.LineaBresenhamAsync();
			if (Link.EnCasa)
			{
				BloquearEscenario();
			}
		}

		private void BotonGuardar_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialogoGuardarArchivo = new SaveFileDialog
			{
				Filter = "dat files (*.dat)|*.dat",
				RestoreDirectory = true
			};
			if (dialogoGuardarArchivo.ShowDialog() == DialogResult.OK)
			{
				//Preparamos el objeto a guardar
				bool[,] Obstaculos = new bool[CuadrosX, CuadrosY];
				for (int i = 0; i < CuadrosX; i++)
				{
					for (int j = 0; j < CuadrosY; j++)
					{
						if (Ambiente[i, j].Image != null) // && (i != Link.X && j != Link.Y) && (i != Casa.X && j != Casa.Y)
						{
							Obstaculos[i, j] = true;
						}
						else
						{
							Obstaculos[i, j] = false;
						}
					}
				}
				Partida partida = new Partida(CuadrosX, CuadrosY, Modo, Fin, Obstaculos, Link, Casa);
				//Realizamos el guardado
				byte[] arregloBytes = new byte[1000000]; //1Mb
				IFormatter formateador = new BinaryFormatter();
				Stream transferencia = new MemoryStream(arregloBytes, true);
				formateador.Serialize(transferencia, partida);
				transferencia.Close();
				string RutaArchivo = dialogoGuardarArchivo.FileName.ToString();
				FileStream archivo = File.Create(RutaArchivo);
				archivo.Write(arregloBytes, 0, arregloBytes.Length);
				archivo.Close();
				MessageBox.Show("Ambiente guardado");
				Text = "Prueba 1 - " + RutaArchivo;
			}
		}

		private void BotonCargar_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialogoAbrirArchivo = new OpenFileDialog
			{
				Filter = "dat files (*.dat)|*.dat",
				RestoreDirectory = true
			};
			if (dialogoAbrirArchivo.ShowDialog() == DialogResult.OK)
			{
				//Realizamos la lectura
				string RutaArchivo = dialogoAbrirArchivo.FileName.ToString();
				FileStream archivo = File.Open(RutaArchivo, FileMode.Open, FileAccess.Read);
				byte[] arregloBytes = new byte[1000000];
				archivo.Read(arregloBytes, 0, arregloBytes.Length);
				archivo.Close();
				IFormatter formateador = new BinaryFormatter();
				Stream transferencia = new MemoryStream(arregloBytes, true);
				Partida partida = (Partida)formateador.Deserialize(transferencia);
				transferencia.Close();
				//Preparamos los datos a cargar
				CuadrosX = partida.CX;
				CuadrosY = partida.CY;
				Modo = partida.M;
				Fin = partida.F;
				CrearCuadricula(partida.O);
				Link = partida.L;
				Casa = partida.C;
				if (Link != null)
				{
					Link.Colocar();
					BotonCasa.Enabled = true;
				}
				if (Casa != null)
				{
					Casa.Colocar();
					BotonObstaculo.Enabled = true;
					BotonLineaRecta.Enabled = true;
				}
				CajaCuadrosX.Text = CuadrosX.ToString();
				CajaCuadrosY.Text = CuadrosY.ToString();
				if (Fin)
				{
					BloquearEscenario();
				}
				Text = "Prueba 1 - " + RutaArchivo;
			}
		}
	}
}