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
        private PictureBox[,] Ambiente {get; set;}
        private int[] CoordenadasCasa {get; set;}

		public Link(PictureBox[,] ambiente)
		{
			this.Ambiente = ambiente;
			CoordenadasCasa = new int[2];
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
                if (e.KeyData == Keys.Down && y < Ambiente.GetLength(1) - 1 && VerificarMovimiento(coordenadas[0], coordenadas[1] + 1))
                {
                    coordenadas[1] += 1;
                }
                if (e.KeyData == Keys.Left && x > 0 && VerificarMovimiento(coordenadas[0] - 1, coordenadas[1]))
                {
                    coordenadas[0] -= 1;
                }
                if (e.KeyData == Keys.Right && x < Ambiente.GetLength(0) - 1 && VerificarMovimiento(coordenadas[0] + 1, coordenadas[1]))
                {
                    coordenadas[0] += 1;
                }
            }
            return coordenadas;
        }

		public void ReconocerAmbiente(PictureBox[,] ambiente)
		{
			Ambiente = ambiente;
		}

		public void ReconocerCasa(int x, int y)
		{
			CoordenadasCasa[0] = x;
			CoordenadasCasa[1] = y;
		}

		private bool VerificarMovimiento(int x, int y)
        {
            if  (Ambiente[x, y].Image == null || (x == CoordenadasCasa[0] && y == CoordenadasCasa[1]))
            {
                return true;
            }
            return false;
        }
    }
}
