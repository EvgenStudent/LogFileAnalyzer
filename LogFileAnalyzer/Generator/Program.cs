using System.Collections.Generic;
using System.IO;
using ConsoleCommandLibrary;
using GeneratorLibrary;
using GeneratorLibrary.Writer;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			FileSystemInfo cofnigInfo = new FileInfo(@"P:\Programming\GitHub\LogFileAnalyzer\LogFileAnalyzer\Config.yaml");
			YamlReader yamlReader = new YamlReader(cofnigInfo);
			IDictionary<string, string> parametersInConfig = yamlReader.GetParameters;

			DirectoryInfo directoryInfo = new DirectoryInfo(@"P:\Programming\GitHub\LogFileAnalyzer\LogFileAnalyzer");
			FileWriter fileWriter = new FileWriter(directoryInfo);

			ConsoleParametrsParse parametrsParse = new ConsoleParametrsParse(args);
			bool correctParameters = parametrsParse.GetParameters();

			if (correctParameters)
			{
				IDictionary<string, string> consoleParameters = parametrsParse.Parameters;
				GeneratorLog generator = new GeneratorLog(consoleParameters);
				fileWriter.Write(generator.TemplateResponse, generator.FileName, generator.Count);
			}
		}
	}
}
