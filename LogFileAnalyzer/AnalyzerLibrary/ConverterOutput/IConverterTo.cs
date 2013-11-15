using System.Collections.Generic;
using PartsRecord;

namespace AnalyzerLibrary.ConverterOutput
{
	public interface IConverterTo<T>
	{
		List<T> Convert(LogRecordParts recordParts);
	}
}