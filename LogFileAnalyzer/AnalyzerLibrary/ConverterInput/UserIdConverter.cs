using PartsRecord;

namespace AnalyzerLibrary.ConverterInput
{
	public class UserIdConverter : IConverter<string, UserId>
	{
		public UserId Convert(string record)
		{
			return new UserId(int.Parse(record));
		}
	}
}