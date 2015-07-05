using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaGenerator
{
	public class DictionaryValidationReport
	{
		public List<string> Founded { get; private set; }
		public List<string> NotFound { get; private set; }

		public DictionaryValidationReport ()
		{
			Founded = new List<string> ();
			NotFound = new List<string> ();
		}

		public void Print ()
		{
			Console.WriteLine (ToString());
		}

		public override string ToString ()
		{
			var sb = new StringBuilder ();
			sb.AppendLine ("Not founded:");

			int i = 0;
			foreach (var p in NotFound)
				sb.AppendFormat ("{0} {1}", ++i, p).AppendLine ();


			sb.AppendFormat ("Found {0} files", Founded.Count);

			return sb.ToString ();
		}
	}
}

