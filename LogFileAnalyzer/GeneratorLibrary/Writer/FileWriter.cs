using System;
using System.IO;
using System.Text;
using GeneratorLibrary.Response;

namespace GeneratorLibrary.Writer
{
	public class FileWriter
	{
		public void Write(IRecordFieldValueGenerator[] recordFieldValueGenerators, string fileName, int count)
		{
			using (StreamWriter file = new StreamWriter(fileName, false, Encoding.UTF8))
			{
				for (int i = 0; i < count; i++)
				{
					foreach (IRecordFieldValueGenerator response in recordFieldValueGenerators)
						file.Write(response.Generate() + " ");
					if (i != count -1)
						file.Write(Environment.NewLine);
				}
			}
		}
	}
}