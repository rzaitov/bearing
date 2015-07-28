using System;
using CommandLine;

namespace PageGenerator
{
	class MainClass
	{
        public static void Main (string[] args)
		{
			Parser.Default.ParseArguments<Options> (args).WithParsed (opts => {
				GeneratorSettings settings = new GeneratorSettings {
					DictionaryPath = opts.Dictionary,
					OutputDir = opts.OutputDir,
					StoragePath = opts.Storage,
					FinishPageTemplatePath = opts.FinishPageTemplate,
					TableTemplatePath = opts.TablePageTemplate,
					GeneratePages = opts.Pages,
					GenerateYandexMarket = opts.YandexMarket,
                    PricelistPath = opts.PriceListPath,
					PricelessLogPath = "ItemsWithoutPrice.txt",
				};
				var engine = new XlsxGeneratorEngine (settings);
				engine.Generate ();
			}).WithNotParsed (_ => Console.WriteLine ("command line arguments are not pare"));
		}
	}
}
