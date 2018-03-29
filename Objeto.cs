using System;
using System.Drawing;

namespace AmbienteZelda
{
	[Serializable]
	public class Objeto
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string RutaImagen { get; set; }

		public Objeto(int x, int y, string rutaImagen)
		{
			X = x;
			Y = y;
			RutaImagen = rutaImagen;
			Colocar();
		}

		public void Colocar()
		{
			Ventana.Ambiente[X, Y].Image = Image.FromFile(RutaImagen);
		}
	}
}