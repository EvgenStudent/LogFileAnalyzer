using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.Reader;
using Config;
using PartsRecord;

namespace AnalyzerLibrary
{
    public class LogFileAnalyzer
    {
	    private readonly List<LogRecordParts> _logRecords; 

        public LogFileAnalyzer(IReader reader, StructureConfig config)
        {
	        _logRecords = (new LogFileStructure(reader.Read(config[Keys.ConsoleParameters][Keys.LogFileName]))).LogRecords;
        }
    }
}