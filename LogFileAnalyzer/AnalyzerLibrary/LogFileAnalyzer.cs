using System;
using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.ConverterOutput;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.Reports;
using AnalyzerLibrary.Writer;
using Config;
using PartsRecord;

namespace AnalyzerLibrary
{
	public class LogFileAnalyzer
	{
		private readonly StructureConfig _config;
		private readonly IConverterTo<string> _convertToString = new ConvertToString();
		private readonly List<LogRecordParts> _logRecords;
		private readonly string _path;
		private readonly ReportRepository<string> _reportRepository;

		public LogFileAnalyzer(StructureConfig config, IReader reader)
		{
			_config = config;
			_path = config[Keys.Console.ConsoleParameters][Keys.Console.ResultFileName];
			_logRecords = (new LogFileStructure(reader.Read(config[Keys.Console.ConsoleParameters][Keys.Console.LogFileName]))).LogRecords;

			_reportRepository = new ReportRepository<string>(CreateReportRepository());
		}

		public void CreateReport()
		{
			try
			{
				IReport<string> reportFunc = _reportRepository.GetReport(_config[Keys.Console.ConsoleParameters][Keys.Console.Report]);
				Report<string> report = reportFunc.GetReport();

				using (var file = new LogStringWriter(_config[Keys.Console.ConsoleParameters][Keys.Console.ResultFileName]))
				{
					foreach (string element in report.Structure)
						file.Write(element);
				}
			}
			catch (Exception exception)
			{
				throw new NotImplementedException();
			}
		}

		private ReportParameters CreateReportRepository()
		{
			var optionalParams = new Dictionary<string, object>
			{
				{
					Keys.Reports.Date + Keys.Reports.Min,
					_config[Keys.Console.ConsoleParameters].ContainsKey(Keys.Reports.Min)
						? DateTime.Parse(_config[Keys.Console.ConsoleParameters][Keys.Reports.Min])
						: DateTime.MinValue.ToShortDateString()
				},
				{
					Keys.Reports.Date + Keys.Reports.Max,
					_config[Keys.Console.ConsoleParameters].ContainsKey(Keys.Reports.Max)
						? _config[Keys.Console.ConsoleParameters][Keys.Reports.Max]
						: DateTime.MaxValue.ToShortDateString()
				}
			};
			var reportParameters = new ReportParameters(_logRecords, _convertToString, optionalParams);
			return reportParameters;
		}
	}
}