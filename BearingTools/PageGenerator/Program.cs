using System;
using CommandLine;

namespace PageGenerator
{
	class MainClass
	{
        const string path = "c:\\Users\\Rustam\\Downloads\\skf\\Подшипники\\Шариковые\\Шариковые Радиальные\\Шариковые Радиальные Однорядные\\Шариковые радиальные однорядные открытые.xlsx";
        const string tableTemplate = "c:\\Users\\Rustam\\Downloads\\table_template2.html";
        const string finishTemplate = "c:\\Users\\Rustam\\Downloads\\table_template3.html";
		
        public static void Main (string[] args)
		{
			var options = new Options ();
			Parser.Default.ParseArguments<Options> (args).WithParsed (opts => {
				GeneratorSettings settings = new GeneratorSettings {
					DictionaryPath = opts.Dictionary,
					OutputDir = opts.OutputDir,
					StoragePath = opts.Storage,
					FinishPageTemplatePath = opts.FinishPageTemplate,
					TableTemplatePath = opts.TablePageTemplate,
					GeneratePages = opts.Pages,
					GenerateYandexMarket = opts.YandexMarket,
					PricelessLogPath = "ItemsWithoutPrice.txt",
				};
				var engine = new XlsxGeneratorEngine (settings);
				engine.Generate ();
			}).WithNotParsed (() => Console.WriteLine ("command line arguments are not pare"));
		}
	}
}
