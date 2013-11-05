namespace GeneratorLibrary.PartsRecord
{
	public struct RequestLine
	{
		public string Method { get; private set; }
		public string FullNameFile { get; private set; }
		public string Protocol { get; private set; }
		public string Version { get; private set; }

		public RequestLine(string method, string fullNameFile, string protocol, string version)
			: this()
		{
			Method = method;
			FullNameFile = fullNameFile;
			Protocol = protocol;
			Version = version;
		}
	}
}