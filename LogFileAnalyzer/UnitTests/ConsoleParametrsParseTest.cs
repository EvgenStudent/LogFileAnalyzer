using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleCommandLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class ConsoleParametrsParseTest
	{
		[TestMethod]
		public void GetParameters()
		{
			// arrange
			string[] args = new[] {"--fileName=logs", "--count=100", "--three=", "--", "ololo"};

			// act
			ConsoleParametrsParse parametrsParse = new ConsoleParametrsParse(args);
			bool correctComplete = parametrsParse.GetParameters();
			IDictionary<string, string> Parameters = parametrsParse.Parameters.ToDictionary(x => x.Key, x=> x.Value);
			IList<string> ErrorParameters = parametrsParse.ErrorParameters.ToList();

			// assert
			Assert.IsFalse(correctComplete);
			Assert.AreEqual(ErrorParameters.Count, 3);
			Assert.AreEqual(Parameters.Count, 2);

			for (int i = 0; i < ErrorParameters.Count; i++)
				Assert.AreEqual(ErrorParameters[i], args[i + 2]);

			int count = 0;
			foreach (KeyValuePair<string, string> pair in Parameters)
			{
				string[] argKeyName = args[count++].Split(new[] {"--", "="}, StringSplitOptions.RemoveEmptyEntries);
				Assert.AreEqual(pair.Key, argKeyName[0]);
				Assert.AreEqual(pair.Value, argKeyName[1]);
			}
		}
	}
}
