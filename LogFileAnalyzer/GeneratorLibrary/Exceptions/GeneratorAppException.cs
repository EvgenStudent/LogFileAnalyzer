using System;
using System.Runtime.Serialization;

namespace GeneratorLibrary.Exceptions
{
	[Serializable]
	public abstract class GeneratorAppException : Exception
	{
		protected GeneratorAppException()
		{ }

		protected GeneratorAppException(string message) 
			: base(message)
		{ }

		protected GeneratorAppException(string message, Exception inner) 
			: base(message, inner)
		{ }

		protected GeneratorAppException(SerializationInfo info, StreamingContext context) : 
			base(info, context)
		{ }
	}
}