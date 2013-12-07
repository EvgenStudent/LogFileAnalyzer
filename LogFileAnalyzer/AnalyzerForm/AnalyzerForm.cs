using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AnalyzerForm.Entities;
using AnalyzerForm.Repository;
using AnalyzerLibrary;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.Repository;
using AnalyzerLibrary.Writer;
using Config;
using PartsRecord;
using Keys = AnalyzerLibrary.Constant.Keys;

namespace AnalyzerForm
{
	public partial class AnalyzerForm : Form
	{
		private readonly ReaderRepository _readerRepository = new ReaderRepository();
		private readonly ReportResultControlRepository _reportResultControlRepository;
		private LogFileAnalyzer _analyzer;
		private Form _formForParameters;
		private StructureConfig _parameters;
		private IReader _reader;
		private string _reportFileName;
		private ReportResult _reportResult;

		//---------------------------------------------------------------

		public AnalyzerForm()
		{
			InitializeComponent();
			_reportResultControlRepository = new ReportResultControlRepository(dataGridView_output);
		}

		private void button_open_Click(object sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog
			{
				InitialDirectory = @"P:\Programming\GitHub\LogFileAnalyzer\LogFileAnalyzer",
				Filter = @"Log files (*.log)|*.log|Text files (*.txt)|*.txt|All files (*.*)|*.*",
				FilterIndex = 1,
				RestoreDirectory = true
			};

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileExtension = Path.GetExtension(openFileDialog.FileName);
				try
				{
					_reader = _readerRepository[fileExtension];
					textBox_LogFileName.Text = openFileDialog.FileName;

					_parameters = InitializationStructureConfig(null);
					_analyzer = new LogFileAnalyzer(_parameters, _reader, null);
					List<LogRecordParts> records = _analyzer.LogRecords;
					CreateDataGriedInput(records);

					groupBox_for_config.Enabled = true;
				}
				catch (KeyNotFoundException)
				{
					MessageBox.Show(string.Format("Unknown file extension: {0}", fileExtension), @"Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		private void button_analyze_Click(object sender, EventArgs e)
		{
			_analyzer = new LogFileAnalyzer(_parameters, _reader,
				_reportResultControlRepository.GetReportWriter(_parameters[Keys.Application.Parameters][Keys.Application.Report]));
			List<LogRecordParts> records = _analyzer.LogRecords;
			CreateDataGriedInput(records);

			_reportResult = _analyzer.Report;
			_analyzer.GetReportWriter(_reportResultControlRepository).ReportWrite(_reportResult);

			button_save_report.Enabled = true;
		}

		private void button_save_report_Click(object sender, EventArgs e)
		{
			using (var saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.InitialDirectory = @"P:\Programming\GitHub\LogFileAnalyzer\LogFileAnalyzer";
				saveFileDialog.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
				saveFileDialog.FilterIndex = 1;
				saveFileDialog.RestoreDirectory = true;

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					_reportFileName = saveFileDialog.FileName;
					using (var writer = new TextFileWriter(_reportFileName))
					{
						_analyzer.GetReportWriter(new ReportResultFileRepository<string>(writer)).ReportWrite(_reportResult);
						button_open_report.Enabled = true;
					}
				}
			}
		}

		private void button_open_report_Click(object sender, EventArgs e)
		{
			Process.Start(_reportFileName);
		}

		private void radioButton_traffic_CheckedChanged(object sender, EventArgs e)
		{
			button_analyze.Enabled = true;

			const string reportName = Keys.Reports.GeneralTraffic;
			_parameters = InitializationStructureConfig(reportName);
		}

		private void radioButton_ip_CheckedChanged(object sender, EventArgs e)
		{
			button_analyze.Enabled = true;

			const string reportName = Keys.Reports.UniqueIp;
			_parameters = InitializationStructureConfig(reportName);
		}

		private void radioButton_codes_CheckedChanged(object sender, EventArgs e)
		{
			button_analyze.Enabled = true;

			const string reportName = Keys.Reports.CodeStatistics;
			_parameters = InitializationStructureConfig(reportName);
		}

		private void textBox_date_Leave(object sender, EventArgs e)
		{
			//if (ValidateData())
			//{
			string reportName = _parameters[Keys.Application.Parameters].ContainsKey(Keys.Application.Report)
				? _parameters[Keys.Application.Parameters][Keys.Application.Report] : null;

			_parameters = InitializationStructureConfig(reportName);
			//}
			//else
			//{
			//	MessageBox.Show(@"Uncorrect date!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	textBox_minDate.Text = string.Empty;
			//	textBox_maxDate.Text = string.Empty;
			//}
		}

		//---------------------------------------------------------------

		private void CreateDataGriedInput(ICollection<LogRecordParts> list)
		{
			var nowList = new List<LogRecordStringParts>(list.Count);
			nowList.AddRange(
				list.Select(item => _analyzer.ConvertToString.Convert(item)).Select(listString => new LogRecordStringParts
				{
					IpAddress = listString[0],
					UserName = listString[1],
					UserId = listString[2],
					Date = listString[3],
					RequestLine = listString[4],
					Code = listString[5],
					FileSize = listString[6]
				}));

			//var bindingSource = new BindingSource();
			//dataGridView_input.Text = null;
			//dataGridView_input.DataSource = bindingSource;
			//bindingSource.DataSource = nowList;


			dataGridView_input.DataSource = null;
			dataGridView_input.Columns.Clear();
			dataGridView_input.Rows.Clear();

			dataGridView_input.Columns.Add("IpAddress", "IpAddress");
			dataGridView_input.Columns.Add("UserName", "UserName");
			dataGridView_input.Columns.Add("UserId", "UserId");
			dataGridView_input.Columns.Add("Date", "Date");
			dataGridView_input.Columns.Add("RequestLine", "RequestLine");
			dataGridView_input.Columns.Add("Code", "Code");
			dataGridView_input.Columns.Add("FileSize", "FileSize");

			foreach (LogRecordStringParts element in nowList)
				dataGridView_input.Rows.Add(element.IpAddress, element.UserName, element.UserId, element.Date, element.RequestLine,
					element.Code, element.FileSize);

			dataGridView_input.Columns[1].Width = 60;
			dataGridView_input.Columns[2].Width = 79;
			dataGridView_input.Columns[3].Width = 186;
			dataGridView_input.Columns[4].Width = 272;
			dataGridView_input.Columns[5].Width = 72;
		}

		private StructureConfig InitializationStructureConfig(string reportName)
		{
			IDictionary<string, IDictionary<string, string>> dictionary =
				new Dictionary<string, IDictionary<string, string>>(StringComparer.InvariantCultureIgnoreCase);

			var innerDictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
			{
				{Keys.Application.Report, reportName},
				{Keys.Application.LogFileName, textBox_LogFileName.Text},
				{Keys.Reports.Min, (textBox_minDate.Text == string.Empty ? DateTime.MinValue.Date.ToString() : textBox_minDate.Text)},
				{Keys.Reports.Max, (textBox_maxDate.Text == string.Empty ? DateTime.MaxValue.Date.ToString() : textBox_maxDate.Text)},
			};

			dictionary.Add(Keys.Application.Parameters, innerDictionary);
			return new StructureConfig(dictionary);
		}

		private bool ValidateData()
		{
			if(textBox_minDate.Text == string.Empty & textBox_maxDate.Text == string.Empty)
				return true;

			const string regexForValidate = @"(0[1-9]|1[0-9]|2[0-9]|3[01])\.(0[1-9]|1[012])\.[0001-9999]";
			bool match = Regex.IsMatch(textBox_minDate.Text, regexForValidate) & Regex.IsMatch(textBox_maxDate.Text, regexForValidate);
			return match;
		}
	}
}

// http://social.msdn.microsoft.com/Forums/windows/en-US/793846c6-cc10-446a-bca1-968b047bb134/bind-datagridview-to-custom-collection