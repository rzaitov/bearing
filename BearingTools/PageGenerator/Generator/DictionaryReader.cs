using System;
using System.IO;
using NPOI.SS.UserModel;
using System.Collections.Generic;

namespace PageGenerator
{
	public class DictionaryReader
	{
		class ColumnIndexes
		{
			public int Path { get; set; }
			public int Description { get; set; }
			public int Img { get; set; }
		}

		readonly string path;
		readonly ISheet sheet;
		readonly string storagePath;

		public DictionaryReader (string path, string storagePath)
		{
			if (!File.Exists (path))
				throw new FileNotFoundException ();

			if (!Directory.Exists (storagePath))
				throw new DirectoryNotFoundException ();

			this.path = path;

			IWorkbook wb = WorkbookFactory.Create (path);
			sheet = wb.GetSheet("URL");

			this.storagePath = storagePath;
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
			path = path.Replace ("\\", Path.DirectorySeparatorChar.ToString ());
			path = Path.Combine (storagePath, path);

			return path;
		}

		string GetStringOrNull (ICell cell)
		{
			if (cell == null)
				return null;

			if(cell.CellType == CellType.String)
				return cell.StringCellValue;
			else
				Console.WriteLine ("Got numeric value when string expected. row={0}, column={1}, value={2}, path={3}", cell.RowIndex, cell.ColumnIndex, cell.NumericCellValue, path);

			return null;
		}
	}
}

