using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Config;
using GeneratorLibrary.Exceptions;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;

namespace GeneratorLibrary.Reader
{
	public class YamlConfigReader : IConfigReader
	{
		private readonly YamlStream _yamlStream;

		public YamlConfigReader(string path)
		{
			_yamlStream = new YamlStream();
			string fileContext = GetContentYamlFile(path);
			try
			{
				_yamlStream.Load(new StringReader(fileContext));
			}
			catch (SyntaxErrorException exception)
			{
				throw new DataSourseException("Incorrect config file.", exception);
			}
		}

		public StructureConfig Parameters
		{
			get
			{
				var mapping = (YamlMappingNode) _yamlStream.Documents[0].RootNode;
				ICollection<YamlNode> keys = mapping.Children.Keys;
				var dictionary = new Dictionary<string, IDictionary<string, string>>(StringComparer.InvariantCultureIgnoreCase);
				Dictionary<string, string> tempDictionary;

				foreach (YamlNode key in keys)
				{
					var parameters = (YamlMappingNode) mapping.Children[new YamlScalarNode(key.ToString())];
					tempDictionary = parameters.ToDictionary(pair => pair.Key.ToString(), pair => pair.Value.ToString(),
						StringComparer.InvariantCultureIgnoreCase);
					dictionary.Add(key.ToString(), tempDictionary);
				}
				return new StructureConfig(dictionary);
			}
		}

		private string GetContentYamlFile(string path)
		{
			var stringBuilder = new StringBuilder();

			string[] lines = File.ReadAllLines(path);
			foreach (string line in lines)
				stringBuilder.Append(line.Replace("\t", "    ") + "\n");

			return stringBuilder.ToString();
		}
	}
}