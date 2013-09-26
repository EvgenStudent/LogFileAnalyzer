using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLibrary
{
	class RequestLine : IResponse
	{
		private readonly Random random;
		private readonly string[] Methods;
		private readonly string[] Versions;
		private readonly string[] Protocols;
		private readonly string[] FileExtension;

		public RequestLine(Random random, string[] methods, string[] fileExtension, string[] protocols, string[] versions)
		{
			this.random = random;
			Methods = methods;
			FileExtension = fileExtension;
			Protocols = protocols;
			Versions = versions;
		}

		public string GetValue()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("\"");
			sb.Append(generateMethod()).Append(" ");
			sb.Append(generatePathFile()).Append(" ");
			sb.Append(generateProtocol());
			sb.Append("\"");
			return sb.ToString();
		}

		private string generateMethod()
		{
			return Methods[random.Next(0, Methods.Length)];
		}
		private string generatePathFile()
		{
			StringBuilder sb = new StringBuilder();
			int count = random.Next(1, 4);
			for (int i = 0; i < random.Next(1, 4); i++)
			{
				sb.Append("/");
				for (int j = 0; j < random.Next(3, 7); j++)
					sb.Append(Convert.ToChar(random.Next(0x0061, 0x007B)));
			}
			sb.Append(FileExtension[random.Next(0, FileExtension.Length)]);
			return sb.ToString();
		}
		private string generateProtocol()
		{
			return String.Format("{0}/{1}", Protocols[random.Next(0, Protocols.Length)], Versions[random.Next(0, Versions.Length)]);
		}
	}
}
