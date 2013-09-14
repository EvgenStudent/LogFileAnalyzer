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

		public int GenerateValue(int min, int max)
		{
			return BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 4) % max + min; 
		}
	}
}