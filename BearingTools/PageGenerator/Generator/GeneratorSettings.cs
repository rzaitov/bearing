using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{
    class GeneratorSettings
    {
        public string DictionaryPath { get; set; }

        public string PricelistPath { get; set; }

        public string StoragePath { get; set; }

        public string TableTemplatePath { get; set; }
        public string FinishPageTemplatePath { get; set; }

        public string OutputDir { get; set; }

        public string PricelessLogPath { get; set; }
    }
}
