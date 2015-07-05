using System;

using ExcelLibrary.SpreadSheet;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace SchemaGenerator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			/*
			Workbook book = Workbook.Load ("Dictionary.xls");
			Worksheet ws = book.Worksheets.Where (w => w.Name == "URL").Single ();

			CellCollection cells = ws.Cells;

			int column = -1;
			while (true) {
				var cell = cells [0, ++column];
				if (cell.StringValue == "Путь к файлу")
					break;
			}

			var notFound = new List<string> ();
			int row = 0;
			int cnt = 0;
			while (true) {
				var cell = cells [++row, column];

				if (cell.Value == null)
					break;

				string path = cell.StringValue;
				if (!path.StartsWith ("skf"))
					continue;

				path = path.Replace ("\\", "/");
				path = Path.Combine ("/Users/rzaitov/Documents/Apps/_Bearing/", path);

				if (!File.Exists (path))
					notFound.Add (path);
				else
					cnt++;
			}

			int i = 0;
			Console.WriteLine ("Not founded:");
			foreach (var p in notFound)
				Console.WriteLine ("{0} {1}", ++i, p);

			Console.WriteLine ("Scanned rows: {0}. Found {1} files", row - 1, cnt);
			*/

			var tr = new TableReader ();
			tr.Read ("/Users/rzaitov/Documents/Apps/_Bearing/skf/Подшипники/Шариковые/Шариковые Упорные/Упорные шарикоподшипники, одинарные.xls");
		}
	}
}
