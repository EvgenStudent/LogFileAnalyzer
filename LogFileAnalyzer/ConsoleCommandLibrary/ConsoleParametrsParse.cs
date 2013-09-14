using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleCommandLibrary
{
    public class ConsoleParametrsParse
    {
		private readonly String[] _args;
		private readonly IDictionary _map; 

		public ConsoleParametrsParse(String[] args)
		{
			_args = args;
			_map = new Dictionary<String, String>();
		}

		public IDictionary GetParametrs()
		{
			string[] nameAndValue;
			foreach (var arg in _args)
			{
				nameAndValue = arg.Split(new[] { "--(", "=", ")" }, StringSplitOptions.RemoveEmptyEntries);
				_map.Add(nameAndValue[0], nameAndValue[1]);
			}
			return _map;
		}
    }
}
