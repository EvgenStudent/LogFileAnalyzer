using System.Windows.Forms;
using AnalyzerForm.ReportConverter;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.ReportWriter;

namespace AnalyzerForm.ReportWriter
{
	public class ReportCodeStatisticsControlWriter : IReportWriter
	{
		private readonly ReportCodeStatisticsConverterToList _converter = new ReportCodeStatisticsConverterToList();
		private readonly DataGridView _dataGridView;

		public ReportCodeStatisticsControlWriter(DataGridView dataGridView)
		{
			_dataGridView = dataGridView;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			var result = (ReportCodeStatisticsResult) reportResult;
			var bindingSource = new BindingSource();

			_dataGridView.Text = null;
			_dataGridView.DataSource = bindingSource;
			bindingSource.DataSource = _converter.Convert(result.CodeCollection);
		}
	}
}