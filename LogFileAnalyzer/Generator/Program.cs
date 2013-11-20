using System.Configuration;
using Config;
using ConsoleCommandLibrary;
using GeneratorLibrary;
using GeneratorLibrary.ErrorView;
using GeneratorLibrary.Exceptions;
using GeneratorLibrary.Reader;

namespace Generator
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			try
			{
				var consoleParameters = new ConsoleParametrsParse(args);
				IConfigReader configReader = new YamlConfigReader(ConfigurationManager.AppSettings.Get("pathConfigFile"));

				StructureConfig configParameters = configReader.Parameters;
				bool tryConsoleParameters = consoleParameters.TryGetParameters();

				if (!tryConsoleParameters)
					throw new IncorrectParametersException(consoleParameters.ErrorParameters);

				configParameters.JoinConfig(consoleParameters.Parameters);
				var generator = new LogFileGenerator(configParameters);
				generator.GenerateLogFile();
			}
			catch (GeneratorAppException exception)
			{
				IErrorView view = new ConsoleErrorView(exception);
				view.DisplayMessage();
			}
		}
	}
}