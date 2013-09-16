using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLibrary
{
	class CodeDefinition
	{
		private readonly int[] codes =
		{
			100, 101, 200, 201, 202, 203, 204, 205, 206, 300, 301, 302, 303, 304, 305, 306, 307, 400, 401,
			402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414, 415, 416, 417, 500, 501, 502, 503, 504, 505
		};

		public int getCode()
		{
			return codes[Random.Instance.GetValue(0, codes.Length)];
		}
	}
}
