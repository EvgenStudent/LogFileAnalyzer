using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AnalyzerLibrary.Reader
{
	public class LogReader : IReader
	{
		public string[] Read(string path)
		{
			IList<string> logRecords = new List<string>();
			using (var file = new StreamReader(path, Encoding.UTF8))
			{
				for ( ; file.Peek() != -1; )
					logRecords.Add(file.ReadLine());
			}
			return logRecords.ToArray();
		}
	}
}