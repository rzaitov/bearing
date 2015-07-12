using System;
using System.Collections.Generic;

namespace PageGenerator
{
	public class FinishPage
	{
        public List<string> Headers { get; set; }
        public List<string> Values { get; set; }

		public FinishPage ()
		{
            Headers = new List<string>();
            Values = new List<string>();
		}
	}
}

