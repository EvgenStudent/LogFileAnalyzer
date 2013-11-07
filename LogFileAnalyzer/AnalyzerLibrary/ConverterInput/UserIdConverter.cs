using PartsRecord;

namespace AnalyzerLibrary.ConverterInput
{
	public class UserIdConverter : IConverter<UserId>
	{
		public UserId Convert(string record)
		{
			return new UserId(int.Parse(record));
		}
	}
}