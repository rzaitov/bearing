using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{
    class XlsxGeneratorEngine
    {
        public void HandleTable(string tablePath, string tableTemplatePath, string finishPageTemplatePath)
        {
            IWorkbook wb = WorkbookFactory.Create(tablePath);
            ISheet sheet = wb.GetSheetAt(0);

            string finishTemplate = File.ReadAllText(finishPageTemplatePath);
            var pathResolver = new FinishPageNameResolver("Output");

            Directory.CreateDirectory("Output");

            XlsxFinishPageGenerator fg = new XlsxFinishPageGenerator(sheet);
            fg.Generate(finishTemplate, pathResolver);

            //var tg = new XlsxTableGenerator(tablePath);
            //string tableTemplate = File.ReadAllText(tableTemplatePath);

            //string page = tg.Generate(tableTemplate);
            //File.WriteAllText("out.html", page, Encoding.Unicode);
        }
    }
}
