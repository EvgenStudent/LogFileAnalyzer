namespace GeneratorLibrary.App_Data
{
	public static class Data
	{
		public static readonly int[] Codes = 
			{
				100, 101, 200, 201, 202, 203, 204, 205, 206, 300, 301, 302, 303, 304, 305, 306, 307, 400, 401,
				402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414, 415, 416, 417, 500, 501, 502, 503, 504, 505
			};
		public static readonly string[] Methods = { "OPTIONS", "GET", "HEAD", "POST", "PUT", "DELETE", "TRACE", "CONNECT", "PATCH", "LINK", "UNLINK" };
		public static readonly string[] Versions = { "0.9", "1.0", "1.1" };
		public static readonly string[] Protocols = { "HTTP", "HTTPS" };
		public static readonly string[] FileExtensions =
		{
			".bmp", ".jpeg", ".png", ".mp3", ".flac", ".txt", ".docx", ".yaml", ".xml",
			".html", ".cs", ".cpp", ".asm"
		};
	}
}