using AnalyzerLibrary.Reader;
using Config;

namespace AnalyzerLibrary.NinjectModule
{
	public class ReaderNinjectModule : Ninject.Modules.NinjectModule
	{
		private readonly StructureConfig _structureConfig;

		public ReaderNinjectModule(StructureConfig structureConfig)
		{
			_structureConfig = structureConfig;
		}

		public override void Load()
		{
			Kernel.Bind<IReader>().To<LogReader>();
			Kernel.Bind<StructureConfig>().ToConstant(_structureConfig);
		}
	}
}