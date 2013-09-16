using System;

namespace GeneratorLibrary
{
	public class Frank
	{
		private readonly String[] arrayParameteres = {"-", "frank"};

		public String generateFrank()
		{
			return arrayParameteres[Random.Instance.GetValue(0, arrayParameteres.Length)];
		}
	}
}