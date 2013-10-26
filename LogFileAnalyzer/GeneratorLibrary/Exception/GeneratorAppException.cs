using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GeneratorLibrary.Exceptions
{
	[Serializable]
	public abstract class GeneratorAppException : Exception
	{
		public new string Message { get; protected set; }

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