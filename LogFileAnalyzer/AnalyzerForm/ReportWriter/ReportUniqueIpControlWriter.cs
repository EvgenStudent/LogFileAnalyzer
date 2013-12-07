using System.Windows.Forms;
using AnalyzerForm.ReportConverter;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.ReportWriter;

namespace AnalyzerForm.ReportWriter
{
	public class ReportUniqueIpControlWriter : IReportWriter
	{
		private readonly ReportUniqueIpConverterToList _converter = new ReportUniqueIpConverterToList();
		private readonly DataGridView _dataGridView;

		public ReportUniqueIpControlWriter(DataGridView dataGridView)
		{
			_dataGridView = dataGridView;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			var bindingSource = new BindingSource();
			var result = (ReportUniqueIpResult) reportResult;

			_dataGridView.Columns.Clear();
			_dataGridView.DataSource = bindingSource;
			bindingSource.DataSource = _converter.Convert(result.IpAddressCollection);
		}
	}
}