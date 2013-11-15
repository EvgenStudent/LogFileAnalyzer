using System.Collections.Generic;

namespace AnalyzerLibrary.Reports
{
	public class Report<T>
	{
		public Report(IList<T> structure)
		{
			Structure = structure;
		}

		public IList<T> Structure { get; private set; }
	}
}