using System;
using System.IO;
using NPOI.SS.UserModel;
using System.Collections.Generic;

namespace SchemaGenerator
{
	public class DictionaryReader
	{
		class ColumnIndexes
		{
			public int Path { get; set; }
			public int Description { get; set; }
			public int Img { get; set; }
		}

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
			var report = new DictionaryValidationReport ();
			IEnumerable<DictionaryItem> items = Read ();

			foreach (var item in items) {
				var path = item.Path;
				if (!File.Exists (path))
					report.NotFound.Add (path);
				else
					report.Founded.Add (path);
			}

			return report;
		}

		public IEnumerable<DictionaryItem> Read ()
		{
			ColumnIndexes columnInfo = GetColumnIndexesInfo ();
			var items = new List<DictionaryItem> ();

			int rowIndex = 0;
			while (true) {
				var row = sheet.GetRow (++rowIndex);
				if (row == null)
					break;

				var item = new DictionaryItem {
					Path = FetchPath (row.GetCell (columnInfo.Path)),
					ImgName = GetStringOrNull(row.GetCell (columnInfo.Img)),
					Description = GetStringOrNull(row.GetCell (columnInfo.Description))
				};
				items.Add (item);
			}

			return items;
		}

		ColumnIndexes GetColumnIndexesInfo ()
		{
			int column = -1;
			IRow headerRow = sheet.GetRow (0);
			var info = new ColumnIndexes ();

			var cells = headerRow.Cells;
			for (int i = 0; i < cells.Count; i++) {
				var c = cells [i];

				switch (c.StringCellValue) {
				case "Path":
					info.Path = i;
					break;

				case "img":
					info.Img = i;
					break;

				case "H1":
					info.Description = i;
					break;
				}
			}

			return info;
		}

		string FetchPath (ICell cell)
		{
			if (cell == null)
				return null;

			string path = cell.StringCellValue;
			if (!path.StartsWith ("skf"))
				return path;

			path = path.Replace ("\\", "/");
			path = Path.Combine (storagePath, path);

			return path;
		}

		string GetStringOrNull (ICell cell)
		{
			if (cell == null)
				return null;

			return cell.StringCellValue;
		}
	}
}

