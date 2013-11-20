using Config;
using GeneratorLibrary.App_Data;
using GeneratorLibrary.Generator;
using GeneratorLibrary.Random;
using PartsRecord;

namespace GeneratorLibrary
{
	public class LogRecordTemplate
	{
		private readonly CodeDefinitionGenerator _codeDefinitionGenerator;
		private readonly IData _data = new ConstantData();

		private readonly DateGenerator _dateGenerator;
		private readonly FileSizeGenerator _fileSizeGenerator;
		private readonly HyphenGenerator _hyphenGenerator;
		private readonly IpAddressGenerator _ipAddressGenerator;
		private readonly RandomWithProbability _random = new RandomWithProbability();
		private readonly RequestLineGenerator _requestLineGenerator;
		private readonly UserIdGenerator _userIdGenerator;

		public LogRecordTemplate()
		{
			_ipAddressGenerator = new IpAddressGenerator(_random, _data.UniqueIpCount);
			_hyphenGenerator = new HyphenGenerator();
			_userIdGenerator = new UserIdGenerator(_random);
			_dateGenerator = new DateGenerator(_random);
			_requestLineGenerator = new RequestLineGenerator(_random, _data.RequestLineParameters);
			_codeDefinitionGenerator = new CodeDefinitionGenerator(_random, _data.Codes);
			_fileSizeGenerator = new FileSizeGenerator(_random);
		}

		public LogRecordTemplate(StructureConfig configParameters)
		{
			_data.SetProbability(configParameters);
			_ipAddressGenerator = new IpAddressGenerator(_random, _data.UniqueIpCount);
			_hyphenGenerator = new HyphenGenerator();
			_userIdGenerator = new UserIdGenerator(_random);
			_dateGenerator = new DateGenerator(_random);
			_requestLineGenerator = new RequestLineGenerator(_random, _data.RequestLineParameters);
			_codeDefinitionGenerator = new CodeDefinitionGenerator(_random, _data.Codes);
			_fileSizeGenerator = new FileSizeGenerator(_random);
		}

		public LogRecordParts GenerateRecord()
		{
			var recordParts = new LogRecordParts
			{
				IpAddress = _ipAddressGenerator.Generate(),
				Hyphen = _hyphenGenerator.Generate(),
				UserId = _userIdGenerator.Generate(),
				Date = _dateGenerator.Generate(),
				RequestLine = _requestLineGenerator.Generate(),
				CodeDefinition = _codeDefinitionGenerator.Generate(),
				FileSize = _fileSizeGenerator.Generate(),
			};
			return recordParts;
		}
	}
}