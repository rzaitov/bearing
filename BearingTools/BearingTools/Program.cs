using System;

using ExcelLibrary.SpreadSheet;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace SchemaGenerator
{
	class MainClass
	{
		const string storagePath = "/Users/rzaitov/Documents/Apps/_Bearing";
		public static void Main (string[] args)
		{
			DictionaryReader dictReader = new DictionaryReader ("Dictionary.xls", storagePath);
			DictionaryValidationReport validationReport = dictReader.Validate ();
			validationReport.Print ();

			var tr = new TableReader ();
			foreach (var p in validationReport.Founded) {
				string fullPath = Path.Combine (storagePath, p);
				tr.Read (fullPath);
			}

			foreach (var kvp in tr.Headers) {
				var files = kvp.Value;
				if (files.Count >= 3)
					Console.WriteLine ("{0}\t{1}", kvp.Key, files.Count);
				else
					Console.WriteLine ("{0}\t{1}\t{2}", kvp.Key, files.Count, string.Join(",", files));
			}

			var cMap = new ColumnMap ();
			var columnsMetaGenerator = new ColumnsMetaGenerator ();
			Console.WriteLine (columnsMetaGenerator.Generage (cMap));
		}
	}
}
