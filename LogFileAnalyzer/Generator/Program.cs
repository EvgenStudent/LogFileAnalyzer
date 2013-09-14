using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCommandLibrary;

namespace Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleParametrsParse parametrsParse = new ConsoleParametrsParse(args);
			IDictionary dictionary = parametrsParse.GetParametrs();

			Console.WriteLine("123");
		
			//=====================
			Console.ReadKey(false);
		}
	}
}
