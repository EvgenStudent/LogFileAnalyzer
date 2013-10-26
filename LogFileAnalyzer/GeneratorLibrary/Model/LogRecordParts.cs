using GeneratorLibrary.PartsRecord;

namespace GeneratorLibrary.Model
{
	public class LogRecordParts
	{
		public IpAddress IpAddress { get; set; }
		public Hyphen Hyphen { get; set; }
		public UserId UserId { get; set; }
		public Date Date { get; set; }
		public RequestLine RequestLine { get; set; }
		public CodeDefinition CodeDefinition { get; set; }
		public FileSize FileSize { get; set; }
	}
}