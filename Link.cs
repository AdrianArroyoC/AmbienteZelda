using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbienteZelda
{
    class Link
    {
        private PictureBox[,] ambiente;
        private int[] coordenadasCasa = new int[2];
        private bool enCasa = false;

        public Link(PictureBox[,] ambiente, int x, int y)
        {
            Mover(ambiente, x, y);
        }

        public int[] Mover(PictureBox[,] ambiente, int x, int y, KeyEventArgs e = null)
        {
            this.ambiente = ambiente;
            int[] coordenadas = {x, y};
            if (e != null)
            {
                if (e.KeyData == Keys.Up && y > 0 && VerificarMovimiento(coordenadas[0], coordenadas[1] - 1))
                {
                    coordenadas[1] -= 1;
                }
                if (e.KeyData == Keys.Down && y < this.ambiente.GetLength(0) - 1 && VerificarMovimiento(coordenadas[0], coordenadas[1] + 1))
                {
                    coordenadas[1] += 1;
                }
                if (e.KeyData == Keys.Left && x > 0 && VerificarMovimiento(coordenadas[0] - 1, coordenadas[1]))
                {
                    coordenadas[0] -= 1;
                }
                if (e.KeyData == Keys.Right && x < this.ambiente.GetLength(0) - 1 && VerificarMovimiento(coordenadas[0] + 1, coordenadas[1]))
                {
                    coordenadas[0] += 1;
                }
            }
            Cargar(ambiente[coordenadas[0], coordenadas[1]], this.ambiente[x, y]);
            return coordenadas;
        }

        private void Cargar(PictureBox nuevo, PictureBox anterior = null)
        {
            if (anterior != null)
            {
                anterior.Image = null;
            }
            if (!enCasa)
            {
                nuevo.Image = Image.FromFile("C:\\Users\\adria\\source\\repos\\AmbienteZelda\\AmbienteZelda\\src\\Link.png");
            }
        }

        private bool VerificarMovimiento(int x, int y)
        {
            if (coordenadasCasa != null && coordenadasCasa[0] == x && coordenadasCasa[y] == y)
            {
                this.enCasa = true;
                return true;
            }
            if  (this.ambiente[x, y].Image == null)
            {
                return true;
            }
            return false;
        }

        public void Reconocer(int x, int y)
        {
            this.coordenadasCasa[0] = x;
            this.coordenadasCasa[1] = y;
        }
    }
}
