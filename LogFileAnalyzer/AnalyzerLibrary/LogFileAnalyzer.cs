using System;
using System.Collections.Generic;
using System.Linq;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.ConverterOutput;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.Reader;
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
		private readonly IReportWriter _writer;

		public LogFileAnalyzer(StructureConfig config, IReader reader, IReportWriter writer)
		{
			ConvertToString = new ConvertToString();
			_config = config;
			_writer = writer;

			DateTime min = DateTime.Parse(_config[Keys.Application.Parameters][Keys.Reports.Min]);
			DateTime max = DateTime.Parse(_config[Keys.Application.Parameters][Keys.Reports.Max]);
			LogRecords =
				(new LogFileStructure(reader.Read(config[Keys.Application.Parameters][Keys.Application.LogFileName]))).LogRecords
					.Where(x => x.Date.DateNow.Date >= min & x.Date.DateNow.Date <= max).ToList();

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
			IReportWriter reportWriter =
				reportResultRepository.GetReportWriter(_config[Keys.Application.Parameters][Keys.Application.Report]);
			return reportWriter;
		}

		private ReportParameters CreateReportRepository()
		{
			var reportParameters = new ReportParameters(LogRecords, ConvertToString);
			return reportParameters;
		}
	}
}