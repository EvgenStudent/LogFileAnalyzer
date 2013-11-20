using System;
using System.Runtime.Serialization;

namespace GeneratorLibrary.Exceptions
{
	[Serializable]
	public class FilePathValidateException : GeneratorAppException
	{
		public FilePathValidateException()
		{
		}

		public FilePathValidateException(string message)
			: base(message)
		{
		}

		public FilePathValidateException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected FilePathValidateException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}