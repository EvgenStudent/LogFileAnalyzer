using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Config;
using Keys = AnalyzerLibrary.Constant.Keys;

namespace AnalyzerForm.FormsForParameters
{
	public partial class ParametersForDate : Form
	{
		private readonly string _fullFileName;
		private readonly Program.TransmissionParameters _parameters;

		public ParametersForDate(Program.TransmissionParameters parameters, string fullFileName)
		{
			InitializeComponent();
			RegexForValidate = @"(0[1-9]|1[0-9]|2[0-9]|3[01])\.(0[1-9]|1[012])\.[0001-9999]";
			_parameters = parameters;
			_fullFileName = fullFileName;
		}

		public string RegexForValidate { get; private set; }

		private void button1_Click(object sender, EventArgs e)
		{
			if (ValidateData())
			{
				IDictionary<string, IDictionary<string, string>> dictionary =
					new Dictionary<string, IDictionary<string, string>>(StringComparer.InvariantCultureIgnoreCase);

				var innerDictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
				{
					{Keys.Application.Report, Keys.Reports.Date},
					{Keys.Reports.Min, textBox_minDate.Text},
					{Keys.Reports.Max, textBox_maxDate.Text},
					{Keys.Application.LogFileName, _fullFileName}
				};

				dictionary.Add(Keys.Application.Parameters, innerDictionary);
				_parameters(new StructureConfig(dictionary));
				Close();
			}
			else
				MessageBox.Show(@"Uncorrect dates!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private bool ValidateData()
		{
			if (textBox_minDate.Text == string.Empty)
				textBox_minDate.Text = DateTime.MinValue.ToShortDateString();
			if (textBox_maxDate.Text == string.Empty)
				textBox_maxDate.Text = DateTime.MaxValue.ToShortDateString();

			bool match = Regex.IsMatch(textBox_minDate.Text, RegexForValidate) &
			             Regex.IsMatch(textBox_maxDate.Text, RegexForValidate);
			return match;
		}
	}
}