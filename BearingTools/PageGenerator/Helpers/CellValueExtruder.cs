using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator.Helpers
{
    class CellValueExtruder
    {
        public string GetValue(ICell cell)
        {
            if (cell.CellType == CellType.Numeric)
                return cell.NumericCellValue.ToString("0.###############");
            else
                return cell.ToString();
        }
    }
}
