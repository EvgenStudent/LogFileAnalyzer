using System;
using System.Windows.Forms;
using Config;

namespace AnalyzerForm
{
	public static class Program
	{
		public delegate void TransmissionParameters(StructureConfig parameters);

		/// <summary>
		///     Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new AnalyzerForm());
		}
	}
}