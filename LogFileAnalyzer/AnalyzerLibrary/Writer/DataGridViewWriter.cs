using System.Windows.Forms;

namespace AnalyzerLibrary.Writer
{
	public class DataGridViewWriter : IFileWriter<string>
	{
		private readonly DataGridView _dataGridView;

		public DataGridViewWriter(DataGridView dataGridView)
		{
			_dataGridView = dataGridView;
			CreateDataGridView();
		}

		public void Write(string parameter)
		{
			//throw new NotImplementedException();
		}

		public void Dispose()
		{
		}

		private void CreateDataGridView()
		{
			_dataGridView.ColumnCount = 5;
		}
	}
}