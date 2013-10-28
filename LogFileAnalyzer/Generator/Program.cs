using System;
using ConsoleCommandLibrary;
using GeneratorLibrary;
using GeneratorLibrary.ErrorView;
using GeneratorLibrary.Exceptions;
using GeneratorLibrary.Reader;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			string pathProject = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.Length - 20);
			try
			{
				var consoleParameters = new ConsoleParametrsParse(args);
				IConfigReader configReader = new YamlConfigReader(pathProject + @"\Config.yaml");

				var configParameters = configReader.Parameters;
				bool tryConsoleParameters = consoleParameters.TryGetParameters();

				if (!tryConsoleParameters) 
					throw new IncorrectParametersException(consoleParameters.ErrorParameters);

				var generator = new LogFileGenerator(consoleParameters.Parameters, configParameters);
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
