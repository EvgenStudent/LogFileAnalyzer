using System;
using PartsRecord;

namespace AnalyzerLibrary.Converter
{
	public class UserIdConverter : IConverter<UserId>
	{
		public UserId Convert(string record)
		{
			return new UserId(int.Parse(record));
		}
	}
}