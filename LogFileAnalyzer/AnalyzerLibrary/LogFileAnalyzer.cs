using System;
using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.ConverterOutput;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.ReportConverter;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.Reports;
using AnalyzerLibrary.ReportWriter;
using Config;
using PartsRecord;

namespace AnalyzerLibrary
{
	public class LogFileAnalyzer
	{
		private readonly StructureConfig _config;
		private readonly ReportRepository _reportRepository;
		private readonly dynamic _writer;

		public LogFileAnalyzer(StructureConfig config, IReader reader, dynamic writer)
		{
			ConvertToString = new ConvertToString();
			_config = config;
			_writer = writer;
			LogRecords = (new LogFileStructure(reader.Read(config[Keys.Application.Parameters][Keys.Application.LogFileName]))).LogRecords;

			_reportRepository = new ReportRepository(CreateReportRepository());
		}

		public IConverterTo<string> ConvertToString { get; private set; }
		public List<LogRecordParts> LogRecords { get; private set; }

		public ReportResult Report
		{
			get
			{
				IReport reportFunc = _reportRepository.GetReport(_config[Keys.Application.Parameters][Keys.Application.Report]);
				ReportResult report = reportFunc.GetReport();
				return report;
			}
		}

		public IReportWriter GetReportWriter(dynamic reportResultRepository)
		{
			IReportWriter reportWriter = reportResultRepository.GetReportWriter(_config[Keys.Application.Parameters][Keys.Application.Report]);
			return reportWriter;
		}

		private ReportParameters CreateReportRepository()
		{
			var optionalParams = new Dictionary<string, object>
			{
				{
					Keys.Reports.Date + Keys.Reports.Min,
					_config[Keys.Application.Parameters].ContainsKey(Keys.Reports.Min)
						? _config[Keys.Application.Parameters][Keys.Reports.Min]
						: DateTime.MinValue.ToShortDateString()
				},
				{
					Keys.Reports.Date + Keys.Reports.Max,
					_config[Keys.Application.Parameters].ContainsKey(Keys.Reports.Max)
						? _config[Keys.Application.Parameters][Keys.Reports.Max]
						: DateTime.MaxValue.ToShortDateString()
				}
			};
			var reportParameters = new ReportParameters(LogRecords, ConvertToString, optionalParams);
			return reportParameters;
		}
	}
}