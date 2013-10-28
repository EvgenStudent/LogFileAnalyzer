using System.Collections.Generic;
using System.Threading;
using GeneratorLibrary.Converter;
using GeneratorLibrary.Model;
using GeneratorLibrary.Writer;

namespace GeneratorLibrary
{
	public class LogFileGenerator
	{
		private readonly string[] keys = { "filename", "count" };
		private readonly LogRecordTemplate _logRecordTemplate;
		private readonly IConverter<string> _converter;
		private readonly IFileWriter _writer;

		private readonly IDictionary<string, string> _consoleParameters;
		private readonly StructureConfig _configParameters;

		public LogFileGenerator(IDictionary<string, string> consoleParameters)
		{
			_consoleParameters = consoleParameters;
			_logRecordTemplate = new LogRecordTemplate();
		}
		public LogFileGenerator(IDictionary<string, string> consoleParameters, StructureConfig configParameters)
			: this(consoleParameters)
		{
			_configParameters = configParameters;
			_logRecordTemplate = new LogRecordTemplate(_configParameters);
		}

		public void GenerateLogFile()
		{
			int count = int.Parse(_consoleParameters[keys[1]]);
			LogRecordParts recordParts;
			for (int i = 0; i < count; i++)
			{
				recordParts = _logRecordTemplate.GenerateRecord();
			}



			// !!! пройти по свойствам структуры циклом foreach
			//var a = new { prop1 = 1, prop2 = "2" };
			//foreach (var prop in a.GetType().GetProperties())
			//{
			//	Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(a, null));
			//}
		}
	}
}