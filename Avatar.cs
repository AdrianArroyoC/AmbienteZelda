using System;
using System.Collections.Generic;
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
		public int[] PasosPruebasReconocimientoRandom { get; set; }
		private Random random = new Random();

		public Avatar(int x, int y, string rutaImagen, string rutaImagenAux, int[,] ambienteAvatar) : base(x, y, rutaImagen)
		{
			RutaImagenAux = rutaImagenAux;
			AmbienteAvatar = ambienteAvatar;
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
			int[] movimientos = null;
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
				if (reconocimiento)
				{
					ReconocerPosicion();
					await Task.Run(ObtenerReconocerCoordenadasAuxiliares);
				}
				await Task.Run(QuitarAsync);
				movimientos = MovimientosDisponibles();
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
					}
					else
					{
						Colocar();
						MessageBox.Show("Ya no se puede avanzar");
						return;
					}
				}
				else if (VerificarMovimiento(X + incXr, Y + incYr) || VerificarEnCasa(X + incXr, Y + incYr)) //Recto
				{
					X+= incXr;
					Y+= incYr;
					av = av + avR;
				}
				else if (movimientos != null && reconocimiento)
				{
					int movimiento = movimientos[random.Next(0, movimientos.Length)];
					Mover(movimiento);
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
					Colocar();
					MessageBox.Show("Ya no se puede avanzar");
					return;
				}
			}
			ImprimirAmbiente();
		}
		
		private int MenorValor(int valor, int x, int y)
		{
			if (valor == -2 || AmbienteAvatar[x, y] < valor)
			{
				return AmbienteAvatar[x, y];
			}
			else
			{
				return valor;
			}
		}

		private int[] MovimientosDisponibles()
		{
			int menorValor = -2;
			List<int> movimientos = new List<int>();
			if (Y - 1 > 0 && VerificarMovimiento(X, Y - 1))
			{
				menorValor = MenorValor(menorValor, X, Y - 1);
				movimientos.Add(0);
			}
			if (X + 1 < Ventana.Ambiente.GetLength(0) - 1 && VerificarMovimiento(X + 1, Y))
			{
				menorValor = MenorValor(menorValor, X + 1, Y);
				movimientos.Add(1);
			}
			if (Y + 1 < Ventana.Ambiente.GetLength(1) - 1 && VerificarMovimiento(X, Y + 1))
			{
				menorValor = MenorValor(menorValor, X, Y + 1);
				movimientos.Add(2);
			}
			if (X - 1 > 0 && VerificarMovimiento(X - 1, Y))
			{
				menorValor = MenorValor(menorValor, X - 1, Y);
				movimientos.Add(3);
			}
			if (movimientos.Contains(0) && AmbienteAvatar[X, Y - 1] != menorValor)
			{
				movimientos.Remove(0);
			}
			else if (movimientos.Contains(1) && AmbienteAvatar[X + 1, Y] != menorValor)
			{
				movimientos.Remove(1);
			}
			else if (movimientos.Contains(2) && AmbienteAvatar[X, Y + 1] != menorValor)
			{
				movimientos.Remove(2);
			}
			else if (movimientos.Contains(3) && AmbienteAvatar[X - 1, Y] != menorValor)
			{
				movimientos.Remove(3);
			}
			return movimientos.ToArray();
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
			Progreso progreso = new Progreso(totales);
			progreso.Show();
			PruebasReconocimientoRandom = new int[totales][,];
			PasosPruebasReconocimientoRandom = new int[totales];
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
						PasosPruebasReconocimientoRandom[i]++;
					}
				}
				EnCasa = false;
				X = x;
				Y = y;
				Colocar();
				Ventana.Casa.Colocar();
				await Task.Delay(50); //
				progreso.Avanzar();
			}
			progreso.Close();
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
						linea += "|00" + AmbienteAvatar[i, j].ToString();
					}
					else if (AmbienteAvatar[i, j].ToString().Length == 2)
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

		private void MarcarCamino(int x, int y, int valor)
		{
			if (y - 1 > 0 && VerificarMovimiento(x, y - 1))
			{
				if (AmbienteAvatar[x, y - 1] > 0)
				{
					MarcarCamino(x, y - 1, valor);
				}
			}
			if (x + 1 < Ventana.Ambiente.GetLength(0) - 1 && VerificarMovimiento(x + 1, y))
			{
				if (AmbienteAvatar[x + 1, y] > 0)
				{
					MarcarCamino(x + 1, y, valor);
				}
			}
			if (y + 1 < Ventana.Ambiente.GetLength(1) - 1 && VerificarMovimiento(x, y + 1))
			{
				if (AmbienteAvatar[x, y + 1] > 0)
				{
					MarcarCamino(x, y + 1, valor);
				}
			}
			if (x - 1 > 0 && VerificarMovimiento(x - 1, y))
			{
				if (AmbienteAvatar[x - 1, y] > 0)
				{
					MarcarCamino(x - 1, y, valor);
				}
			}
		}

		public async Task MejorRutaRandom()
		{
			int menor = PasosPruebasReconocimientoRandom[0];
			for (int i = 1; i < PasosPruebasReconocimientoRandom.Length; i++)
			{
				if (PasosPruebasReconocimientoRandom[i] < menor)
				{
					menor = PasosPruebasReconocimientoRandom[i];
				}
			}
			List<int> posiciones = new List<int>();
			for (int i = 0; i < PasosPruebasReconocimientoRandom.Length; i++)
			{
				if (PasosPruebasReconocimientoRandom[i] == menor)
				{
					posiciones.Add(i);
				}
			}
			int[] posicionesMenores = posiciones.ToArray();
			if (posicionesMenores.Length > 1)
			{
				AmbienteAvatar = PruebasReconocimientoRandom[posicionesMenores[random.Next(0, posicionesMenores.Length)]];
			}
			else
			{
				AmbienteAvatar = PruebasReconocimientoRandom[posicionesMenores[0]];
			}
			ImprimirAmbiente();
			MarcarCamino(Ventana.Casa.X, Ventana.Casa.Y, 1);
			ImprimirAmbiente();
		}

		public async Task MejorRutaReconocimiento() 
		{
			for (int i = 0; i < PruebasReconocimientoRandom.Length; i++)
			{
				for (int j = 0; j < PruebasReconocimientoRandom[i].GetLength(1); j++)
				{
					for (int k = 0; k < PruebasReconocimientoRandom[k].GetLength(0); k++)
					{
						AmbienteAvatar[j, k] += PruebasReconocimientoRandom[i][j, k];
					}
				}
			}
			ImprimirAmbiente();
		}
	}
}