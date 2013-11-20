using System.Collections.Generic;
using System.Linq;
using GeneratorLibrary.Random;
using PartsRecord;

namespace GeneratorLibrary.Generator
{
	public class UserIdGenerator : IGenerator<UserId>
	{
		private readonly RandomWithProbability _random;
		private List<int> _reservedId;
		private int count = 1;
		private int countIncrement = 500;

		public UserIdGenerator(RandomWithProbability random)
		{
			_random = random;
			_reservedId = Enumerable.Range(count, count + countIncrement).ToList();
		}

		public UserId Generate()
		{
			if (_reservedId.Count == 0)
			{
				count += countIncrement;
				_reservedId = Enumerable.Range(count, count + countIncrement).ToList();
			}
			int idPosition = _random.Next(0, _reservedId.Count);
			int id = _reservedId[idPosition];
			_reservedId.RemoveAt(idPosition);
			return new UserId(id);
		}
	}
}