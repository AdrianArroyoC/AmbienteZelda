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
		private int UltimoMovimiento { get; set; }
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
			UltimoMovimiento = 0;
		}

		public void Mover(PreviewKeyDownEventArgs e) 
		{
			if (e.KeyData == Keys.Up) 
			{
				MoverArriba();
			}
			if (e.KeyData == Keys.Down) 
			{
				MoverAbajo();
			}
			if (e.KeyData == Keys.Left)
			{
				MoverIzquierda();
			}
			if (e.KeyData == Keys.Right) 
			{
				MoverDerecha();
			}
			Colocar();
		}

		private bool MoverArriba(bool verificarAmbienteAvatar = false)
		{
			if (Y > 0 && (VerificarMovimiento(X, Y - 1) || VerificarEnCasa(X, Y - 1)))
			{
				if (verificarAmbienteAvatar && AmbienteAvatar[X, Y - 1] < 0)
				{
					return false;
				}
				Y -= 1;
				UltimoMovimiento = 1;
				return true;
			}
			return false;
		}

		private bool MoverAbajo(bool verificarAmbienteAvatar = false)
		{
			if (Y < Ventana.Ambiente.GetLength(1) - 1 && (VerificarMovimiento(X, Y + 1) || VerificarEnCasa(X, Y + 1)))
			{
				if (verificarAmbienteAvatar && AmbienteAvatar[X, Y + 1] < 0)
				{
					return false;
				}
				Y += 1;
				UltimoMovimiento = 2;
				return true;
			}
			return false;
		}

		private bool MoverIzquierda(bool verificarAmbienteAvatar = false)
		{
			if (X > 0 && (VerificarMovimiento(X - 1, Y) || VerificarEnCasa(X - 1, Y)))
			{
				if (verificarAmbienteAvatar && AmbienteAvatar[X - 1, Y] < 0)
				{
					return false;
				}
				X -= 1;
				UltimoMovimiento = 3;
				return true;
			}
			return false;
		}

		private bool MoverDerecha(bool verificarAmbienteAvatar = false)
		{
			if (X < Ventana.Ambiente.GetLength(0) - 1 && (VerificarMovimiento(X + 1, Y) || VerificarEnCasa(X + 1, Y)))
			{
				if (verificarAmbienteAvatar && AmbienteAvatar[X + 1, Y] < 0)
				{
					return false;
				}
				X += 1;
				UltimoMovimiento = 4;
				return true;
			}
			return false;
		}

		private bool VerificarMovimiento(int x, int y)
        {
            if  (Ventana.Ambiente[x, y].Image == null)
            {
                return true;
            }
			return false;
        }

		private bool VerificarEnCasa(int x, int y)
		{
			if ((x == Ventana.Casa.X && y == Ventana.Casa.Y))
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

		public int[] CalcularLineaBresenham()
		{
			int[] resultados = new int[9];
			resultados[0] = Ventana.Casa.X - X; //dX
			resultados[1] = Ventana.Casa.Y - Y; //dY
			//Incrementos en las secciones con avance inclinado
			if (resultados[0] >= 0)
			{
				resultados[2] = 1; //incXi
			}
			else
			{
				resultados[0] = -resultados[0];
				resultados[2] = -1;
			}
			if (resultados[1] >= 0)
			{
				resultados[3] = 1; //incYi
			}
			else
			{
				resultados[1] = -resultados[1];
				resultados[3] = -1;
			}
			//Incrementos en las secciones de avance recto
			if (resultados[0] >= resultados[1])
			{
				resultados[5] = 0; //incYr
				resultados[4] = resultados[2]; //incXr
			}
			else
			{
				resultados[4] = 0;
				resultados[5] = resultados[3];
				//Intercambio
				int k = resultados[0];
				resultados[0] = resultados[1];
				resultados[1] = k;
			}
			//Inicializar valores
			resultados[6] = 2 * resultados[1]; //avR
			resultados[7] = resultados[6] - resultados[0]; //av
			resultados[8] = resultados[7] - resultados[0]; //avI
			return resultados;
		}

		public async Task LineaBresenhamAsync() 
		{
			CoordenadasAuxiliares = new int[4][];
			//Variables de distancia
			int dX, dY, incXi, incYi, incXr, incYr, avR, av, avI;
			int[] variablesDistancia = CalcularLineaBresenham();
			dX = variablesDistancia[0];
			dY = variablesDistancia[1];
			incXi = variablesDistancia[2];
			incYi = variablesDistancia[3];
			incXr = variablesDistancia[4];
			incYr = variablesDistancia[5];
			avR = variablesDistancia[6];
			av = variablesDistancia[7];
			avI = variablesDistancia[8];
			//Ciclo para el trazado de las lineas
			while (!VerificarEnCasa(X, Y))
			{
				Colocar();
				await Task.Delay(250);
				ReconocerAmbiente(X, Y, true);
				await Task.Run(QuitarAuxiliaresAsync);
				ContadorPasos++;
				AmbienteAvatar[X, Y] = ContadorPasos;
				await Task.Run(QuitarAsync);
				if (av >= 0 && (VerificarMovimiento(X + incXi, Y + incYi) || VerificarEnCasa(X + incXi, Y + incYi)))
				{
					X = X + incXi;
					Y = Y + incYi;
					av = av + avI;
					UltimoMovimiento = 0;
				}
				else if (VerificarMovimiento(X + incXr, Y + incYr) || VerificarEnCasa(X + incXr, Y + incYr))
				{
					X = X + incXr;
					Y = Y + incYr;
					av = av + avR;
					UltimoMovimiento = 0;
				}
				else if (Mover(dX, dY))
				{
					//ReCalcular
					variablesDistancia = CalcularLineaBresenham();
					dX = variablesDistancia[0];
					dY = variablesDistancia[1];
					incXi = variablesDistancia[2];
					incYi = variablesDistancia[3];
					incXr = variablesDistancia[4];
					incYr = variablesDistancia[5];
					avR = variablesDistancia[6];
					av = variablesDistancia[7];
					avI = variablesDistancia[8];
				}
				else
				{
					MessageBox.Show("Ya no se puede avanzar");
					Colocar();
					return;
				}
			}
			EnCasa = true;
		}

		public bool Mover(int dX, int dY)
		{
			//Elegimos si el movimiento será en X o en Y (La mayor distancia)
			if (Math.Abs(dX) >= Math.Abs(dY)) //En Y
			{
				//Si es para arriba o abajo
				if (dY > 0 && MoverAbajo(true)) //Para abajo
				{
					return true;
				}
				//Si no fue para abajo hacia arriba
				if (MoverArriba(true))
				{
					UltimoMovimiento = 1;
					Y -= 1;
					return true;
				}
			}
			//Si no fue en Y en X
			//Para la derecha
			if (dX > 0 && MoverDerecha(true))
			{
				UltimoMovimiento = 4;
				X += 1;
				return true;
			}
			//Si no fue para la derecha hacia la izquierda
			if (MoverIzquierda(true))
			{
				UltimoMovimiento = 3;
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
			if (y > 0) //!(x == X && Y == y - 1)
			{
				if (VerificarMovimiento(x, y - 1))
				{
					if (AmbienteAvatar[x, y - 1] == -2)
					{
						AmbienteAvatar[x, y - 1] = 0;
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
			if (y < Ventana.Ambiente.GetLength(1) - 1) //!(x == X && Y == y + 1)
			{
				if (VerificarMovimiento(x, y + 1))
				{
					if (AmbienteAvatar[x, y + 1] == -2)
					{
						AmbienteAvatar[x, y + 1] = 0;
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
			if (x > 0) //!(x - 1 == X && Y == y)
			{
				if (VerificarMovimiento(x - 1, y))
				{
					if (AmbienteAvatar[x - 1, y] == -2)
					{
						AmbienteAvatar[x - 1, y] = 0;
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
			if (x < Ventana.Ambiente.GetLength(0) - 1)  //!(x + 1 == X && Y == y)
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