using System;

using RazorEngine;
using RazorEngine.Templating;
using RazorEngine.Compilation.CSharp;
using System.IO;
using NPOI.SS.UserModel;
using PageGenerator.Helpers;
using System.Collections.Generic;

namespace PageGenerator
{
    public class XlsxTableGenerator : ITableGenerator
	{
        readonly ISheet sheet;

        public XlsxTableGenerator(ISheet sheet)
		{
            this.sheet = sheet;
		}

		public void Generate (string template, FinishPageNameResolver resolver, string outputPath)
		{
            var hReader = new HeaderReader();
            List<string> headers = hReader.FetchHeaders(0, sheet);

            var model = new TablePage();
            model.Headers.AddRange(headers);

            if (!Engine.Razor.IsTemplateCached("tablePageKey", typeof(TablePage)))
                Engine.Razor.Compile(template, "tablePageKey", typeof(TablePage));

            int rowIndex = 0;
            while (true)
            {
                var row = sheet.GetRow(++rowIndex);
                if (row == null)
                    break;

                var rData = new RowData();
                for (int i = 0; i < headers.Count; i++)
                {
                    var cell = row.GetCell(i);
                    rData.Values.Add(cell.ToString());
                }
                rData.FinishPageUrl = resolver.GetFileName(rData.Values[0]);
                model.Rows.Add(rData);
            }

            string result = Engine.Razor.Run("tablePageKey", typeof(TablePage), model);
            File.WriteAllText(outputPath, result, System.Text.Encoding.Unicode);
		}
    }
}

