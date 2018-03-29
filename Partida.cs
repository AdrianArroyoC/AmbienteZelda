using System;

namespace AmbienteZelda
{
	[Serializable]
	class Partida
	{
		public int CX { get; set; }
		public int CY { get; set; }
		public int M { get; set; }
		public bool F { get; set; }
		public bool[,] O { get; set; }
		public Avatar L { get; set; }
		public Meta C { get; set; }
		
		public Partida(int cX, int cY, int m, bool f, bool[,] o, Avatar l, Meta c)
		{
			CX = cX;
			CY = cY;
			M = M;
			F = f;
			O = o;
			L = l;
			C = c;
		}
	}
}