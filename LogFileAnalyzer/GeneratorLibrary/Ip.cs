using System;

namespace GeneratorLibrary
{
	public class Ip
	{
		public String generateIp()
		{
			return String.Format("{0}.{1}.{2}.{3}", Random.Instance.GetValue(0, 255), Random.Instance.GetValue(0, 255), Random.Instance.GetValue(0, 255), Random.Instance.GetValue(0, 255));
		} 
	}
}