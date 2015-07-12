using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator.Helpers
{
    class HeaderReader
    {
        public List<string> FetchHeaders(int atRow, ISheet sheet)
        {
            List<string> headers = new List<string>();
			int column = 0;
			while (true) {
				ICell cell = sheet.GetRow (atRow).GetCell (column++);

				if (cell == null)
					break;

                headers.Add(cell.StringCellValue);
			}

            return headers;
        }       
    }
}
