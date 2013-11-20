using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AnalyzerForm.Entities;
using AnalyzerForm.FormsForParameters;
using AnalyzerForm.Repository;
using AnalyzerLibrary;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.Writer;
using Config;
using PartsRecord;
using Keys = AnalyzerLibrary.Constant.Keys;

namespace AnalyzerForm
{
	public partial class AnalyzerForm : Form
	{
		private readonly ReaderRepository _readerRepository = new ReaderRepository();
		private LogFileAnalyzer _analyzer;
		private Form _formForParameters;
		private StructureConfig _parameters;
		private IReader _reader;

		//---------------------------------------------------------------

		public AnalyzerForm()
		{
			InitializeComponent();
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
					button_analyze.Enabled = true;
					groupBox_for_config.Enabled = true;
					radioButton_ip.Checked = true;
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
			_reader = new LogReader();
			IWriter<string> writer = new DataGridViewWriter(dataGridView_output);
			_analyzer = new LogFileAnalyzer(_parameters, _reader, writer);
			List<LogRecordParts> records = _analyzer.LogRecords;
			CreateDataGriedInput(records);

			_analyzer.CreateReport();
		}

		private void radioButton_date_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_date.Checked)
			{
				_formForParameters = new ParametersForDate(SetParameters, textBox_LogFileName.Text);
				_formForParameters.ShowDialog();
			}
		}

		private void radioButton_ip_CheckedChanged(object sender, EventArgs e)
		{
			IDictionary<string, IDictionary<string, string>> dictionary =
				new Dictionary<string, IDictionary<string, string>>(StringComparer.InvariantCultureIgnoreCase);

			var innerDictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
			{
				{Keys.Application.Report, Keys.Reports.UniqueIp},
				{Keys.Application.LogFileName, textBox_LogFileName.Text}
			};

			dictionary.Add(Keys.Application.Parameters, innerDictionary);
			_parameters = new StructureConfig(dictionary);
		}

		private void radioButton_codes_CheckedChanged(object sender, EventArgs e)
		{
			IDictionary<string, IDictionary<string, string>> dictionary =
				new Dictionary<string, IDictionary<string, string>>(StringComparer.InvariantCultureIgnoreCase);

			var innerDictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
			{
				{Keys.Application.Report, Keys.Reports.CodeStatistics},
				{Keys.Application.LogFileName, textBox_LogFileName.Text}
			};

			dictionary.Add(Keys.Application.Parameters, innerDictionary);
			_parameters = new StructureConfig(dictionary);
		}

		//---------------------------------------------------------------

		private void SetParameters(StructureConfig parameters)
		{
			_parameters = parameters;
		}

		private void CreateDataGriedInput(ICollection<LogRecordParts> list)
		{
			var nowList = new List<LogRecordStringParts>(list.Count);
			nowList.AddRange(
				list.Select(item => _analyzer.ConvertToString.Convert(item)).Select(listString => new LogRecordStringParts
				{
					IpAddress = listString[0],
					Hyphen = listString[1],
					UserId = listString[2],
					Date = listString[3],
					RequestLine = listString[4],
					Code = listString[5],
					FileSize = listString[6]
				}));


			var bindingSource = new BindingSource();
			dataGridView_input.Text = null;
			dataGridView_input.DataSource = bindingSource;
			bindingSource.DataSource = nowList;


			dataGridView_input.Columns[1].Width = 60;
			dataGridView_input.Columns[2].Width = 79;
			dataGridView_input.Columns[3].Width = 186;
			dataGridView_input.Columns[4].Width = 272;
			dataGridView_input.Columns[5].Width = 72;
		}
	}
}

// http://social.msdn.microsoft.com/Forums/windows/en-US/793846c6-cc10-446a-bca1-968b047bb134/bind-datagridview-to-custom-collection