using System.Collections.Generic;
using System.Globalization;
using Config;
using GeneratorLibrary.Constant;
using GeneratorLibrary.Model;

namespace GeneratorLibrary.App_Data
{
	public class ConstantData : IData
	{
		private readonly List<ElementWithProbability<int>> _codes = new List<ElementWithProbability<int>>
		{
			#region Codes
			new ElementWithProbability<int>(100),
			new ElementWithProbability<int>(101),
			new ElementWithProbability<int>(200),
			new ElementWithProbability<int>(201),
			new ElementWithProbability<int>(202),
			new ElementWithProbability<int>(203),
			new ElementWithProbability<int>(204),
			new ElementWithProbability<int>(205),
			new ElementWithProbability<int>(206),
			new ElementWithProbability<int>(300),
			new ElementWithProbability<int>(301),
			new ElementWithProbability<int>(302),
			new ElementWithProbability<int>(303),
			new ElementWithProbability<int>(304),
			new ElementWithProbability<int>(305),
			new ElementWithProbability<int>(306),
			new ElementWithProbability<int>(307),
			new ElementWithProbability<int>(400),
			new ElementWithProbability<int>(401),
			new ElementWithProbability<int>(402),
			new ElementWithProbability<int>(403),
			new ElementWithProbability<int>(404),
			new ElementWithProbability<int>(405),
			new ElementWithProbability<int>(406),
			new ElementWithProbability<int>(407),
			new ElementWithProbability<int>(408),
			new ElementWithProbability<int>(409),
			new ElementWithProbability<int>(410),
			new ElementWithProbability<int>(411),
			new ElementWithProbability<int>(412),
			new ElementWithProbability<int>(413),
			new ElementWithProbability<int>(414),
			new ElementWithProbability<int>(415),
			new ElementWithProbability<int>(416),
			new ElementWithProbability<int>(417),
			new ElementWithProbability<int>(500),
			new ElementWithProbability<int>(501),
			new ElementWithProbability<int>(502),
			new ElementWithProbability<int>(503),
			new ElementWithProbability<int>(504),
			new ElementWithProbability<int>(505),
			#endregion
		};

		private readonly RequestLineParameters _requestLineParameters = new RequestLineParameters
		{
			#region Methods
			Methods = new List<ElementWithProbability<string>>
			{
				new ElementWithProbability<string>("OPTIONS"), 
				new ElementWithProbability<string>("GET"), 
				new ElementWithProbability<string>("HEAD"), 
				new ElementWithProbability<string>("POST"), 
				new ElementWithProbability<string>("PUT"), 
				new ElementWithProbability<string>("DELETE"), 
				new ElementWithProbability<string>("TRACE"), 
				new ElementWithProbability<string>("CONNECT"), 
				new ElementWithProbability<string>("PATCH"), 
				new ElementWithProbability<string>("LINK"), 
				new ElementWithProbability<string>("UNLINK"), 
			},
			#endregion

			#region Versions
			Versions = new List<ElementWithProbability<string>>
			{
				new ElementWithProbability<string>("0.9"), 
				new ElementWithProbability<string>("1.0"), 
				new ElementWithProbability<string>("1.1"), 
			},
			#endregion

			#region Protocols
			Protocols = new List<ElementWithProbability<string>>
			{
				new ElementWithProbability<string>("HTTP"), 
				new ElementWithProbability<string>("HTTPS"), 
			},
			#endregion

			#region FileExtensions
			FileExtensions = new List<ElementWithProbability<string>>
			{
				new ElementWithProbability<string>("bmp"), 
				new ElementWithProbability<string>("jpeg"), 
				new ElementWithProbability<string>("png"), 
				new ElementWithProbability<string>("mp3"), 
				new ElementWithProbability<string>("flac"), 
				new ElementWithProbability<string>("txt"), 
				new ElementWithProbability<string>("docx"), 
				new ElementWithProbability<string>("yaml"), 
				new ElementWithProbability<string>("xml"), 
				new ElementWithProbability<string>("html"), 
				new ElementWithProbability<string>("cs"), 
				new ElementWithProbability<string>("cpp"), 
				new ElementWithProbability<string>("asm"), 
			},
			#endregion
		};

		public IReadOnlyList<ElementWithProbability<int>> Codes
		{
			get { return _codes; }
		}

		public RequestLineParameters RequestLineParameters
		{
			get { return _requestLineParameters; }
		}

		public void SetProbability(StructureConfig config)
		{
			if (config.ContainsKey(Keys.Codes))
				foreach (ElementWithProbability<int> code in _codes)
					code.Probability = config[Keys.Codes].ContainsKey(code.Value.ToString(CultureInfo.InvariantCulture)) ? config[Keys.Codes].CastValueToInt()[code.Value.ToString(CultureInfo.InvariantCulture)] : 0;

			if (config.ContainsKey(Keys.Methods))
				foreach (ElementWithProbability<string> method in _requestLineParameters.Methods)
					method.Probability = config[Keys.Methods].ContainsKey(method.Value) ? config[Keys.Methods].CastValueToInt()[method.Value] : 0;

			if (config.ContainsKey(Keys.Versions))
				foreach (ElementWithProbability<string> version in _requestLineParameters.Versions)
					version.Probability = config[Keys.Versions].ContainsKey(version.Value) ? config[Keys.Versions].CastValueToInt()[version.Value] : 0;

			if (config.ContainsKey(Keys.Protocols))
				foreach (ElementWithProbability<string> protocol in _requestLineParameters.Protocols)
					protocol.Probability = config[Keys.Protocols].ContainsKey(protocol.Value) ? config[Keys.Protocols].CastValueToInt()[protocol.Value] : 0;

			if (config.ContainsKey(Keys.FileExtensions))
				foreach (ElementWithProbability<string> extension in _requestLineParameters.FileExtensions)
					extension.Probability = config[Keys.FileExtensions].ContainsKey(extension.Value) ? config[Keys.FileExtensions].CastValueToInt()[extension.Value] : 0;
		}
	}
}