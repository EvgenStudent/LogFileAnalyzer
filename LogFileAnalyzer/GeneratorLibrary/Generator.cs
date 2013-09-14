using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLibrary
{
    public class Generator
    {
	    private IDictionary _dictionary;

		public Generator(IDictionary dictionary)
		{
			_dictionary = dictionary;
		}
    }
}
