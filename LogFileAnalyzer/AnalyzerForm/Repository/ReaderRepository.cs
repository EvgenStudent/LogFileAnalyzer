using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.Reader;

namespace AnalyzerForm.Repository
{
	public class ReaderRepository
	{
		private readonly IDictionary<string, IReader> _repository = new Dictionary<string, IReader>
		{
			{Keys.FileExtension.Log, new LogReader()},
			{Keys.FileExtension.Txt, new LogReader()},
		};

		public IReader this[string key]
		{
			get { return _repository[key]; }
		}
	}
}