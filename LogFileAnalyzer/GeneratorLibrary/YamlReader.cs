using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using GeneratorLibrary.Exceptions;
using YamlDotNet.RepresentationModel;

namespace GeneratorLibrary
{
	public class YamlReader
	{
		private readonly YamlStream _yamlStream;

		public YamlReader(FileInfo file)
		{
			_yamlStream = new YamlStream();
			string fileContext = GetContentYamlFile(file.FullName);
			_yamlStream.Load(new StringReader(fileContext));
		}

		public ConfigYaml GetParameters
		{
			get
			{
				var mapping = (YamlMappingNode)_yamlStream.Documents[0].RootNode;
				var keys = mapping.Children.Keys;
				IDictionary<string, IDictionary<string, string>> dictionary = new Dictionary<string, IDictionary<string, string>>();
				IDictionary<string, string> tempDictionary;

				foreach (YamlNode key in keys)
				{
					var parameters = (YamlMappingNode)mapping.Children[new YamlScalarNode(key.ToString())];
					tempDictionary = parameters.ToDictionary(pair => pair.Key.ToString(), pair => pair.Value.ToString());
					dictionary.Add(key.ToString(), tempDictionary);
				}
				return new ConfigYaml(dictionary);
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

		private bool ValidateFilePath(string path)
		{
			return Regex.IsMatch(path, @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");
		}
	}
}