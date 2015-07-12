using System;

namespace PageGenerator
{
	class MainClass
	{
        const string path = "c:\\Users\\Rustam\\Downloads\\skf\\Подшипники\\Шариковые\\Шариковые Радиальные\\Шариковые Радиальные Однорядные\\Шариковые радиальные однорядные открытые.xlsx";
        const string templatePath = "c:\\Users\\Rustam\\Downloads\\table_template3.html";
		public static void Main (string[] args)
		{
            XlsxGeneratorEngine engine = new XlsxGeneratorEngine();
            engine.HandleTable(path, templatePath);

		}
	}
}
