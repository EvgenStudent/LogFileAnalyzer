using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleCommandLibrary
{
    public class ConsoleParametrsParse
    {
		private readonly string[] _args;
	    private readonly IDictionary<string, string> _parameters;
		private readonly IList<string> _errorParameters;

		public IReadOnlyDictionary<string, string> Parameters
	    {
		    get
		    {
				return new ReadOnlyDictionary<string, string>(_parameters);
		    }
	    }
	    public IReadOnlyList<string> ErrorParameters
	    {
		    get
		    {
				return new ReadOnlyCollection<string>(_errorParameters);
		    }
	    }

		public ConsoleParametrsParse(string[] args)
		{
			_args = args;
			_parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			_errorParameters = new List<string>();
		}

		public bool GetParameters()
		{
			string[] keyNameBuffer;
			foreach (string arg in _args)
				if (arg.Contains("--") & arg.Contains("=") & (keyNameBuffer = arg.Split(new[] { "--", "=" }, StringSplitOptions.RemoveEmptyEntries)).Length.Equals(2))
					_parameters.Add(keyNameBuffer[0], keyNameBuffer[1]);
				else
					_errorParameters.Add(arg);
			return ErrorParameters.Count == 0;
		}
    }
}
