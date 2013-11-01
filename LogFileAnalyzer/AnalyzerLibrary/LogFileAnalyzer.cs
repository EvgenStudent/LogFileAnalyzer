using System;
using System.Collections.Generic;
using AnalyzerLibrary.Reader;

namespace AnalyzerLibrary
{
    public class LogFileAnalyzer
    {
		private readonly string[] _keys = { "logFileName", "resultFileName" };
        private readonly IDictionary<string, string> _consoleParameters;
	    private LogFileStructure _logFileStructure;

        public LogFileAnalyzer(IReader reader, IDictionary<string, string> consoleParameters)
        {
            _consoleParameters = consoleParameters;
			_logFileStructure = new LogFileStructure(reader.Read(_consoleParameters[_keys[0]]));
        }
    }
}