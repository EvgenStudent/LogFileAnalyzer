using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GeneratorLibrary.App_Data;
using GeneratorLibrary.Exceptions;
using GeneratorLibrary.Response;

namespace GeneratorLibrary
{
    public class TemplateLogRecord
    {
	    private readonly string[] _keys = {"fileName", "count"};
		private readonly IReadOnlyDictionary<string, string> _consoleParameters;
	    private readonly Random random;
	    private readonly IData data = new ConstantData();
	    private readonly ConfigYaml _configYaml;
		
		public IRecordFieldValueGenerator[] LogFileRecordTemplate { set; get; }
		
		public string FileName
		{
			get
			{
				return _consoleParameters[_keys[0]];
			}
		}
		public int Count
		{
			get
			{
				return int.Parse(_consoleParameters[_keys[1]]);
			}
		}

		public TemplateLogRecord(IReadOnlyDictionary<string, string> consoleParameters)
		{
			Validate(consoleParameters);
			_consoleParameters = consoleParameters;
			random = new RandomGuid();
			CreateRecordTemplate();
		}
	    public TemplateLogRecord(IReadOnlyDictionary<string, string> consoleParameters, ConfigYaml configYaml)
	    {
			_configYaml = configYaml;
			Validate(consoleParameters);
			_consoleParameters = consoleParameters;
			random = new RandomGuid();
			CreateRecordTemplate();
	    }

	    private void CreateRecordTemplate()
	    {
		    var parametersForRequestLine = new ParametersForRequestLine
		    {
				FileExtensions = data.FileExtensions, Methods = data.Methods, Protocols = data.Protocols, Versions = data.Versions,
				Probability = (_configYaml == null) ? null :new Probability
				{
					probabilityFileExtensions = _configYaml["fileExtensions"],
					probabilityMethods = _configYaml["methods"],
					probabilityProtocols = _configYaml["protocols"],
					probabilityVersions = _configYaml["versions"],
				}
		    };
		    LogFileRecordTemplate = new IRecordFieldValueGenerator[]
		    {
			    new Ip(random), 
				new Hyphen(), 
				new UserId(random, Count), 
				new Date(random), 
				new RequestLine(random, parametersForRequestLine), 
				new CodeDefinition(random, data.Codes), 
				new FileSize(random), 
		    };
	    }

		private void Validate(IReadOnlyDictionary<string, string> consoleParameters)
		{
			foreach (string key in _keys.Where(key => !consoleParameters.ContainsKey(key)))
				throw new NoParameterException("Ошибка. Отсутствует параметр: " + key);

			if (!Regex.IsMatch(consoleParameters[_keys[0]], @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$"))
				throw new FilePathValidateException("Ошибка валидации. Неверное полное имя файла: " + consoleParameters[_keys[0]]);
		}
    }
}
