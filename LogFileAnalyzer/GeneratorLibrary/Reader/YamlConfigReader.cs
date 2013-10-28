using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GeneratorLibrary.Model;
using YamlDotNet.RepresentationModel;

namespace GeneratorLibrary.Reader
{
	public class YamlConfigReader : IConfigReader
	{
		private readonly YamlStream _yamlStream;

		public StructureConfig Parameters
		{
			get
			{
				var mapping = (YamlMappingNode)_yamlStream.Documents[0].RootNode;
				var keys = mapping.Children.Keys;
				IDictionary<string, IDictionary<string, int>> dictionary = new Dictionary<string, IDictionary<string, int>>(StringComparer.InvariantCultureIgnoreCase);
				IDictionary<string, int> tempDictionary;

				foreach (YamlNode key in keys)
				{
					var parameters = (YamlMappingNode)mapping.Children[new YamlScalarNode(key.ToString())];
					tempDictionary = parameters.ToDictionary(pair => pair.Key.ToString(), pair => Convert.ToInt32(pair.Value.ToString()), StringComparer.InvariantCultureIgnoreCase);
					dictionary.Add(key.ToString(), tempDictionary);
				}
				return new StructureConfig(dictionary);
			}
		}

		public YamlConfigReader(string path)
		{
			_yamlStream = new YamlStream();
			string fileContext = GetContentYamlFile(path);
			_yamlStream.Load(new StringReader(fileContext));
		}

		private string GetContentYamlFile(string path)
		{
			var stringBuilder = new StringBuilder();

			var lines = File.ReadAllLines(path);
			foreach (var line in lines)
				stringBuilder.Append(line + "\n");

			return stringBuilder.ToString();
		}
	}
}