using System;

namespace GeneratorLibrary
{
	public sealed class Random
	{
		private static volatile Random _instance;
		private static readonly object SyncRoot = new Object();
		public static Random Instance
		{
			get
			{
				if (_instance == null)
					lock (SyncRoot)
					{
						if (_instance == null)
							_instance = new Random();
					}
				return _instance;
			}
		}

		private Random()
		{ }

		public int GetValue(int min, int max)
		{

			var buf = Guid.NewGuid().ToByteArray();
			var randomValue32 = BitConverter.ToInt32(buf, 4);
			var val = (randomValue32 % (((max - 1) + 1) - (min))) + (min);
			return val;
		}
	}
}