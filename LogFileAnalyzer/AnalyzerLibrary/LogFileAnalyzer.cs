using System;
using System.Collections.Generic;
using System.Linq;
using AnalyzerLibrary.Comparer;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.ConverterOutput;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.Writer;
using Config;
using PartsRecord;

namespace AnalyzerLibrary
{
    public class LogFileAnalyzer
    {
	    private readonly List<LogRecordParts> _logRecords;
		private readonly ConvertToString _convertToString = new ConvertToString();
	    private readonly string _path;

        public LogFileAnalyzer(StructureConfig config, IReader reader)
        {
	        _path = config[Keys.ConsoleParameters][Keys.ResultFileName];
	        _logRecords = (new LogFileStructure(reader.Read(config[Keys.ConsoleParameters][Keys.LogFileName]))).LogRecords;
        }

		public void FindByDate(DateTime? min = null, DateTime? max = null)
		{
			if (min == null) min = DateTime.MinValue;
			if (max == null) max = DateTime.MaxValue;

			var findResult = _logRecords.Where(x => x.Date.DateNow >= min & x.Date.DateNow <= max).ToList();

			using (var file = new LogStringWriter(_path))
			{
				foreach (var record in findResult)
				{
					var partsRecord = _convertToString.Convert(record);
					file.Write(string.Join(" ", partsRecord));
				}
			}
		}

	    public void FindByUniqueIp()
	    {
		    var findResult = _logRecords.Distinct(new IpAddressComparer()).ToList();

			using (var file = new LogStringWriter(_path))
			{
				foreach (var record in findResult)
				{
					var partsRecord = _convertToString.Convert(record);
					file.Write(string.Join(" ", partsRecord));
				}
			}
			throw new NotImplementedException();
	    }

	    public void CodeStatistics()
	    {
		    throw new NotImplementedException();
	    }
    }
}