using System;
using System.IO;
using NPOI.SS.UserModel;
using System.Collections.Generic;

namespace SchemaGenerator
{
	public class DictionaryReader
	{
		readonly ISheet sheet;
		readonly string storagePath;

		public DictionaryReader (string path, string storagePath)
		{
			if (!File.Exists (path))
				throw new FileNotFoundException ();

			if (!Directory.Exists (storagePath))
				throw new DirectoryNotFoundException ();

			IWorkbook wb = WorkbookFactory.Create (path);
			sheet = wb.GetSheet("URL");

			this.storagePath = storagePath;
		}

		public DictionaryValidationReport Validate ()
		{
			int column = -1;
			while (true) {
				var cell = sheet.GetRow (0).GetCell (++column);
				if (cell.StringCellValue == "Path")
					break;
			}

			var report = new DictionaryValidationReport ();

			int rowIndex = 0;
			while (true) {
				var row = sheet.GetRow (++rowIndex);
				if (row == null)
					break;

				var cell = row.GetCell (column);
				if (cell == null)
					break;

				report.Count++;

				string path = cell.StringCellValue;
				if (!path.StartsWith ("skf"))
					continue;

				path = path.Replace ("\\", "/");
				path = Path.Combine (storagePath, path);

				if (!File.Exists (path))
					report.NotFound.Add (path);
				else
					report.Founded.Add (path);
			}

			return report;
		}
	}
}

