using System;
using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;

namespace SchemaGenerator
{
	public class TableReader
	{
		public Dictionary<string, List<string>> Headers { get; private set; }

		public TableReader ()
		{
			Headers = new Dictionary<string, List<string>> ();
		}

		public void Read (string path)
		{
			if (!File.Exists (path))
				throw new FileNotFoundException ();

			IWorkbook wb = WorkbookFactory.Create (path);
			ISheet sheet = wb.GetSheetAt (0);

			int column = 0;
			while (true) {
				ICell cell = sheet.GetRow (0).GetCell (column++);

				if (cell == null)
					break;

				List<string> files;
				var header = cell.StringCellValue;
				if (Headers.TryGetValue (header, out files))
					files.Add (path);
				else
					Headers [header] = new List<string> { path };
			}
		}
	}
}

