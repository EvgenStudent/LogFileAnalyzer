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
		private readonly ParametersForRequestLine _parameters;

		public RequestLine(Random random, ParametersForRequestLine parameters)
		{
			this.random = random;
			_parameters = parameters;
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
			return _parameters.Methods[random.Next(0, _parameters.Methods.Count)];
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
			sb.Append(_parameters.FileExtensions[random.Next(0, _parameters.FileExtensions.Count)]);
			return sb.ToString();
		}
		private string GenerateProtocol()
		{
			return String.Format("{0}/{1}", _parameters.Protocols[random.Next(0, _parameters.Protocols.Count)], _parameters.Versions[random.Next(0, _parameters.Versions.Count)]);
		}
	}
}
