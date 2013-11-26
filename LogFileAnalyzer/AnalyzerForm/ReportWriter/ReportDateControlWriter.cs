using System;
using System.Windows.Forms;
using AnalyzerForm.ReportConverter;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.ReportWriter;

namespace AnalyzerForm.ReportWriter
{
	public class ReportDateControlWriter : IReportWriter
	{
		private readonly DataGridView _dataGridView;
		private readonly ReportDateConverterToList _converter = new ReportDateConverterToList();

		public ReportDateControlWriter(DataGridView dataGridView)
		{
			_dataGridView = dataGridView;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			var result = (ReportDateResult)reportResult;
			var bindingSource = new BindingSource();

			_dataGridView.Text = null;
			_dataGridView.DataSource = bindingSource;
			bindingSource.DataSource = _converter.Convert(result.DateCollection);

			_dataGridView.Columns[1].Width = 60;
			_dataGridView.Columns[2].Width = 79;
			_dataGridView.Columns[3].Width = 186;
			_dataGridView.Columns[4].Width = 272;
			_dataGridView.Columns[5].Width = 72;
		}
	}
}