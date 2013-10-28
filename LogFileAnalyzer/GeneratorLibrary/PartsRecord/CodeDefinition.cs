namespace GeneratorLibrary.PartsRecord
{
	public struct CodeDefinition
	{
		public int Code { get; private set; }

		public CodeDefinition(int code)
			: this()
		{
			Code = code;
		}
	}
}