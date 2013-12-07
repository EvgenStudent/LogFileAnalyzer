using AnalyzerLibrary.Reader;
using AnalyzerLibrary.ReportWriter;
using Config;

namespace AnalyzerLibrary.NinjectModule
{
	public class AnalyzerNinjectModule : Ninject.Modules.NinjectModule
	{
		private readonly IReportWriter _reportWriter;
		private readonly StructureConfig _structureConfig;

		public AnalyzerNinjectModule(StructureConfig structureConfig, IReportWriter reportWriter)
		{
			_structureConfig = structureConfig;
			_reportWriter = reportWriter;
		}

		public override void Load()
		{
			Kernel.Bind<IReader>().To<LogReader>();
			Kernel.Bind<StructureConfig>().ToConstant(_structureConfig);
			Kernel.Bind<IReportWriter>().ToConstant(_reportWriter);
		}
	}
}