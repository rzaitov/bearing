using System;
using System.Collections.Generic;

namespace PageGenerator
{
	public class FinishPage
	{
        public List<string> Headers { get; set; }
        public List<string> Values { get; set; }

        string article;
        public string Article {
            get {
                if(article == null)
                    article = Values.Count > 0 ? Values[0].Trim() : string.Empty;

                return article;
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

