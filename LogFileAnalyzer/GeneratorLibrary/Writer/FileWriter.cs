using System;
using System.IO;
using System.Text;

namespace GeneratorLibrary.Writer
{
	public class FileWriter
	{
		private readonly string _pathDirectory;

		public FileWriter()
		{
			_pathDirectory = String.Empty;
		}
		public FileWriter(DirectoryInfo directoryInfo)
		{
			if (directoryInfo.Exists == false)
				directoryInfo.Create();
			_pathDirectory = (directoryInfo.FullName.EndsWith(@"\")) ? directoryInfo.FullName : (directoryInfo.FullName + @"\");
		}

		public void Write(IResponse[] responses, string fileName, int count)
		{
			using (StreamWriter file = new StreamWriter(_pathDirectory + fileName + @".log", false, Encoding.UTF8))
			{
				for (int i = 0; i < count; i++)
				{
					foreach (IResponse response in responses)
						file.Write(response.GetValue() + " ");
					file.WriteLine("\n");
				}
			}
		}
	}
}