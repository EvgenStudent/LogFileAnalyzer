using System;
using System.Runtime.Serialization;

namespace GeneratorLibrary.Exceptions
{
	[Serializable]
	public class DataSourseException : GeneratorAppException
	{
		public DataSourseException()
		{
		}

		public DataSourseException(string message)
			: base(message)
		{
		}

		public DataSourseException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected DataSourseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}