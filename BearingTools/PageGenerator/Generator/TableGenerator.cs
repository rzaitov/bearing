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
        readonly string path;
        readonly ISheet sheet;

        public XlsxTableGenerator (string path)
		{
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException();


            if (!File.Exists(path))
                throw new FileNotFoundException();

            IWorkbook wb = WorkbookFactory.Create(path);
            sheet = wb.GetSheetAt(0);
		}

		public string Generate (string template)
		{
            var hReader = new HeaderReader();
            List<string> headers = hReader.FetchHeaders(0, sheet);

            var model = new TablePage();
            model.TableHeaders.AddRange(headers);

            int rowIndex = 0;
            while (true)
            {
                var row = sheet.GetRow(++rowIndex);
                if (row == null)
                    break;

                for (int i = 0; i < headers.Count; i++)
                {
                    var cell = row.GetCell(i);
                    model.Values.Add(cell.ToString());
                }

                //Path = FetchPath(row.GetCell(columnInfo.Path)),
                //ImgName = GetStringOrNull(row.GetCell(columnInfo.Img)),
                //Description = GetStringOrNull(row.GetCell(columnInfo.Description))
                //items.Add(item);

                break;
            }



			string result = Engine.Razor.RunCompile(template, "templateKey", typeof(TablePage), model);
			return result;
		}
    }
}

