using System;

namespace PageGenerator
{
	class MainClass
	{
        const string path = "c:\\Users\\Rustam\\Downloads\\skf\\Подшипники\\Шариковые\\Шариковые Радиальные\\Шариковые Радиальные Однорядные\\Шариковые радиальные однорядные открытые.xlsx";
        const string tableTemplate = "c:\\Users\\Rustam\\Downloads\\table_template2.html";
        const string finishTemplate = "c:\\Users\\Rustam\\Downloads\\table_template3.html";
		
        public static void Main (string[] args)
		{
            GeneratorSettings settings = new GeneratorSettings
            {
                DictionaryPath = "c:\\Users\\Rustam\\Downloads\\Dictionary.xlsx",
                OutputDir = "Output",
                StoragePath = "c:\\Users\\Rustam\\Downloads\\",
                FinishPageTemplatePath = finishTemplate,
                TableTemplatePath = tableTemplate
            };
            var engine = new XlsxGeneratorEngine(settings);
            engine.Generate();
		}
	}
}
