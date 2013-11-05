using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.Reader;
using Config;

namespace AnalyzerLibrary
{
    public class LogFileAnalyzer
    {
		private readonly IDictionary<string, string> _consoleParameters;
	    private LogFileStructure _logFileStructure;
	    private StructureConfig _config;

        public LogFileAnalyzer(IReader reader, StructureConfig config)
        {
	        _config = config;
			_logFileStructure = new LogFileStructure(reader.Read(_consoleParameters[Keys.LogFileName]));
        }
    }
}