using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorLibrary.Response;

namespace GeneratorLibrary
{
	class RequestLine : IRecordFieldValueGenerator
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

		public string Generate()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("\"");
			sb.Append(GenerateMethod()).Append(" ");
			sb.Append(GeneratePathFile()).Append(" ");
			sb.Append(GenerateProtocol());
			sb.Append("\"");
			return sb.ToString();
		}

		private string GenerateMethod()
		{
			return Methods[random.Next(0, Methods.Length)];
		}
		private string GeneratePathFile()
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
		private string GenerateProtocol()
		{
			return String.Format("{0}/{1}", Protocols[random.Next(0, Protocols.Length)], Versions[random.Next(0, Versions.Length)]);
		}
	}
}
