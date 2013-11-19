using System.Windows.Forms;

namespace AnalyzerLibrary.Writer
{
	public class DataGridViewWriter : IWriter<string>
	{
		private DataGridView _dataGridView;

		public DataGridViewWriter(DataGridView dataGridView)
		{
			_dataGridView = dataGridView;
		}

		public void Write(string parameter)
		{
			throw new System.NotImplementedException();
		}
	}
}