using System;
using System.Collections.Generic;
using System.IO;
using ConsoleCommandLibrary;
using GeneratorLibrary;
using GeneratorLibrary.Exceptions;
using GeneratorLibrary.View;
using GeneratorLibrary.Writer;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			string pathProject = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.Length - 20);
			YamlReader yamlReader = new YamlReader(new FileInfo(pathProject + @"\Config.yaml"));
			ConfigYaml configParameters = yamlReader.GetParameters;

			FileWriter fileWriter = new FileWriter();
			
			ConsoleParametrsParse consoleParametrs = new ConsoleParametrsParse(args);
			bool correctParameters = consoleParametrs.GetParameters();

			try
			{
				if (correctParameters)
				{
					IReadOnlyDictionary<string, string> consoleParameters = consoleParametrs.Parameters;
					TemplateLogRecord template = new TemplateLogRecord(consoleParameters, configParameters);
					fileWriter.Write(template.LogFileRecordTemplate, template.FileName, template.Count);
				}
				else
					throw new IncorrectParametersException(consoleParametrs.ErrorParameters);
			}
			catch (GeneratorAppException exception)
			{
				IErrorView view = new ConsoleErrorView(exception);
				view.DisplayMessage();
			}
		}
	}
}
