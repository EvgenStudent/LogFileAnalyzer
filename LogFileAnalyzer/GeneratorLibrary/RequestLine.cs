using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLibrary
{
	class RequestLine
	{
		private readonly String[] methods = { "OPTIONS", "GET", "HEAD", "POST", "PUT", "DELETE", "TRACE", "CONNECT", "PATCH", "LINK", "UNLINK" };
		private readonly Double[] versions = { 0.9, 1.0, 1.1 };
		private readonly String[] protocols = { "HTTP", "HTTPS" };
		private readonly String[] fileExtension =
		{
			".get", ".jpeg", ".png", ".mp3", ".flac", ".txt", ".docx", ".yaml", ".xml",
			".html", ".cs", ".cpp", ".asm"
		};
		
		private String GetMethod()
		{
			return methods[Random.Instance.GetValue(0, methods.Length)];
		}
		private Double GetVersion()
		{
			return versions[Random.Instance.GetValue(0, versions.Length)];
		}
		private String GetProtocol()
		{
			return protocols[Random.Instance.GetValue(0, protocols.Length)];
		}
		private String GetPathFile()
		{
			StringBuilder sb = new StringBuilder();
			System.Random random = new System.Random();
			int size = Random.Instance.GetValue(1, 3);
			//todo Учесть момент, когда файл не качается, т.е. просто пустое местов  логе будет
			for (int i = 0; i < size; i++)
			{
				int amount = Random.Instance.GetValue(3, 7);
				for (int j = 0; j < amount; j++)
					sb.Append(Convert.ToChar(Random.Instance.GetValue(0x005F, 0x007B)));
				if (i != size - 1)
					sb.Append("/");
			}
			sb.Append(fileExtension[Random.Instance.GetValue(0, fileExtension.Length)]);
			return sb.ToString();
		}

		public String GetRequestLine()
		{
			String value = String.Format("\"{0} {1} {2}/{3:F1}\"", GetMethod(), GetPathFile(), GetProtocol(), GetVersion());
			return value;
		}	
	}
}
