﻿using Core;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{

    class MarketGenerator
    {
        readonly string outputPath;
        int offerIndex;
        readonly IWorkbook workbook;
        readonly ISheet outputSheet;
        int rowIndex;

        public MarketGenerator(string outputPath)
        {
            this.outputPath = outputPath;
            offerIndex = 1;

            workbook = new XSSFWorkbook();
            outputSheet = workbook.CreateSheet();
        }

        public void Generate(ISheet sheet, Dictionary<string, double> priceList)
        {
            foreach (var article in ReadArticles(sheet))
                AppendOffer(offerIndex++, article, priceList);

            using (var fs = new FileStream(outputPath, FileMode.Create))
                workbook.Write(fs);
        }

        IEnumerable<string> ReadArticles(ISheet sheet)
        {
            int rowIndex = 0;
            while (true)
            {
                var row = sheet.GetRow(++rowIndex);
                if (row == null)
                    yield break;

                var cell = row.GetCell(0);
                string value = cell.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                    yield return value;
            }
        }

        void AppendOffer(int index, string article, Dictionary<string, double> priceList)
        {
            var builder = new GeneratorBuilder(article);
            VariantsGenerator generator = builder.Build();

            double price;
            string header = priceList.TryGetValue(article, out price) ? string.Format("{0} {1} руб.", article, price) : article;
            string text = string.Format("Подшипники {0}. Наличие в Спб. Низкие цены. Звоните!", header);

            foreach (var item in generator.GetVariants())
            {
                IRow row = outputSheet.CreateRow(rowIndex++);
                var cell = row.CreateCell(0);
                cell.SetCellValue(index.ToString());

                cell = row.CreateCell(1);
                cell.SetCellValue(item);

                cell = row.CreateCell(2);
                cell.SetCellValue(header);

                cell = row.CreateCell(3);
                cell.SetCellValue(text);
            }       
        }
    }
}
