using System;
using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;

namespace SchemaGenerator
{
	public class TableReader
	{
		readonly List<string> files;
		readonly List<string> notFound;
		readonly HashSet<string> headers;

		public TableReader ()
		{
			files = new List<string> ();
			notFound = new List<string> ();
			headers = new HashSet<string> ();
		}

		public void Read (string path)
		{
			if (!File.Exists (path)) {
				notFound.Add (path);
				return;
			}

			IWorkbook wb = WorkbookFactory.Create (path);
			ISheet sheet = wb.GetSheetAt (0);

			int column = 0;
			while (true) {
				ICell cell = sheet.GetRow (0).GetCell (column++);

				if (cell == null)
					break;

				headers.Add (cell.StringCellValue);
			}

			foreach (var h in headers) {
				Console.WriteLine (h);
			}
		}
	}
}

