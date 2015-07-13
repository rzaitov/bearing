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
            string outputDir = "Output";
            IWorkbook wb = WorkbookFactory.Create(tablePath);
            ISheet sheet = wb.GetSheetAt(0);

            string finishTemplate = File.ReadAllText(finishPageTemplatePath);
            string tableTemplate = File.ReadAllText(tableTemplatePath);
            var pathResolver = new FinishPageNameResolver(outputDir);

            Directory.CreateDirectory(outputDir);

            XlsxFinishPageGenerator fg = new XlsxFinishPageGenerator(sheet);
            fg.Generate(finishTemplate, pathResolver);

            XlsxTableGenerator tg = new XlsxTableGenerator(sheet);
            tg.Generate(tableTemplate, pathResolver, Path.Combine(outputDir, "aaa.html"));
        }
    }
}
