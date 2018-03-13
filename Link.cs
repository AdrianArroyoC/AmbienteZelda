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

		//public void Mover(int x, int y, PreviewKeyDownEventArgs e = null)
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
			Ambiente[x, y].Image = null;
			if (CoordenadasCasa != null && EncontroCasa(x, CoordenadasCasa[0], y, CoordenadasCasa[1]))
			{
				MessageBox.Show(CoordenadasCasa[0].ToString() + CoordenadasCasa[1].ToString());
				coordenadas[0] = 101;
				coordenadas[1] = 101;
			}
			else
			{
				Ambiente[coordenadas[0], coordenadas[1]].Image = Image.FromFile("D:\\Dropbox\\Maestria\\Cuarto semestre\\Patrones de diseño y frameworks\\AmbienteZelda\\AmbienteZelda\\src\\Link.jpg");
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

		public bool EncontroCasa(int x1, int y1, int x2, int y2)
		{
			if (x1 == x2 && y1 == y2)
			{
				MessageBox.Show("Game Over");
				return true;
			}
			return false;
		}

		public void LineaBresenham(int x1, int y1, int x2, int y2)
		{
			//Variables de distancia
			int dX = (x2 - x1);
			int dY = (y2 - y1);
			int incXi;
			int incYi;
			int incXr;
			int incYr;
			//Incrementos en las secciones con avance inclinado
			if (dX >= 0)
			{
				incXi = 1;
			}
			else
			{
				dX = -dX;
				incXi = -1;
			}
			if (dY >= 0)
			{
				incYi = 1;
			}
			else
			{
				dY = -dY;
				incYi = -1;
			}
			//Incrementos en las secciones de avance recto
			if (dX >= dY)
			{
				incYr = 0;
				incXr = incXi;
			}
			else
			{
				incXr = 0;
				incYr = incYi;
				//Intercambio
				int k = dX;
				dX = dY;
				dY = k;
			}
			//Inicializar valores
			int x = x1;
			int y = y1;
			int avR = 2 * dY;
			int av = avR - dX;
			int avI = av - dX;
			//Ciclo para el trazado de las lineas
			while (EncontroCasa(x, x2, y, y2))
			{
				if (av >= 0)
				{
					x = x + incXi;
					y = y + incYi;
					av = av + avI;
				}
				else
				{
					x = x + incXr;
					y = y + incYr;
					av = av + avR;
				}
				Mover(x, y);
			}
		}
    }
}
