using System;
using System.Collections.Generic;
using System.Globalization;

namespace GeneratorLibrary
{
	public class UderId : IResponse
	{
		private readonly Random random;
		private readonly IList<int> reservedId;

		public UderId(Random random, int count)
		{
			this.random = random;
			reservedId = new List<int>(count);
			for (int i = 1; i <= count; i++)
				reservedId.Add(i);
		}

		public string GetValue()
		{
			int idPosition = random.Next(0, reservedId.Count);
			int id = reservedId[idPosition];
			reservedId.RemoveAt(idPosition);
			return id.ToString(CultureInfo.InvariantCulture);
		}
	}
}