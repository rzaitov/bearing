using System;
using System.Collections.Generic;

namespace PageGenerator
{
	public class FinishPage
	{
        public List<string> Headers { get; set; }
        public List<string> Values { get; set; }

        public string Article {
            get {
                return Values.Count > 0 ? Values[0].Trim() : string.Empty;
            }
        }

        public double? Price { get; set; }

		public FinishPage ()
		{
            Headers = new List<string>();
            Values = new List<string>();
		}
	}
}

