using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleCommandLibrary
{
    public class ConsoleParametrsParse
    {
		private readonly string[] _args;
		public IDictionary<string, string> Parameters { get; private set; }
		public IList<string> ErrorParameters { get; private set; }

		public ConsoleParametrsParse(string[] args)
		{
			_args = args;
			Parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			ErrorParameters = new List<string>();
		}

		public bool GetParameters()
		{
			string[] keyNameBuffer;
			foreach (string arg in _args)
				if (arg.Contains("--") & arg.Contains("=") & (keyNameBuffer = arg.Split(new[] { "--", "=" }, StringSplitOptions.RemoveEmptyEntries)).Length.Equals(2))
					Parameters.Add(keyNameBuffer[0], keyNameBuffer[1]);
				else
					ErrorParameters.Add(arg);
			return ErrorParameters.Count == 0;
		}
    }
}
