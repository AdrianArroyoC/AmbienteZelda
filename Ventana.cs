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
        private int largo = 0;
        private int ancho = 0;
        private PictureBox[,] ambiente;
        private Link adrian;
        private int x = 0;
        private int y = 0;
        private int boton = 1;
        private bool avatar = false;
        private bool casa = false;
        private int[] coordenadasCasa = new int[2];

        public Ventana()
        {
            InitializeComponent();
        }
        
        private void BotonCrearCuadricula_Click(object sender, EventArgs e)
        {
            this.largo = Convert.ToInt32(this.CajaBase.Text);
            this.ancho = Convert.ToInt32(this.CajaAltura.Text);
            if ((this.largo >= 10 && this.largo <= 100) && (this.ancho >= 10 && this.ancho <= 100))
            {
                this.PanelAmbiente.Width = 500;
                this.PanelAmbiente.Height = 500;
                this.PanelAmbiente.Controls.Clear();
                this.avatar = false;
                this.ambiente = new PictureBox[ancho, largo];
                int a = this.PanelAmbiente.Width / ancho;
                int l = this.PanelAmbiente.Height / largo;
                this.PanelAmbiente.Width = ancho * a;
                this.PanelAmbiente.Height = largo * l;
                for (int i = 1; i <= ancho; i++)
                {
                    for (int j = 1; j <= largo; j++)
                    {
                        PictureBox CajaImagen = new PictureBox
                        {
                            Location = new System.Drawing.Point(i * a - a, j * l - l),
                            Size = new System.Drawing.Size(a, l),
                            BorderStyle = BorderStyle.FixedSingle,
                            Name = "CajaImagen" + (i - 1).ToString() + "-" + (j - 1).ToString() + "",
                            BackColor = Color.Transparent
                        };
                        CajaImagen.Click += CajaImagen_Click;
                        this.ambiente[i - 1, j - 1] = CajaImagen;
                        this.PanelAmbiente.Controls.Add(CajaImagen);
                    }
                    //MessageBox.Show(i.ToString());
                }
                this.BotonAvatar.Enabled = true;
                MessageBox.Show("Selecciona la ubicacion inicial del avatar");
                SeleccionarBoton();
            }
            else
            {
                MessageBox.Show("Los valores deben de ser entre 10 y 100");
            }
        }

        private void CajaImagen_Click(object sender, EventArgs e)
        {
            PictureBox CajaImagen = sender as PictureBox;
            string[] coordenadas = CajaImagen.Name.Replace("CajaImagen", "").Split('-');
            int x = Convert.ToInt32(coordenadas[0]);
            int y = Convert.ToInt32(coordenadas[1]);
            if (this.boton == 0)
            {
                CajaImagen.Image = Image.FromFile("C:\\Users\\adria\\source\\repos\\AmbienteZelda\\AmbienteZelda\\src\\Arbol.png");
            }
            else if (this.boton == 1 && this.avatar == false)
            {
                this.x = x;
                this.y = y;
                adrian = new Link(ambiente, x, y);
                avatar = true;
                BotonObstaculo.Enabled = true;
                BotonCasa.Enabled = true;
            }
            else if (this.boton == 2 && this.casa == false)
            {
                CajaImagen.Image = Image.FromFile("C:\\Users\\adria\\source\\repos\\AmbienteZelda\\AmbienteZelda\\src\\Casa.png");
                casa = true;
                MessageBox.Show(x.ToString());
                coordenadasCasa[0] = x;
                coordenadasCasa[1] = y;
            }
            CajaImagen.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void CajaLargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                return;
            }
        }

        private void CajaAncho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                return;
            }
        }

        private void SeleccionarBoton()
        {
            this.BotonObstaculo.BackColor = SystemColors.AppWorkspace;
            this.BotonAvatar.BackColor = SystemColors.AppWorkspace;
            this.BotonCasa.BackColor = SystemColors.AppWorkspace;
            if (this.boton == 0)
            {
                this.BotonObstaculo.BackColor = SystemColors.ActiveCaption;
            }
            else if (this.boton == 1)
            {
                this.BotonAvatar.BackColor = SystemColors.ActiveCaption;
            }
            else if (this.boton == 2)
            {
                this.BotonCasa.BackColor = SystemColors.ActiveCaption;
            }
        }

        private void Ventana_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.boton == 1)
            {
                if (casa)
                {
                    adrian.Reconocer(coordenadasCasa[0], coordenadasCasa[1]);
                }
                adrian.Mover(ambiente, x, y, e);
            }
        }

        private void BotonObstaculo_Click(object sender, EventArgs e)
        {
            this.boton = 0;
            SeleccionarBoton();
        }

        private void BotonAvatar_Click(object sender, EventArgs e)
        {
            this.boton = 1;
            SeleccionarBoton();
        }

        private void BotonCasa_Click(object sender, EventArgs e)
        {
            this.boton = 2;
            SeleccionarBoton();
        }
    }
}