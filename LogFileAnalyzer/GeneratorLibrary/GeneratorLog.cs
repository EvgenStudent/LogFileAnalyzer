using System;
using System.Collections;
using System.Linq;

namespace GeneratorLibrary
{
    public class GeneratorLog
    {
	    private IDictionary _dictionary;
	    private readonly String fileName;
		private readonly int records;
		private readonly Ip ip = new Ip();
		private readonly Frank frank = new Frank();
		private readonly Date date = Date.Instance;
		private readonly RequestLine requestLine = new RequestLine();
		private readonly CodeDefinition codeDefinition = new CodeDefinition();

		public GeneratorLog(IDictionary dictionary)
		{
			_dictionary = dictionary;
			foreach (DictionaryEntry entry in _dictionary)
			{
				if (entry.Key.ToString().ToLower().Contains("name") || entry.Key.ToString().ToLower().Contains("file"))
					fileName = entry.Value.ToString();
				if (entry.Key.ToString().ToLower().Contains("amount") || entry.Key.ToString().ToLower().Contains("line"))
					records = int.Parse(entry.Value.ToString());
			}
		}

	    public void GenerateLogFile()
	    {
		    String answer;
		    for (int i = 0; i < records; i++)
		    {
				answer = GenerateRecord();
				Console.WriteLine(answer);
		    }
	    }

	    private String GenerateRecord()
	    {
			String record = String.Format("{0, 15} - {1, 5} {2} {3} {4} {5}", ip.generateIp(), frank.generateFrank(), date.GetValue(), requestLine.GetRequestLine(), codeDefinition.getCode(), Random.Instance.GetValue(100, 1500));
		    return record;
	    }
    }
}
