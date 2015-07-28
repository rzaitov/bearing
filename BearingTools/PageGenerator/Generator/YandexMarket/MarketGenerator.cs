using Core;
using NPOI.SS.UserModel;
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

        public MarketGenerator(string outputPath)
        {
            this.outputPath = outputPath;
            offerIndex = 1;
        }

        public void Appdend(ISheet sheet, Dictionary<string, double> priceList)
        {
            using (var sw = new StreamWriter(outputPath, true))
            {
                sw.WriteLine("These items are without price:");
                foreach (var article in ReadArticles(sheet))
                    AppendOffer(sw, offerIndex++, article, priceList);
            }
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

        void AppendOffer(StreamWriter sw, int index, string article, Dictionary<string, double> priceList)
        {
            var builder = new GeneratorBuilder(article);
            VariantsGenerator generator = builder.Build();

            double price;
            string header = priceList.TryGetValue(article, out price) ? string.Format("{0} {1} руб.", article, price) : article;
            string text = string.Format("Подшипники {0}. Наличие в Спб. Низкие цены. Звоните!", header);

            foreach (var item in generator.GetVariants())
            {
                sw.Write(index);
                sw.Write("\t");
                sw.Write(item);
                sw.Write("\t");
                sw.Write(header);
                sw.Write("\t");
                sw.Write(text);
                sw.WriteLine();
            }       
        }
    }
}
