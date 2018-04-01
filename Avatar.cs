using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbienteZelda
{
	[Serializable]
    public class Avatar : Objeto
    {
		public bool EnCasa { get; set; }
		private int ContadorPasos { get; set; }
		private string RutaImagenAux1 { get; set; }
		private string RutaImagenAux2 { get; set; }
		private int[,] AmbienteAvatar { get; set; }
		private int[][] CoordenadasAuxiliares { get; set; }

		public Avatar(int x, int y, string rutaImagen, string rutaImagenAux1, string rutaImagenAux2, int[,] ambienteAvatar) : base(x, y, rutaImagen)
		{
			RutaImagenAux1 = rutaImagenAux1;
			RutaImagenAux2 = rutaImagenAux2;
			AmbienteAvatar = ambienteAvatar;
			ContadorPasos = 0;
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
				return true;
			}
			return false;
        }

		public async Task QuitarAsync()
		{
			await Task.Delay(1000);
			Ventana.Ambiente[X, Y].Image = null;
		}

		public async Task LineaBresenhamAsync() 
		{
			CoordenadasAuxiliares = new int[4][];
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
				Colocar();
				ReconocerAmbiente(X, Y, true);
				await Task.Run(QuitarAuxiliaresAsync);
				ContadorPasos++;
				AmbienteAvatar[X, Y] = ContadorPasos;
				if (av >= 0 && VerificarMovimiento(X + incXi, Y + incYi))
				{
					await Task.Run(QuitarAsync);
					X = X + incXi;
					Y = Y + incYi;
					av = av + avI;
					AmbienteAvatar[X, Y] = 0;
				}
				else if (VerificarMovimiento(X + incXr, Y + incYr))
				{
					await Task.Run(QuitarAsync);
					X = X + incXr;
					Y = Y + incYr;
					av = av + avR;
				}
				else 
				{
					//Moverse hacia uno de los espacios contiguos libres 
					await Task.Run(QuitarAsync);
					if (Mover())
					{
						await LineaBresenhamAsync(); //Volvemos a calcular el recorrido
					}
					else
					{
						MessageBox.Show("Ya no se puede avanzar");
						return;
					}
				}
			}
			EnCasa = true;
		}

		public bool Mover()
		{
			int dX = (Ventana.Casa.X - X);
			int dY = (Ventana.Casa.Y - Y);
			//Elegimos si el movimiento será en X o en Y (La mayor distancia)
			if (Math.Abs(dX) >= Math.Abs(dY)) //En Y
			{
				//Si es para arriba o abajo
				if (dY > 0 && AmbienteAvatar[X, Y + 1] == 0) //Para abajo
				{
					Y += 1;
					return true;
				}
				//Si no fue para abajo hacia arriba
				if (AmbienteAvatar[X, Y - 1] == 0)
				{
					Y -= 1;
					return true;
				}
			}
			//Si no fue en Y en X
			//Para la derecha
			if (dX > 0 && AmbienteAvatar[X + 1, Y] == 0)
			{
				X += 1;
				return true;
			}
			//Si no fue para la derecha hacia la izquierda
			if (AmbienteAvatar[X - 1, Y] == 0)
			{
				X -= 1;
				return true;
			}
			return false;
		}

		public async Task QuitarAuxiliaresAsync()
		{
			await Task.Delay(1000);
			for (int i = 0; i < CoordenadasAuxiliares.Length; i++)
			{
				if (CoordenadasAuxiliares[i] != null)
				{
					Ventana.Ambiente[CoordenadasAuxiliares[i][0], CoordenadasAuxiliares[i][1]].Image = null;
				}
			}
		}

		public void ReconocerAmbiente(int x, int y, bool imagen = false)
		{
			if (y > 0 && !(x == X && Y == y - 1))
			{
				if (VerificarMovimiento(x, y - 1))
				{
					if (AmbienteAvatar[x + 1, y] == -2)
					{
						AmbienteAvatar[x + 1, y] = 0;
					}
					if (imagen)
					{
						Ventana.Ambiente[x, y - 1].Image = Image.FromFile(RutaImagenAux1);
						ReconocerAmbiente(x, y - 1);
						CoordenadasAuxiliares[0] = new int[] { x, y - 1 };
					}
				}
				else 
				{
					AmbienteAvatar[x, y - 1] = -1;
				}
			}
			if (y < Ventana.Ambiente.GetLength(1) - 1 && !(x == X && Y == y + 1))
			{
				if (VerificarMovimiento(x, y + 1))
				{
					if (AmbienteAvatar[x + 1, y] == -2)
					{
						AmbienteAvatar[x + 1, y] = 0;
					}
					if (imagen)
					{
						Ventana.Ambiente[x, y + 1].Image = Image.FromFile(RutaImagenAux1);
						ReconocerAmbiente(x, y + 1);
						CoordenadasAuxiliares[1] = new int[] { x, y + 1 };
					}
				}
				else
				{
					AmbienteAvatar[x, y + 1] = -1;
				}
			}
			if (x > 0 && !(x - 1 == X && Y == y))
			{
				if (VerificarMovimiento(x - 1, y))
				{
					if (AmbienteAvatar[x + 1, y] == -2)
					{
						AmbienteAvatar[x + 1, y] = 0;
					}
					if (imagen)
					{
						Ventana.Ambiente[x - 1, y].Image = Image.FromFile(RutaImagenAux2);
						ReconocerAmbiente(x - 1, y);
						CoordenadasAuxiliares[2] = new int[] { x - 1, y };
					}
				}
				else 
				{
					AmbienteAvatar[x - 1, y] = -1;
				}
			}
			if (x < Ventana.Ambiente.GetLength(0) - 1 && !(x + 1 == X && Y == y))
			{
				if (VerificarMovimiento(x + 1, y))
				{
					if (AmbienteAvatar[x + 1, y] == -2)
					{
						AmbienteAvatar[x + 1, y] = 0;
					}
					if (imagen)
					{
						Ventana.Ambiente[x + 1, y].Image = Image.FromFile(RutaImagenAux2);
						ReconocerAmbiente(x + 1, y);
						CoordenadasAuxiliares[3] = new int[] { x + 1, y };
					}
				}
				else
				{
					AmbienteAvatar[x + 1, y] = -1;
				}
			}
		}
	}
}