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
		public IncorrectParametersException(IEnumerable<string> readOnlyList)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string errorRecord in readOnlyList)
				sb.Append(errorRecord).Append(Environment.NewLine);
			sb.ToString();
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