﻿using NPOI.SS.UserModel;
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
        readonly string finishTemplate;
        readonly string tableTemplate;

        readonly GeneratorSettings settings;
        readonly FinishPageNameResolver pathResolver;


        public XlsxGeneratorEngine(GeneratorSettings settings)
        {
            this.settings = settings;

            finishTemplate = File.ReadAllText(settings.FinishPageTemplatePath);
            tableTemplate = File.ReadAllText(settings.TableTemplatePath);
            pathResolver = new FinishPageNameResolver(settings.OutputDir);
        }

        static int i = 1;
        public void Generate()
        {
            Directory.CreateDirectory(settings.OutputDir);

            var reader = new DictionaryReader(settings.DictionaryPath, settings.StoragePath);
            foreach (var item in reader.Read())
            {
                string path = item.Path;
                if (!File.Exists(path)) {
                    Console.WriteLine(string.Format("File not found: {0}", path));
                    continue;
                }

                IWorkbook wb = WorkbookFactory.Create(path);
                ISheet sheet = wb.GetSheetAt(0);

                HandleTable(sheet, Path.Combine(settings.OutputDir, string.Format("{0}.html", i++)));
            }
        }

        public void HandleTable(ISheet sheet, string tablePageOutputPath)
        {
            XlsxFinishPageGenerator fg = new XlsxFinishPageGenerator(sheet);
            fg.Generate(finishTemplate, pathResolver);

            XlsxTableGenerator tg = new XlsxTableGenerator(sheet);
            tg.Generate(tableTemplate, pathResolver, tablePageOutputPath);
        }
    }
}
