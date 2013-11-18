using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnalyzerForm.FormsForParameters;
using AnalyzerLibrary;
using AnalyzerLibrary.Reader;
using Config;
using PartsRecord;

namespace AnalyzerForm
{
	public partial class AnalyzerForm : Form
	{
		private IReader _reader = new LogReader();
		private StructureConfig _parameters;
		private Form _formForParameters;

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
				textBox_LogFileName.Text = openFileDialog.FileName;
				button_analyze.Enabled = true;
				groupBox_for_config.Enabled = true;
			}
		}

		private void button_analyze_Click(object sender, EventArgs e)
		{
			_reader = new LogReader();
			var analyzer = new LogFileAnalyzer(_parameters, _reader);
			var records = analyzer.LogRecords;
			CreateDataGriedInput(records);
		}

		private void radioButton_date_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_date.Checked)
			{
				_formForParameters = new ParametersForDate(SetParameters, textBox_LogFileName.Text);
				_formForParameters.ShowDialog();
			}
		}

		private void SetParameters(StructureConfig parameters)
		{
			_parameters = parameters;
		}

		private void CreateDataGriedInput(IList<LogRecordParts> list)
		{
			var bindingSource = new BindingSource();
			dataGridView_input.Text = null;
			dataGridView_input.DataSource = bindingSource;
			bindingSource.DataSource = list;
		}
	}
}

// http://social.msdn.microsoft.com/Forums/windows/en-US/793846c6-cc10-446a-bca1-968b047bb134/bind-datagridview-to-custom-collection
		