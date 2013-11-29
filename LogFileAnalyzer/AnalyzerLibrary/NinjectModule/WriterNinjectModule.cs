using AnalyzerLibrary.Writer;

namespace AnalyzerLibrary.NinjectModule
{
	public class WriterNinjectModule : Ninject.Modules.NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind<IFileWriter<string>>().To<TextFileWriter>();
		}
	}
}