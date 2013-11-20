using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GeneratorLibrary.Exceptions
{
	[Serializable]
	public class IncorrectParametersException : GeneratorAppException
	{
		private readonly string _message;

		public IncorrectParametersException(IEnumerable<string> errorParameters)
		{
			var sb = new StringBuilder();
			sb.Append("Incorrect parameters:\n");
			int i = 1;
			foreach (string errorRecord in errorParameters)
				sb.Append(i++).Append(". ").AppendLine(errorRecord);
			_message = sb.ToString();
		}

		public IncorrectParametersException(string message)
			: base(message)
		{
		}

		public IncorrectParametersException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected IncorrectParametersException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public override string Message
		{
			get { return _message; }
		}
	}
}