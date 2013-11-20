using System;
using System.Text;
using GeneratorLibrary.Model;
using GeneratorLibrary.Random;
using PartsRecord;

namespace GeneratorLibrary.Generator
{
	public class RequestLineGenerator : IGenerator<RequestLine>
	{
		private readonly RequestLineParameters _parameters;
		private readonly RandomWithProbability _random;

		public RequestLineGenerator(RandomWithProbability random, RequestLineParameters parameters)
		{
			_random = random;
			_parameters = parameters;
		}

		public RequestLine Generate()
		{
			return new RequestLine(GenerateMethod(), GenerateFullNameFile(), GenerateProtocol(), GenerateVersion());
		}

		private string GenerateMethod()
		{
			return _random.Next(_parameters.Methods);
		}

		private string GenerateFullNameFile()
		{
			var sb = new StringBuilder();
			int count = _random.Next(1, 4);
			for (int i = 0; i < count; i++)
			{
				sb.Append("/");
				for (int j = 0; j < _random.Next(3, 7); j++)
					sb.Append(Convert.ToChar(_random.Next(0x0061, 0x007B)));
			}
			sb.Append(".").Append(_random.Next(_parameters.FileExtensions));
			return sb.ToString();
		}

		private string GenerateProtocol()
		{
			return _random.Next(_parameters.Protocols);
		}

		private string GenerateVersion()
		{
			return _random.Next(_parameters.Versions);
		}
	}
}