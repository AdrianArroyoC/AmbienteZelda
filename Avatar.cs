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
		private string RutaImagenAux { get; set; }
		private int[,] AmbienteAvatar { get; set; }
		private int[][] CoordenadasAuxiliares1 { get; set; }
		public int[][,] PruebasReconocimientoRandom { get; set; }
		private ProgressBar BarraProgreso { get; set; }
		private Label Progreso { get; set; }

		public Avatar(int x, int y, string rutaImagen, string rutaImagenAux, int[,] ambienteAvatar, ProgressBar barraProgreso, Label progreso) : base(x, y, rutaImagen)
		{
			RutaImagenAux = rutaImagenAux;
			AmbienteAvatar = ambienteAvatar;
			BarraProgreso = barraProgreso;
			Progreso = progreso;
		}

		public bool Mover(int tecla) 
		{
			bool seMovio = false;
			if (tecla == 0) 
			{
				seMovio = MoverArriba();
			}
			else if (tecla == 1)
			{
				seMovio = MoverDerecha();
			}
			else if (tecla == 2) 
			{
				seMovio = MoverAbajo();
			}
			else
			{
				seMovio = MoverIzquierda();
			}
			Colocar();
			return seMovio;
		}

		private bool MoverArriba()
		{
			if (Y > 0 && (VerificarMovimiento(X, Y - 1) || VerificarEnCasa(X, Y - 1)))
			{
				Y -= 1;
				return true;
			}
			return false;
		}

		private bool MoverDerecha()
		{
			if (X < Ventana.Ambiente.GetLength(0) - 1 && (VerificarMovimiento(X + 1, Y) || VerificarEnCasa(X + 1, Y)))
			{
				X += 1;
				return true;
			}
			return false;
		}

		private bool MoverAbajo()
		{
			if (Y < Ventana.Ambiente.GetLength(1) - 1 && (VerificarMovimiento(X, Y + 1) || VerificarEnCasa(X, Y + 1)))
			{
				Y += 1;
				return true;
			}
			return false;
		}

		private bool MoverIzquierda()
		{
			if (X > 0 && (VerificarMovimiento(X - 1, Y) || VerificarEnCasa(X - 1, Y)))
			{
				X -= 1;
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
				EnCasa = true;
				return EnCasa;
			}
			return false;
		}

		private bool VerificarMovimientoCasa(int x, int y)
		{
			if (VerificarMovimiento(x, y) || VerificarEnCasa(x, y))
			{
				return true;
			}
			return false;
		}

		private async Task QuitarAsync()
		{
			await Task.Delay(250);
			Ventana.Ambiente[X, Y].Image = null;
		}

		private int[] CalcularLineaBresenham()
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

		public async Task LineaBresenhamAsync(bool reconocimiento = false) 
		{
			CoordenadasAuxiliares1 = new int[4][];
			bool lineaRecalculada = false;
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
				if (!lineaRecalculada)
				{
					Colocar();
					await Task.Delay(250);
					if (reconocimiento)
					{
						ReconocerPosicion();
						await Task.Run(ObtenerReconocerCoordenadasAuxiliares);
					}
					await Task.Run(QuitarAsync);
				}
				if (av >= 0 && (VerificarMovimiento(X + incXi, Y + incYi) || VerificarEnCasa(X + incXi, Y + incYi))) //Inclinado
				{
					if (VerificarMovimientoCasa(X + incXi, Y) && VerificarMovimientoCasa(X + incXi, Y + incYi))
					{
						X+= incXi;
						Colocar();
						await Task.Delay(250);
						if (reconocimiento)
						{
							ReconocerPosicion();
							await Task.Run(ObtenerReconocerCoordenadasAuxiliares);
						}
						await Task.Run(QuitarAsync);
						Y += incYi;
						av = av + avI;
						lineaRecalculada = false;
					}
					else if (VerificarMovimientoCasa(X, Y + incYi) && VerificarMovimientoCasa(X + incXi, Y + incYi))
					{
						Y+= incYi;
						Colocar();
						await Task.Delay(250);
						if (reconocimiento)
						{
							ReconocerPosicion();
							await Task.Run(ObtenerReconocerCoordenadasAuxiliares);
						}
						await Task.Run(QuitarAsync);
						X += incXi;
						av = av + avI;
						lineaRecalculada = false;
					}
					else
					{
						Colocar();
						MessageBox.Show("Ya no se puede avanzar");
						return;
					}
				}
				else if (VerificarMovimientoCasa(X + incXr, Y + incYr)) //Recto
				{
					X+= incXr;
					Y+= incYr;
					av = av + avR;
					lineaRecalculada = false;
				}
				/*else if (!lineaRecalculada) //Recalcular Linea Recta 
				{
					//Metodo para utilizar el reconocimiento
					//Revisara los valores a sus lados y se movera aleatoriamente a los valores menores disponibles
					//Cuando se mueve tratará con línea recta y si se puede la hará y saldrá de aqui pero si no seguirá moviendose
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
					lineaRecalculada = true;
				}*/
				else
				{
					Colocar();
					MessageBox.Show("Ya no se puede avanzar");
					return;
				}
			}
			ImprimirAmbiente();
		}

		private void ReconocerPosicion()
		{
			if (AmbienteAvatar[X, Y] <= 0)
			{
				AmbienteAvatar[X, Y] = 1;
			}
			else
			{
				AmbienteAvatar[X, Y]++;
			}
		}

		private async Task ObtenerReconocerCoordenadasAuxiliares()
		{
			ObtenerCoordenadasAuxiliares(X, Y, new bool[]{ true, true, true, true, true });
			ReconocerCoordenadasAuxiliares();
			int[][] coordenadasAuxiliares2 = new int[4][];
			for (int i = 0; i < coordenadasAuxiliares2.Length; i++)
			{
				coordenadasAuxiliares2[i] = CoordenadasAuxiliares1[i];
			}
			await Task.Run(QuitarAuxiliaresAsync);
			bool[] direccionesAuxiliares = new bool[]{ false, false, false, false, false };
			for (int i = 0; i < coordenadasAuxiliares2.Length; i++)
			{
				if (coordenadasAuxiliares2[i] != null)
				{
					direccionesAuxiliares[i] = true;
					ObtenerCoordenadasAuxiliares(coordenadasAuxiliares2[i][0], coordenadasAuxiliares2[i][1], direccionesAuxiliares);
					direccionesAuxiliares[i] = false;
				}
			}
			ReconocerCoordenadasAuxiliares();
			await Task.Run(QuitarAuxiliaresAsync);
			for (int i = 0; i < coordenadasAuxiliares2.Length; i++)
			{
				if (coordenadasAuxiliares2[i] != null)
				{
					direccionesAuxiliares[i + 1] = true;
					ObtenerCoordenadasAuxiliares(coordenadasAuxiliares2[i][0], coordenadasAuxiliares2[i][1], direccionesAuxiliares);
					direccionesAuxiliares[i + 1] = false;
				}
			}
			ReconocerCoordenadasAuxiliares();
			await Task.Run(QuitarAuxiliaresAsync);
		}

		public async Task QuitarAuxiliaresAsync()
		{
			await Task.Delay(250);
			for (int i = 0; i < CoordenadasAuxiliares1.Length; i++)
			{
				if (CoordenadasAuxiliares1[i] != null)
				{
					Ventana.Ambiente[CoordenadasAuxiliares1[i][0], CoordenadasAuxiliares1[i][1]].Image = null;
					CoordenadasAuxiliares1[i] = null; 
				}
			}
		}

		private void ObtenerCoordenadasAuxiliares(int x, int y, bool[] dir)
		{
			if (y > 0 && VerificarMovimiento(x, y - 1) && (dir[0] || dir[4])) //arriba 
			{
				CoordenadasAuxiliares1[0] = new int[] { x, y - 1 };
			}
			if (x < Ventana.Ambiente.GetLength(0) - 1 && VerificarMovimiento(x + 1, y) && dir[1]) //derecha
			{
				CoordenadasAuxiliares1[1] = new int[] { x + 1, y };
			}
			if (y < Ventana.Ambiente.GetLength(1) - 1 && VerificarMovimiento(x, y + 1) && dir[2]) //abajo
			{
				CoordenadasAuxiliares1[2] = new int[] { x, y + 1 };				
			}
			if (x > 0 && VerificarMovimiento(x - 1, y) && dir[3]) //izquierda
			{
				CoordenadasAuxiliares1[3] = new int[] { x - 1, y };
			}
		}

		private void ReconocerCoordenadasAuxiliares()
		{
			for (int i = 0; i < CoordenadasAuxiliares1.Length; i++)
			{
				if (CoordenadasAuxiliares1[i] != null)
				{
					int x = CoordenadasAuxiliares1[i][0];
					int y = CoordenadasAuxiliares1[i][1];
					if (AmbienteAvatar[x, y] == -2 || AmbienteAvatar[x, y] >= 0) 
					{
						if (AmbienteAvatar[x, y] != 1)
						{
							AmbienteAvatar[x, y] = 0;
						}
						Ventana.Ambiente[x, y].Image = Image.FromFile(RutaImagenAux);
					}
					else
					{
						AmbienteAvatar[x, y] = -1;
					}
				}
			}
		}

		public async Task ReconocimientoRandom(int visibles, int ocultas)
		{
			int x = X;
			int y = Y;
			int totales = visibles + ocultas;
			BarraProgreso.Maximum = totales;
			Progreso.Text = "0/" + totales.ToString();
			PruebasReconocimientoRandom = new int[totales][,];
			Random random = new Random();
			for (int i = 0; i < totales; i++)
			{
				PruebasReconocimientoRandom[i] = new int[AmbienteAvatar.GetLength(0), AmbienteAvatar.GetLength(1)]; //Modifique aqui el 1 era 0
				while (!EnCasa)
				{
					Ventana.Ambiente[X, Y].Image = null;
					if (Mover(random.Next(0, 4)))
					{
						if (i < visibles)
						{
							Colocar();
							await Task.Delay(100);
						}
						PruebasReconocimientoRandom[i][X, Y]++;
					}
				}
				EnCasa = false;
				X = x;
				Y = y;
				Colocar();
				Ventana.Casa.Colocar();
				BarraProgreso.PerformStep();
				await Task.Delay(50); //
				Progreso.Text = (i + 1).ToString() + "/" + totales;
			}
		}

		private void ImprimirAmbiente()
		{
			for (int j = 0; j < AmbienteAvatar.GetLength(1); j++)
			{
				string linea = "";
				for (int i = 0; i < AmbienteAvatar.GetLength(0); i++)
				{
				
					if (AmbienteAvatar[i, j].ToString().Length == 1)
					{
						linea += "|0" + AmbienteAvatar[i, j].ToString();
					}
					else
					{
						linea += "|" + AmbienteAvatar[i, j].ToString();
					}					
				}
				System.Diagnostics.Debug.WriteLine(linea);
			}
		}
	}
}