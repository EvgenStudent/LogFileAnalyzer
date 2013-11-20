using System;
using System.Runtime.Serialization;

namespace GeneratorLibrary.Exceptions
{
	[Serializable]
	public class NoParameterException : GeneratorAppException
	{
		public NoParameterException()
		{
		}

		public NoParameterException(string message)
			: base(message)
		{
		}

		public NoParameterException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected NoParameterException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}