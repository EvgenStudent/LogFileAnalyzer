using System.Windows.Forms;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.ReportWriter;

namespace AnalyzerForm.ReportWriter
{
	public class ReportGeneralTrafficControlWriter : IReportWriter
	{
		private readonly DataGridView _dataGridView;

		public ReportGeneralTrafficControlWriter(DataGridView dataGridView)
		{
			_dataGridView = dataGridView;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			var result = (ReportGeneralTrafficResult) reportResult;

			_dataGridView.DataSource = null;
			_dataGridView.Columns.Clear();
			_dataGridView.Columns.Add("generalTraffic", "General traffic");
			_dataGridView.Rows.Add(result.FilesSize);
		}
	}
}