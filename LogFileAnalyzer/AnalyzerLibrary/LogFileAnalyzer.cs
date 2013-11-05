using AnalyzerLibrary.Constant;
using AnalyzerLibrary.Reader;
using Config;

namespace AnalyzerLibrary
{
    public class LogFileAnalyzer
    {
		private LogFileStructure _logFileStructure;
	    private StructureConfig _config;

        public LogFileAnalyzer(IReader reader, StructureConfig config)
        {
	        _config = config;
			_logFileStructure = new LogFileStructure(reader.Read(_config[Keys.ConsoleParameters][Keys.LogFileName]));
        }
    }
}