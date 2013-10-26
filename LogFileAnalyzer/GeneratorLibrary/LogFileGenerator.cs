using System.Collections.Generic;
using GeneratorLibrary.Converter;
using GeneratorLibrary.Model;
using GeneratorLibrary.Writer;

namespace GeneratorLibrary
{
	public class LogFileGenerator
	{
		private readonly LogRecordTemplate _logRecordTemplate = new LogRecordTemplate();
		private readonly IConverter<string> _converter;
		private readonly IFileWriter _writer;

		private readonly IDictionary<string, string> _consoleParameters;
		private readonly StructureConfig _configParameters;

		public LogFileGenerator(IDictionary<string, string> consoleParameters)
		{
			_consoleParameters = consoleParameters;
			
		}
		public LogFileGenerator(IDictionary<string, string> consoleParameters, StructureConfig configParameters)
			: this(consoleParameters)
		{
			_configParameters = configParameters;
		}

		public void GenerateLogFile()
		{
			var record = _logRecordTemplate.GenerateRecord();

			// !!! пройти по свойствам структуры циклом foreach
			//var a = new { prop1 = 1, prop2 = "2" };
			//foreach (var prop in a.GetType().GetProperties())
			//{
			//	Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(a, null));
			//}
		}
	}
}