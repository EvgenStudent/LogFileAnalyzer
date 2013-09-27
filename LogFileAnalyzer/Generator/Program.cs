using System;
using System.Collections.Generic;
using System.IO;
using ConsoleCommandLibrary;
using GeneratorLibrary;
using GeneratorLibrary.Exceptions;
using GeneratorLibrary.Writer;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			string pathProject = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.Length - 20);
			YamlReader yamlReader = new YamlReader(new FileInfo(pathProject + @"\Config.yaml"));
			IDictionary<string, IDictionary<string, string>> parametersInConfig = yamlReader.GetParameters;

			DirectoryInfo directoryInfo = new DirectoryInfo(pathProject);
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
