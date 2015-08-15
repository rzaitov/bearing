using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.SS.UserModel;

namespace PageGenerator
{
    class PriceListReader
    {
        public Dictionary<string, double> ReadPriceList(ISheet sheet)
        {
            var priceList = new Dictionary<string, double>();

            AssertHeaders(sheet);
            int rowIndex = 1;

            while (true)
            {
                var row = sheet.GetRow(rowIndex++);
                if (row == null)
                    break;

                var articleCell = row.GetCell(0);
                var priceCell = row.GetCell(1);

                string article = articleCell.StringCellValue.Trim();
                double price = priceCell.NumericCellValue;

                if (string.IsNullOrWhiteSpace(article))
                    throw new InvalidProgramException(string.Format("found empty article at {0} row", row));

                if (priceList.ContainsKey(article))
                    throw new InvalidProgramException(string.Format("found duplicate price for {0}", article));

                priceList[article] = price;
            }

            return priceList;
        }

        void AssertHeaders(ISheet sheet)
        {
            var row = sheet.GetRow(0);
            if (row == null)
                throw new InvalidOperationException("Price list must contains headers");

            var nomenclature = row.GetCell(0);
            if (nomenclature.StringCellValue.Trim().ToLower() != "article")
                throw new InvalidOperationException("First column's header inside pricelist must be named \"Article\"");

            var price = row.GetCell(1);
            if (price.StringCellValue.Trim().ToLower() != "price")
                throw new InvalidOperationException("Second column's header must be named \"Price\"");
        }
    }
}
