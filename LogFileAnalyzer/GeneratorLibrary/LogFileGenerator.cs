using System.Collections.Generic;
using GeneratorLibrary.Converter;
using GeneratorLibrary.Model;
using GeneratorLibrary.Writer;

namespace GeneratorLibrary
{
	public class LogFileGenerator
	{
		private readonly string[] keys = { "filename", "count" };
		private readonly LogRecordTemplate _logRecordTemplate;
		private readonly ConvertToString _converter = new ConvertToString();
		
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
			using (var _writer = new LogStringWriter(_consoleParameters[keys[0]]))
			{
				for (int i = 0; i < count; i++)
				{
					recordParts = _logRecordTemplate.GenerateRecord();
					_writer.Write(_converter.Convert(recordParts));
				}
			}
		}
	}
}