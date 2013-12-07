namespace AnalyzerForm.Entities
{
	public struct LogRecordStringParts
	{
		public string IpAddress { get; set; }
		public string UserName { get; set; }
		public string UserId { get; set; }
		public string Date { get; set; }
		public string RequestLine { get; set; }
		public string Code { get; set; }
		public string FileSize { get; set; }
	}
}