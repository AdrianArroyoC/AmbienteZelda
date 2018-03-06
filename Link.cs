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

		public Link(PictureBox[,] ambiente)
		{
			this.ambiente = ambiente;
		}

        public int[] Mover(int x, int y, PreviewKeyDownEventArgs e = null)
        {
            int[] coordenadas = {x, y};
            if (e != null)
            {
                if (e.KeyData == Keys.Up && y > 0 && VerificarMovimiento(coordenadas[0], coordenadas[1] - 1))
                {
                    coordenadas[1] -= 1;
                }
                if (e.KeyData == Keys.Down && y < this.ambiente.GetLength(1) - 1 && VerificarMovimiento(coordenadas[0], coordenadas[1] + 1))
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
            return coordenadas;
        }

		public void ReconocerAmbiente(PictureBox[,] ambiente)
		{
			this.ambiente = ambiente;
		}

		public void ReconocerCasa(int x, int y)
		{
			coordenadasCasa[0] = x;
			coordenadasCasa[1] = y;
		}

		private bool VerificarMovimiento(int x, int y)
        {
            if  (ambiente[x, y].Image == null || (x == coordenadasCasa[0] && y == coordenadasCasa[1]))
            {
                return true;
            }
            return false;
        }

		//Metodo para reconocer la llegada a la casa y detener el juego y quitar eso de la Ventana
		//Clase padre para objetos con el metodo pintar y generar herencia
    }
}
