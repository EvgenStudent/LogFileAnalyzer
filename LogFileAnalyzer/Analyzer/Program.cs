using AnalyzerLibrary;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.ReportConverter;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.Writer;
using ConsoleCommandLibrary;

namespace Analyzer
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var consoleParameters = new ConsoleParametrsParse(args);

			bool tryConsoleParameters = consoleParameters.TryGetParameters();
			if (tryConsoleParameters)
			{
				IReader reader = new LogReader();
				IFileWriter<string> writer = new TextFileWriter(consoleParameters.Parameters[Keys.Application.Parameters][Keys.Application.ResultFileName]);
				var analyzer = new LogFileAnalyzer(consoleParameters.Parameters, reader, writer);
				ReportResult report = analyzer.Report;
				analyzer.GetReportWriter(new ReportResultRepository(writer)).ReportWrite(report);
			}
		}
	}
}