using NPOI.SS.UserModel;
using PageGenerator.Helpers;
using RazorEngine;
using RazorEngine.Templating;
using RazorEngine.Compilation.CSharp;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{
    class XlsxFinishPageGenerator
    {
        readonly ISheet sheet;

        public XlsxFinishPageGenerator(ISheet sheet)
		{
            this.sheet = sheet;
		}

        public void Generate(string template, FinishPageNameResolver resolver)
        {
            var hReader = new HeaderReader();
            List<string> headers = hReader.FetchHeaders(0, sheet);

            var model = new FinishPage();
            model.Headers.AddRange(headers);

            if(!Engine.Razor.IsTemplateCached("finishPageKey", typeof(FinishPage)))
                Engine.Razor.Compile(template, "finishPageKey", typeof(FinishPage));

            int rowIndex = 0;
            while (true)
            {
                var row = sheet.GetRow(++rowIndex);
                if (row == null)
                    break;

                bool isRowEmpty = true;
                bool hasEmptyCell = false;
                model.Values.Clear();
                for (int i = 0; i < headers.Count; i++)
                {
                    var cell = row.GetCell(i);
                    string cellValue = cell.ToString();
                    isRowEmpty &= string.IsNullOrWhiteSpace(cellValue);
                    hasEmptyCell |= string.IsNullOrWhiteSpace(cellValue);
                    model.Values.Add(cellValue);
                }

                if (isRowEmpty)
                    continue;
                if (hasEmptyCell)
                    throw new InvalidOperationException();

                string result = Engine.Razor.Run("finishPageKey", typeof(FinishPage), model);
                string fileName = resolver.GetFilePath(model.Values[0]);
                File.WriteAllText(fileName, result, System.Text.Encoding.Unicode);
            }
        }
    }
}
