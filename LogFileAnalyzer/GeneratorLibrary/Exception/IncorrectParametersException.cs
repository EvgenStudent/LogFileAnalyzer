using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace GeneratorLibrary.Exceptions
{
	[Serializable]
	public class IncorrectParametersException : GeneratorAppException
	{
		public IncorrectParametersException(IEnumerable<string> errorParameters)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Incorrect parameters:\n");
			int i = 1;
			foreach (string errorRecord in errorParameters)
				sb.Append(i++).Append(". ").AppendLine(errorRecord);
			Message = sb.ToString();
		}

		public IncorrectParametersException(string message) 
			: base(message)
		{ }

		public IncorrectParametersException(string message, Exception inner) 
			: base(message, inner)
		{ }

		protected IncorrectParametersException(SerializationInfo info, StreamingContext context) 
			: base(info, context)
		{ }
	}
}