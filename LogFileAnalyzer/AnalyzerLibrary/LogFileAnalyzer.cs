using System;
using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.ConverterOutput;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.ReportConverter;
using AnalyzerLibrary.ReportResults;
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
		public List<LogRecordParts> LogRecords { get; private set; }
		private readonly ReportRepository _reportRepository;
		private readonly ReportResultRepository _reportResultRepository;

		public LogFileAnalyzer(StructureConfig config, IReader reader)
		{
			_config = config;
			LogRecords = (new LogFileStructure(reader.Read(config[Keys.Application.Parameters][Keys.Application.LogFileName]))).LogRecords;

			//_reportRepository = new ReportRepository(CreateReportRepository());
			//_reportResultRepository = new ReportResultRepository(new LogStringWriter(config[Keys.Application.Parameters][Keys.Application.ResultFileName]));
		}

		public void CreateReport()
		{
			IReport reportFunc = _reportRepository.GetReport(_config[Keys.Application.Parameters][Keys.Application.Report]);
			ReportResult report = reportFunc.GetReport();

			IReportWriter reportWriter = _reportResultRepository.GetReportResult(_config[Keys.Application.Parameters][Keys.Application.Report]);
			reportWriter.ReportWrite(report);
		}

		private ReportParameters CreateReportRepository()
		{
			var optionalParams = new Dictionary<string, object>
			{
				{
					Keys.Reports.Date + Keys.Reports.Min,
					_config[Keys.Application.Parameters].ContainsKey(Keys.Reports.Min)
						?_config[Keys.Application.Parameters][Keys.Reports.Min]
						: DateTime.MinValue.ToShortDateString()
				},
				{
					Keys.Reports.Date + Keys.Reports.Max,
					_config[Keys.Application.Parameters].ContainsKey(Keys.Reports.Max)
						? _config[Keys.Application.Parameters][Keys.Reports.Max]
						: DateTime.MaxValue.ToShortDateString()
				}
			};
			var reportParameters = new ReportParameters(LogRecords, _convertToString, optionalParams);
			return reportParameters;
		}
	}
}