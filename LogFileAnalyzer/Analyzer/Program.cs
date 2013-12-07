using AnalyzerLibrary;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.NinjectModule;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.Repository;
using AnalyzerLibrary.Writer;
using ConsoleCommandLibrary;
using Ninject;

namespace Analyzer
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			IKernel kernel = new StandardKernel(new ReaderNinjectModule(null));
			var consoleParameters = new ConsoleParametrsParse(args);

			bool tryConsoleParameters = consoleParameters.TryGetParameters();
			if (tryConsoleParameters)
			{
				IReader reader = new LogReader();
				IFileWriter<string> fileWriter =
					new TextFileWriter(consoleParameters.Parameters[Keys.Application.Parameters][Keys.Application.ResultFileName]);
				var repository = new ReportResultFileRepository<string>(fileWriter);
				var analyzer = new LogFileAnalyzer(consoleParameters.Parameters, reader,
					repository.GetReportWriter(consoleParameters.Parameters[Keys.Application.Parameters][Keys.Application.Report]));
				ReportResult report = analyzer.Report;
				analyzer.GetReportWriter(repository).ReportWrite(report);
			}
		}
	}
}