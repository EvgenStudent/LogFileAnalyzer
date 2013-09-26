using System;
using System.Collections.Generic;
using GeneratorLibrary.App_Data;
using GeneratorLibrary.Response;

namespace GeneratorLibrary
{
    public class GeneratorLog
    {
	    private readonly string[] keys = {"fileName", "count"};
	    private readonly IDictionary<string, string> consoleParameters;
	    private readonly Random random;
		public IResponse[] TemplateResponse { set; get; }

		public string FileName
		{
			get
			{
				return consoleParameters[keys[0]];
			}
		}
		public int Count
		{
			get
			{
				return int.Parse(consoleParameters[keys[1]]);
			}
		}

		public GeneratorLog(IDictionary<string, string> consoleParameters)
		{
			this.consoleParameters = consoleParameters;
			random = new RandomGuid();
			CreateTemplateResponse();
		}

	    private void CreateTemplateResponse()
	    {
		    TemplateResponse = new IResponse[]
		    {
			    new Ip(random), 
				new Hyphen(), 
				new UderId(random, Count), 
				new Date(random), 
				new RequestLine(random, Data.Methods, Data.FileExtensions, Data.Protocols, Data.Versions), 
				new CodeDefinition(random, Data.Codes), 
				new FileSize(random), 
		    };
	    }
    }
}
