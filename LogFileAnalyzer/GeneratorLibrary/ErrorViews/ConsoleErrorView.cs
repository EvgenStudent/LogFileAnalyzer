using System;
using GeneratorLibrary.Exceptions;

namespace GeneratorLibrary.View
{
	public class ConsoleErrorView : IErrorView
	{
		private readonly GeneratorAppException _exception;

		public ConsoleErrorView(GeneratorAppException exception)
		{
			_exception = exception;
		}

		public void DisplayMessage()
		{
			Console.WriteLine(_exception.Message);
			Console.ReadKey(true);
		}

		public void DisplayStack()
		{
			Console.WriteLine(_exception.StackTrace);
			Console.ReadKey(true);
		}
	}
}