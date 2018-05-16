using System.Windows.Forms;

namespace AmbienteZelda
{
	public partial class Progreso : Form
	{
		private int Totales { get; set; }
		private int Avance { get; set; }

		public Progreso(int totales)
		{
			InitializeComponent();
			Totales = totales;
			EtiquetaProgreso.Text = "  0/" + Totales.ToString();
		}
		
		public void Avanzar()
		{
			Avance++;
			if (Avance.ToString().Length == 1)
			{
				EtiquetaProgreso.Text = "  " + Avance.ToString() + "/" + Totales.ToString();
			}
			else if (Avance.ToString().Length == 2)
			{
				EtiquetaProgreso.Text = " " + Avance.ToString() + "/" + Totales.ToString();
			}
			else
			{
				EtiquetaProgreso.Text = Avance.ToString() + "/" + Totales.ToString();
			}
		}
	}
}
