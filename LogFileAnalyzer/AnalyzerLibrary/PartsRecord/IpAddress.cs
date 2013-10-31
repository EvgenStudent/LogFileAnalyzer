namespace AnalyzerLibrary.PartsRecord
{
	public struct IpAddress
	{
		public byte A { get; private set; }
		public byte B { get; private set; }
		public byte C { get; private set; }
		public byte D { get; private set; }

		public IpAddress(byte a, byte b, byte c, byte d) 
			: this()
		{
			A = a;
			B = b;
			C = c;
			D = d;
		}
	}
}