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
        private int cuadrosY;
        private int cuadrosX;
        private PictureBox[,] ambiente;
        private Link adrian;
        private int xA;
        private int yA;
        private int boton = 1;
        private bool avatar = false;
        private bool casa = false;
        private int xC;
		private int yC;
		private bool fin = false;

        public Ventana()
        {
            InitializeComponent();
			MessageBox.Show("Bienvenido al ambiente de Hyrule selecciona la cantidad de cuadros a lo largo y alto del mapa para empezar.");
        }
        
        private void BotonCrearCuadricula_Click(object sender, EventArgs e)
        {
			if (CajaCuadrosX.Text != "" && CajaCuadrosY.Text != "")
			{
				cuadrosY = Convert.ToInt32(CajaCuadrosY.Text);
				cuadrosX = Convert.ToInt32(CajaCuadrosX.Text);
				if (cuadrosY >= 10 && cuadrosY <= 100 && cuadrosX >= 10 && cuadrosX <= 100)
				{
					PanelAmbiente.Width = 500;
					PanelAmbiente.Height = 500;
					PanelAmbiente.Controls.Clear();
					PanelAmbiente.BackgroundImage = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Fondo2.jpg");
					avatar = false;
					ambiente = new PictureBox[cuadrosX, cuadrosY];
					int a = PanelAmbiente.Width / cuadrosX;
					int l = PanelAmbiente.Height / cuadrosY;
					PanelAmbiente.Width = cuadrosX * a;
					PanelAmbiente.Height = cuadrosY * l;
					for (int i = 1; i <= cuadrosX; i++)
					{
						for (int j = 1; j <= cuadrosY; j++)
						{
							PictureBox CajaImagen = new PictureBox
							{
								Location = new System.Drawing.Point(i * a - a, j * l - l),
								Size = new System.Drawing.Size(a, l),
								BorderStyle = BorderStyle.FixedSingle,
								Name = "CajaImagen" + (i - 1).ToString() + "-" + (j - 1).ToString() + "",
								BackColor = Color.Transparent,
								SizeMode = PictureBoxSizeMode.StretchImage
							};
							CajaImagen.MouseClick += CajaImagen_MouseClick;
							ambiente[i - 1, j - 1] = CajaImagen;
							PanelAmbiente.Controls.Add(CajaImagen);
						}
					}
					BotonAvatar.Enabled = true;
					MessageBox.Show("Selecciona la ubicacion inicial del avatar");
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

		private void CajaImagen_MouseClick(object sender, MouseEventArgs e)
		{
			if (!fin)
			{
				PictureBox CajaImagen = sender as PictureBox;
				string[] coordenadas = CajaImagen.Name.Replace("CajaImagen", "").Split('-');
				int x = Convert.ToInt32(coordenadas[0]);
				int y = Convert.ToInt32(coordenadas[1]);
				if (boton == 0)
				{
					if (e.Button == MouseButtons.Left && CajaImagen.Image == null)
					{
						CajaImagen.Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Arbol.png");
					}
					else if (e.Button == MouseButtons.Right)
					{
						CajaImagen.Image = null;
					}
				}
				else if (this.boton == 1 && this.avatar == false && CajaImagen.Image == null)
				{
					xA = x;
					yA = y;
					adrian = new Link();
					CajaImagen.Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Link.png");
					avatar = true;
					BotonCasa.Enabled = true;
					PanelAmbiente.Focus();
					MessageBox.Show("Selecciona el boton del pino para colocar con click derecho y remover con izquierdo los obstaculos,"
						+ " tambien puedes seleccionar el boton del castillo para colocar una sola meta para el recorrido.");
				}
				else if (boton == 2 && casa == false && CajaImagen.Image == null)
				{
					CajaImagen.Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Casa.png");
					casa = true;
					adrian.ReconocerCasa(x, y);
					xC = x;
					yC = y;
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
            BotonObstaculo.BackColor = SystemColors.AppWorkspace;
            BotonAvatar.BackColor = SystemColors.AppWorkspace;
            BotonCasa.BackColor = SystemColors.AppWorkspace;
			if (!fin)
			{
				if (boton == 0)
				{
					BotonObstaculo.BackColor = SystemColors.ActiveCaption;
				}
				else if (boton == 1)
				{
					BotonAvatar.BackColor = SystemColors.ActiveCaption;
					PanelAmbiente.Focus();
				}
				else if (boton == 2)
				{
					BotonCasa.BackColor = SystemColors.ActiveCaption;
				}
			}
        }
		
        private void BotonObstaculo_Click(object sender, EventArgs e)
        {
            boton = 0;
            SeleccionarBoton();
        }

        private void BotonAvatar_Click(object sender, EventArgs e)
        {
            boton = 1;
            SeleccionarBoton();
        }

        private void BotonCasa_Click(object sender, EventArgs e)
        {
            boton = 2;
            SeleccionarBoton();
        }

		private void PanelAmbiente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (boton == 1 && !fin)
			{
				int[] coordenadas = adrian.Mover(ambiente, xA, yA, e);
				ambiente[xA, yA].Image = null;
				if (casa)
				{
					if (coordenadas[0] == xC && coordenadas[1] == yC)
					{
						fin = true;
						MessageBox.Show("Haz llegado a tu castillo");
						BotonAvatar.Enabled = false;
						BotonCasa.Enabled = false;
						BotonObstaculo.Enabled = false;
						return;
					}
				}
				ambiente[coordenadas[0], coordenadas[1]].Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Link.png");
				xA = coordenadas[0];
				yA = coordenadas[1];
			}
		}
	}
}