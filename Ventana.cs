using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace AmbienteZelda
{
    public partial class Ventana : Form 
    {
		private PictureBox[,] Ambiente { get; set; }
		private Link Adrian { get; set; }
        private int CuadrosEnX { get; set; }
		private int CuadrosEnY { get; set; }
		private int XAvatar { get; set; }
		private int YAvatar { get; set; }
        private int XCasa { get; set; }
		private int YCasa { get; set; }
		private int Boton { get; set; }
		private bool Fin { get; set; }
		private bool Avatar { get; set; }
		private bool Casa { get; set; }
		private readonly String rutaImagenAvatar = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Link.jpg";
		private readonly String rutaImagenCasa = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Casa.jpg";
		private readonly String rutaImagenArbol = "D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Arbol.jpg";
		private string RutaArchivo { get; set; }

		public Ventana()
        {
            InitializeComponent();
			Boton = 1;
			Avatar = false;
			Casa = false;
			Fin = false;
        }

		public void CrearCuadricula(bool[,] ObstaculosAmbiente = null)
		{
			PanelAmbiente.Width = 500;
			PanelAmbiente.Height = 500;
			PanelAmbiente.Controls.Clear();
			PanelAmbiente.BackgroundImage = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Fondo2.jpg");
			Avatar = false;
			BotonCasa.Enabled = false;
			BotonObstaculo.Enabled = false;
			Casa = false;
			Ambiente = new PictureBox[CuadrosEnX, CuadrosEnY];
			int a = PanelAmbiente.Width / CuadrosEnX;
			int l = PanelAmbiente.Height / CuadrosEnY;
			PanelAmbiente.Width = CuadrosEnX * a;
			PanelAmbiente.Height = CuadrosEnY * l;
			for (int i = 1; i <= CuadrosEnX; i++)
			{
				for (int j = 1; j <= CuadrosEnY; j++)
				{
					PictureBox CajaImagen = new PictureBox
					{
						Location = new Point(i * a - a, j * l - l),
						Size = new Size(a, l),
						BorderStyle = BorderStyle.None,
						Name = "CajaImagen" + (i - 1).ToString() + "-" + (j - 1).ToString() + "",
						BackColor = Color.Transparent,
						SizeMode = PictureBoxSizeMode.StretchImage
					};
					CajaImagen.MouseClick += CajaImagen_MouseClick;
					CajaImagen.Paint += CajaImagen_Paint;
					Ambiente[i - 1, j - 1] = CajaImagen;
					PanelAmbiente.Controls.Add(CajaImagen);
				}
			}
			if (ObstaculosAmbiente != null)
			{
				for (int i = 0; i < CuadrosEnX; i++)
				{
					for (int j = 0; j < CuadrosEnY; j++)
					{
						if (ObstaculosAmbiente[i, j] == true)
						{
							Ambiente[i, j].Image = Image.FromFile(rutaImagenArbol);
						}
					}
				}
			}
			BotonAvatar.Enabled = true;
			BotonGuardar.Enabled = true;
			SeleccionarBoton();
		}
        
        private void BotonCrearCuadricula_Click(object sender, EventArgs e)
        {
			if (CajaCuadrosX.Text != "" && CajaCuadrosY.Text != "")
			{
				CuadrosEnY = Convert.ToInt32(CajaCuadrosY.Text);
				CuadrosEnX = Convert.ToInt32(CajaCuadrosX.Text);
				if (CuadrosEnY >= 10 && CuadrosEnY <= 100 && CuadrosEnX >= 10 && CuadrosEnX <= 100)
				{
					this.Text = "Prueba 1 - Nuevo";
					Boton = 1;
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
				if (Boton == 0)
				{
					if (e.Button == MouseButtons.Left && CajaImagen.Image == null)
					{
						CajaImagen.Image = Image.FromFile(rutaImagenArbol);
					}
					else if (e.Button == MouseButtons.Right)
					{
						CajaImagen.Image = null;
					}
				}
				else if (this.Boton == 1 && this.Avatar == false && CajaImagen.Image == null)
				{
					XAvatar = x;
					YAvatar = y;
					Adrian = new Link(rutaImagenAvatar);
					Adrian.ReconocerAmbiente(Ambiente);
					Adrian.Mover(XAvatar, YAvatar);
					Avatar = true;
					BotonCasa.Enabled = true;
					PanelAmbiente.Focus();
				}
				else if (Boton == 2 && Casa == false && CajaImagen.Image == null)
				{
					CajaImagen.Image = Image.FromFile(rutaImagenCasa);
					Casa = true;
					BotonLineaRecta.Enabled = true;
					Adrian.ReconocerCasa(x, y);
					XCasa = x;
					YCasa = y;
					BotonObstaculo.Enabled = true;
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
				if (Boton == 0)
				{
					BotonObstaculo.FlatStyle = FlatStyle.Standard;
				}
				else if (Boton == 1)
				{
					BotonAvatar.FlatStyle = FlatStyle.Standard;
					PanelAmbiente.Focus();
				}
				else if (Boton == 2)
				{
					BotonCasa.FlatStyle = FlatStyle.Standard;
				}
			}
		}
		
        private void BotonObstaculo_Click(object sender, EventArgs e)
        {
            Boton = 0;
            SeleccionarBoton();
        }

        private void BotonAvatar_Click(object sender, EventArgs e)
        {
            Boton = 1;
            SeleccionarBoton();
			if (Avatar)
			{
				Adrian.ReconocerAmbiente(Ambiente);
			}
		}

        private void BotonCasa_Click(object sender, EventArgs e)
        {
            Boton = 2;
            SeleccionarBoton();
        }

		private void PanelAmbiente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (Boton == 1 && !Fin)
			{
				int[] coordenadas = Adrian.Mover(XAvatar, YAvatar, e);
				Ambiente[XAvatar, YAvatar].Image = null;
				if (Casa)
				{
					if (Adrian.EnCasa)
					{
						BloquearEscenario();
						return;
					}
				}
				XAvatar = coordenadas[0];
				YAvatar = coordenadas[1];
			}
		}

		private void BloquearEscenario()
		{
			BotonAvatar.Enabled = false;
			BotonCasa.Enabled = false;
			BotonObstaculo.Enabled = false;
			BotonLineaRecta.Enabled = false;
			MessageBox.Show("Game Over");
		}

		private void PanelAmbiente_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, PanelAmbiente.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
		}

		private void BotonLineaRecta_Click(object sender, EventArgs e)
		{
			Adrian.LineaBresenham(XAvatar, YAvatar, XCasa, YCasa);
			if (Adrian.EnCasa)
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
				bool[,] ObstaculosAmbiente = new bool[CuadrosEnX, CuadrosEnY];
				for (int i = 1; i < CuadrosEnX; i++)
				{
					for (int j = 1; j < CuadrosEnY; j++)
					{
						if (Ambiente[i, j].Image != null && (i != XAvatar && j != YAvatar) && (i != XCasa && j != YCasa))
						{
							ObstaculosAmbiente[i, j] = true;
						}
						else
						{
							ObstaculosAmbiente[i, j] = false;
						}
					}
				}
				Mapa mapa = new Mapa(CuadrosEnX, CuadrosEnY, XAvatar, YAvatar, XCasa, YCasa, Boton, Fin, Avatar, Casa, ObstaculosAmbiente);
				//Realizamos el guardado
				byte[] arregloBytes = new byte[1000000]; //1Mb
				IFormatter formateador = new BinaryFormatter();
				Stream flujo = new MemoryStream(arregloBytes, true);
				formateador.Serialize(flujo, mapa);
				flujo.Close();
				RutaArchivo = dialogoGuardarArchivo.FileName.ToString();
				FileStream archivo = File.Create(RutaArchivo);
				archivo.Write(arregloBytes, 0, arregloBytes.Length);
				archivo.Close();
				MessageBox.Show("Ambiente guardado");
				this.Text = "Prueba 1 - " + RutaArchivo;
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
				RutaArchivo = dialogoAbrirArchivo.FileName.ToString();
				FileStream archivo = File.Open(RutaArchivo, FileMode.Open, FileAccess.Read);
				byte[] arregloBytes = new byte[1000000];
				archivo.Read(arregloBytes, 0, arregloBytes.Length);
				archivo.Close();
				IFormatter formateador = new BinaryFormatter();
				Stream flujo = new MemoryStream(arregloBytes, true);
				Mapa mapa = (Mapa)formateador.Deserialize(flujo);
				flujo.Close();
				//Preparamos los datos a cargar
				CuadrosEnX = mapa.CX;
				CuadrosEnY = mapa.CY;
				CajaCuadrosX.Text = CuadrosEnX.ToString();
				CajaCuadrosY.Text = CuadrosEnY.ToString();
				XAvatar = mapa.XA;
				YAvatar = mapa.YA;
				XCasa = mapa.XC;
				YCasa = mapa.YC;
				Boton = mapa.B;
				CrearCuadricula(mapa.OA);
				Avatar = mapa.A;
				if (Avatar)
				{
					Ambiente[XAvatar, YAvatar].Image = Image.FromFile(rutaImagenAvatar);
					BotonCasa.Enabled = true;
				}
				Casa = mapa.C;
				if (Casa)
				{
					Ambiente[XCasa, YCasa].Image = Image.FromFile(rutaImagenCasa);
					BotonObstaculo.Enabled = true;
					BotonLineaRecta.Enabled = true;
				}
				Fin = mapa.F;
				if (Fin)
				{
					BloquearEscenario();
				}
				this.Text = "Prueba 1" + RutaArchivo;
			}
		}
	}
}