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
        readonly string finishTemplate;
        readonly string tableTemplate;

        readonly GeneratorSettings settings;
        readonly FinishPageNameResolver pathResolver;

        readonly Dictionary<string, double> pricelist;
        readonly MissedPriceStorage missedPriceStorage;

        MarketGenerator marketGenerator;

        public XlsxGeneratorEngine(GeneratorSettings settings)
        {
            this.settings = settings;

            finishTemplate = File.ReadAllText(settings.FinishPageTemplatePath);
            tableTemplate = File.ReadAllText(settings.TableTemplatePath);
            pathResolver = new FinishPageNameResolver(settings.OutputDir);


            var priceListReader = new PriceListReader();
            pricelist = priceListReader.ReadPriceList(LoadPricelist(settings.PricelistPath));

            missedPriceStorage = new MissedPriceStorage();
        }

        ISheet LoadPricelist(string path)
        {
            IWorkbook wb = WorkbookFactory.Create(path);
            ISheet sheet = wb.GetSheetAt(0);
            return sheet;
        }

        static int i = 1;
        public void Generate()
        {
            Directory.CreateDirectory(settings.OutputDir);

            var marketOutputPath = Path.Combine(settings.OutputDir, settings.MarketOutput);
            File.Delete(marketOutputPath);
            marketGenerator = new MarketGenerator(marketOutputPath);

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

            ReportAboutPricelessItems();
        }

        public void HandleTable(ISheet sheet, string tablePageOutputPath)
        {
            XlsxFinishPageGenerator fg = new XlsxFinishPageGenerator(sheet);
            var fPageSettings = new FinishPageSettings {
                Template = finishTemplate,
                PriceList = pricelist,
                NameResolver = pathResolver,
                MissedPriceStorage = missedPriceStorage
            };
            fg.Generate(fPageSettings);

            XlsxTableGenerator tg = new XlsxTableGenerator(sheet);
            tg.Generate(tableTemplate, pathResolver, tablePageOutputPath);

            marketGenerator.Appdend(sheet, pricelist);
        }

        void ReportAboutPricelessItems()
        {
            if (!missedPriceStorage.ItemsWithoutPrice.Any())
                return;

            using (var sw = new StreamWriter(settings.PricelessLogPath))
            {
                sw.WriteLine("These items are without price:");
                foreach (var pricelessItem in missedPriceStorage.ItemsWithoutPrice)
                    sw.WriteLine(pricelessItem);
            }
        }
    }
}
