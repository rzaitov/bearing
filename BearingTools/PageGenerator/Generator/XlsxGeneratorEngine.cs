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
        public void HandleTable(string tablePath, string tableTemplatePath)
        {
            if (!File.Exists(tableTemplatePath))
                throw new FileNotFoundException();

            IWorkbook wb = WorkbookFactory.Create(tablePath);
            ISheet sheet = wb.GetSheetAt(0);

            var tg = new XlsxTableGenerator(tablePath);
            string tableTemplate = File.ReadAllText(tableTemplatePath);

            string page = tg.Generate(tableTemplate);
            File.WriteAllText("out.html", page, Encoding.Unicode);
        }
    }
}
