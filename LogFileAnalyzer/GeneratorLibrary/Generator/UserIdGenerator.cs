using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GeneratorLibrary.PartsRecord;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.Generator
{
	public class UserIdGenerator : IGenerator<UserId>
	{
		private readonly RandomWithProbability _random;
		private readonly List<int> _reservedId;

		public UserIdGenerator(RandomWithProbability random)
		{
			_random = random;
			_reservedId = Enumerable.Range(1, 1000).ToList();
		}

		public UserId Generate()
		{
			int idPosition = _random.Next(0, _reservedId.Count);
			int id = _reservedId[idPosition];
			_reservedId.RemoveAt(idPosition);
			return new UserId(id);
		}
	}
}