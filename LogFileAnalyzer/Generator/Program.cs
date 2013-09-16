using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCommandLibrary;
using GeneratorLibrary;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			var parametrsParse = new ConsoleParametrsParse(args);
			IDictionary dictionary = parametrsParse.GetParametrs();
			var generator = new GeneratorLog(dictionary);

			generator.GenerateLogFile();
			
			//=====================
			Console.ReadKey(false);
		}
	}
}
