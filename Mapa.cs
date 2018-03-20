using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbienteZelda
{
	[Serializable]
	class Mapa
	{
		public bool[,] OA { get; set; }
		public int CX { get; set; }
		public int CY { get; set; }
		public int XA { get; set; }
		public int YA { get; set; }
		public int XC { get; set; }
		public int YC { get; set; }
		public int B { get; set; }
		public bool F { get; set; }
		public bool A { get; set; }
		public bool C { get; set; }

		public Mapa()
		{

		}

		public Mapa(int CY, int CX, int XA, int YA, int XC, int YC, int B, bool F, bool A, bool C, bool[,] OA)
		{
			this.CY = CY;
			this.CX = CX;
			this.XA = XA;
			this.YA = YA;
			this.XC = XC;
			this.YC = YC;
			this.B = B;
			this.F = F;
			this.A = A;
			this.C = C;
			this.OA = OA;
		}
	}
}