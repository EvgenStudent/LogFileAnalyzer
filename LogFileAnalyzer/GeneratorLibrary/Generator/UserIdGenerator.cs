using GeneratorLibrary.PartsRecord;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.Generator
{
	public class UserIdGenerator : IGenerator<UserId>
	{
		private readonly RandomWithProbability _random;

		public UserIdGenerator(RandomWithProbability random)
		{
			_random = random;
		}

		public UserId Generate()
		{
			throw new System.NotImplementedException();
		}
	}
}