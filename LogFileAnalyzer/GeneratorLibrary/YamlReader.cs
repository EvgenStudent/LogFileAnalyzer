using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace GeneratorLibrary
{
	public class YamlReader
	{
		private readonly YamlStream _yamlStream;
	
		public YamlReader(FileSystemInfo file)
		{
			_yamlStream = new YamlStream();
			string fileContext = GetContentYamlFile(file.FullName);
			_yamlStream.Load(new StringReader(fileContext));
			/////
			var mapping = (YamlMappingNode)_yamlStream.Documents[0].RootNode;
			foreach (var entry in mapping.Children)
			{
				Console.WriteLine(((YamlScalarNode)entry.Key).Value);
			}
		} 

		public IDictionary<string, string> GetParameters
		{
			get
			{
				var mapping = (YamlMappingNode)_yamlStream.Documents[0].RootNode;
				IDictionary<string, string> dictionary = 
					mapping.Children.ToDictionary(key => key.Key.ToString(), value => value.Value.ToString());
				return dictionary;
			}
		} 
		private string GetContentYamlFile(string path)
		{
			StringBuilder stringBuilder = new StringBuilder();

			var lines = File.ReadAllLines(path);
			foreach (var line in lines)
				stringBuilder.Append(line + "\n");

			return stringBuilder.ToString();
		}
	}
}