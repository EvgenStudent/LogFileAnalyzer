using PartsRecord;

namespace ConverterOutput
{
	public class RequestLineConverter : IConverter<string>
	{
		private readonly RequestLine _requestLine;

		public RequestLineConverter(RequestLine requestLine)
		{
			_requestLine = requestLine;
		}

		public string Convert()
		{
			return "\"" + _requestLine.Method + " " + _requestLine.FullNameFile + " " + _requestLine.Protocol + "/" + _requestLine.Version + "\"";
		}
	}
}