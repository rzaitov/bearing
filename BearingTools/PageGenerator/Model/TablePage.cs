using System;
using System.Collections.Generic;

namespace PageGenerator
{
	public class TablePage
	{
        public List<string> TableHeaders { get; set; }
        public List<string> Values { get; set; }

		public TablePage ()
		{
            TableHeaders = new List<string>();
            Values = new List<string>();
		}
	}
}

