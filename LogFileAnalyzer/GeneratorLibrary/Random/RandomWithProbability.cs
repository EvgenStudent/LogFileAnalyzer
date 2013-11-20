using System;
using System.Collections.Generic;
using System.Linq;
using GeneratorLibrary.Model;

namespace GeneratorLibrary.Random
{
	public class RandomWithProbability
	{
		public int Next(int minValue, int maxValue)
		{
			if (maxValue == 0)
				return maxValue;
			return (BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 4)%(((maxValue - 1) + 1) - (minValue))) + (minValue);
		}

		public T Next<T>(IReadOnlyList<ElementWithProbability<T>> elements)
		{
			var mapProbability = new Dictionary<int, ElementWithProbability<T>>(elements.Sum(x => x.Probability));

			int i = 1;
			foreach (var element in elements)
				for (int j = 0; j < element.Probability; j++, i++)
					mapProbability.Add(i, element);

			int randValue = Next(1, mapProbability.Count + 1);
			return mapProbability[randValue].Value;
		}
	}
}