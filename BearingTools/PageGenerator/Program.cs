using System;

namespace PageGenerator
{
	class MainClass
	{
        const string path = "c:\\Users\\Rustam\\Downloads\\skf\\Подшипники\\Шариковые\\Шариковые Радиальные\\Шариковые Радиальные Однорядные\\Шариковые радиальные однорядные открытые.xlsx";
        const string tableTemplate = "c:\\Users\\Rustam\\Downloads\\table_template3.html";
        const string finishTemplate = "c:\\Users\\Rustam\\Downloads\\table_template3.html";
		
        public static void Main (string[] args)
		{
            XlsxGeneratorEngine engine = new XlsxGeneratorEngine();
            engine.HandleTable(path, tableTemplate, finishTemplate);

		}
	}
}
