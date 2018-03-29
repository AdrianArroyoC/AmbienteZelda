using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbienteZelda
{
	[Serializable]
    public class Avatar : Objeto
    {
		public bool EnCasa { get; set; }
		
		public Avatar(int x, int y, string rutaImagen) : base(x, y, rutaImagen)
		{
			//EnCasa = false; //Creo que es falso por defecto
		}

		public void Mover(PreviewKeyDownEventArgs e) 
		{
			if (e.KeyData == Keys.Up && Y > 0 && VerificarMovimiento(X, Y - 1)) 
			{
				Y -= 1; //MoverArriba()
			}
			if (e.KeyData == Keys.Down && Y < Ventana.Ambiente.GetLength(1) - 1 && VerificarMovimiento(X, Y + 1)) 
			{
				Y += 1; //MoverAbajo()
			}
			if (e.KeyData == Keys.Left && X > 0 && VerificarMovimiento(X - 1, Y))
			{
				X -= 1; //MoverIzquierda()
			}
			if (e.KeyData == Keys.Right && X < Ventana.Ambiente.GetLength(0) - 1 && VerificarMovimiento(X + 1, Y)) 
			{
				X += 1; //MoverDerecha()
			}
			Colocar();
		}

		private bool VerificarMovimiento(int x, int y)
        {
            if  (Ventana.Ambiente[x, y].Image == null)
            {
                return true;
            } 
			if (x == Ventana.Casa.X && y == Ventana.Casa.Y)
			{
				//
				return true;
			}
			return false;
        }

		public async Task QuitarAsync()
		{
			await Task.Delay(1000);
			Ventana.Ambiente[X, Y].Image = null;
		}

		//public async //Task LineaBresenhamAsync()
		public async void LineaBresenhamAsync()
		{
			//Variables de distancia
			int dX = (Ventana.Casa.X - X);
			int dY = (Ventana.Casa.Y - Y);
			int incXi, incYi, incXr, incYr;
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
			int avR = 2 * dY;
			int av = avR - dX;
			int avI = av - dX;
			//Ciclo para el trazado de las lineas
			while (X != Ventana.Casa.X && Y != Ventana.Casa.Y)
			{
				Colocar(); //
				if (av >= 0 && VerificarMovimiento(X + incXi, Y + incYi))
				{
					await Task.Run(QuitarAsync);
					X = X + incXi;
					Y = Y + incYi;
					av = av + avI;
				}
				else if (VerificarMovimiento(X + incXr, Y + incYr))
				{
					await Task.Run(QuitarAsync);
					Task.WaitAll();
					X = X + incXr;
					Y = Y + incYr;
					av = av + avR;
				}
				else 
				{
					MessageBox.Show("Ya no se puede avanzar");
					return;
				}
			}
			EnCasa = true;
		}
	}
}