namespace GeneratorLibrary.PartsRecord
{
	public struct FileSize
	{
		public int Size { get; private set; }

		public FileSize(int size)
			: this()
		{
			Size = size;
		}
	}
}