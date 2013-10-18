using System.Collections.Generic;

namespace GeneratorLibrary.App_Data
{
	public class ConstantData : IData
	{
		private readonly IReadOnlyList<int> _codes = new List<int>{
				100, 101, 200, 201, 202, 203, 204, 205, 206, 300, 301, 302, 303, 304, 305, 306, 307, 400, 401,
				402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414, 415, 416, 417, 500, 501, 502, 503, 504, 505
			};
		private readonly IReadOnlyList<string> _methods = new List<string> { "OPTIONS", "GET", "HEAD", "POST", "PUT", "DELETE", "TRACE", "CONNECT", "PATCH", "LINK", "UNLINK" };
		private readonly IReadOnlyList<string> _versions = new List<string> { "0.9", "1.0", "1.1" };
		private readonly IReadOnlyList<string> _protocols = new List<string> { "HTTP", "HTTPS" };
		private readonly IReadOnlyList<string> _fileExtensions = new List<string> {
			".bmp", ".jpeg", ".png", ".mp3", ".flac", ".txt", ".docx", ".yaml", ".xml",
			".html", ".cs", ".cpp", ".asm"
		};

		public IReadOnlyList<int> Codes
		{
			get { return _codes; }
		}

		public IReadOnlyList<string> Methods
		{
			get { return _methods; }
		}

		public IReadOnlyList<string> Versions
		{
			get { return _versions; }
		}

		public IReadOnlyList<string> Protocols
		{
			get { return _protocols; }
		}

		public IReadOnlyList<string> FileExtensions
		{
			get { return _fileExtensions; }
		}
	}
}