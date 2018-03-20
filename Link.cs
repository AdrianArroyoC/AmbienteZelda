using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbienteZelda
{
    class Link
    {	
        private PictureBox[,] Ambiente { get; set; } 
        private int[] CoordenadasCasa { get; set; } 
		private string RutaImagen { get; set; } 
		public bool EnCasa { get; set; } 

		public Link(string rutaImagen)
		{
			RutaImagen = rutaImagen;
			EnCasa = false;
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
			Ambiente[coordenadas[0], coordenadas[1]].Image = Image.FromFile(RutaImagen);
			return coordenadas;
        }

		public void ReconocerAmbiente(PictureBox[,] ambiente)
		{
			Ambiente = ambiente;
		}

		public void ReconocerCasa(int x, int y)
		{
			CoordenadasCasa = new int[2];
			CoordenadasCasa[0] = x;
			CoordenadasCasa[1] = y;
		}

		private bool VerificarMovimiento(int x, int y)
        {
            if  (Ambiente[x, y].Image == null)
            {
                return true;
            } 
			if (x == CoordenadasCasa[0] && y == CoordenadasCasa[1])
			{
				EnCasa = true;
				return EnCasa;
			}
			return false;
        }

		public void LineaBresenham(int x1, int y1, int x2, int y2)
		{
			int[] coordenadas = new int[2];
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
			//int x = x1;
			//int y = y1;
			coordenadas[0] = x1;
			coordenadas[1] = y1;
			int avR = 2 * dY;
			int av = avR - dX;
			int avI = av - dX;
			//Ciclo para el trazado de las lineas
			while (coordenadas[0] != x2 || coordenadas[1] != y2)
			{
				//Mover(coordenadas[0], coordenadas[1]);
				//Application.DoEvents();
				//Thread.Sleep(1000);
				Mover(coordenadas[0], coordenadas[1]);
				Ambiente[coordenadas[0], coordenadas[1]].Image = null;
				if (av >= 0 && VerificarMovimiento(coordenadas[0] + incXi, coordenadas[1] + incYi))
				{
					coordenadas[0] = coordenadas[0] + incXi;
					coordenadas[1] = coordenadas[1] + incYi;
					av = av + avI;
				}
				else if (VerificarMovimiento(coordenadas[0] + incXr, coordenadas[1] + incYr))
				{
					coordenadas[0] = coordenadas[0] + incXr;
					coordenadas[1] = coordenadas[1] + incYr;
					av = av + avR;
				}
				else 
				{
					MessageBox.Show("Ya no se puede avanzar");
					break;
				}
			}
			EnCasa = true;
		}
	}
}
