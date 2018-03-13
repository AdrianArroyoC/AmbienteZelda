using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbienteZelda
{
    public partial class Ventana : Form
    {
        private int CuadrosEnY {get; set;}
        private int CuadrosEnX {get; set;}
        private PictureBox[,] Ambiente {get; set;}
		private Link Adrian {get; set;}
		private int XAvatar {get; set;}
		private int YAvatar {get; set;}
		private int Boton {get; set;}
		private bool Avatar {get; set;}
		private bool Casa {get; set;}
        private int XCasa {get; set;}
		private int YCasa {get; set;}
		private bool Fin {get; set;}

        public Ventana()
        {
            InitializeComponent();
			Boton = 1;
			Avatar = false;
			Casa = false;
			Fin = false;
        }
        
        private void BotonCrearCuadricula_Click(object sender, EventArgs e)
        {
			if (CajaCuadrosX.Text != "" && CajaCuadrosY.Text != "")
			{
				CuadrosEnY = Convert.ToInt32(CajaCuadrosY.Text);
				CuadrosEnX = Convert.ToInt32(CajaCuadrosX.Text);
				BotonCasa.Enabled = false;
				BotonObstaculo.Enabled = false;
				Casa = false;
				if (CuadrosEnY >= 10 && CuadrosEnY <= 100 && CuadrosEnX >= 10 && CuadrosEnX <= 100)
				{
					PanelAmbiente.Width = 500;
					PanelAmbiente.Height = 500;
					PanelAmbiente.Controls.Clear();
					PanelAmbiente.BackgroundImage = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Fondo2.jpg");
					Avatar = false;
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
					BotonAvatar.Enabled = true;
					SeleccionarBoton();
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
						CajaImagen.Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Arbol.jpg");
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
					Adrian = new Link(Ambiente);
					Adrian.Mover(XAvatar, YAvatar);
					//CajaImagen.Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Link.jpg");
					Avatar = true;
					BotonCasa.Enabled = true;
					PanelAmbiente.Focus();
				}
				else if (Boton == 2 && Casa == false && CajaImagen.Image == null)
				{
					CajaImagen.Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Casa.jpg");
					Casa = true;
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
					if (coordenadas[0] == XCasa && coordenadas[1] == YCasa)
					{
						Fin = true;
						MessageBox.Show("Game Over");
						BotonAvatar.Enabled = false;
						BotonCasa.Enabled = false;
						BotonObstaculo.Enabled = false;
						return;
					}
				}
				Ambiente[coordenadas[0], coordenadas[1]].Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Link.jpg");
				XAvatar = coordenadas[0];
				YAvatar = coordenadas[1];
			}
		}

		private void PanelAmbiente_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, PanelAmbiente.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
		}

		private void BotonIniciar_Click(object sender, EventArgs e)
		{
			Adrian.LineaBresenham(XAvatar, YAvatar, XCasa, YCasa);
		}
	}
}