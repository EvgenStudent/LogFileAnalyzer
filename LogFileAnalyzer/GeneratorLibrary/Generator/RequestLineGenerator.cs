using GeneratorLibrary.Model;
using GeneratorLibrary.PartsRecord;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.Generator
{
	public class RequestLineGenerator : IGenerator<RequestLine>
	{
		private readonly RandomWithProbability _random;
		private readonly RequestLineParameters _parameters;

		public RequestLineGenerator(RandomWithProbability random, RequestLineParameters parameters)
		{
			_random = random;
			_parameters = parameters;
		}

		public RequestLine Generate()
		{
			throw new System.NotImplementedException();
		}
	}
}