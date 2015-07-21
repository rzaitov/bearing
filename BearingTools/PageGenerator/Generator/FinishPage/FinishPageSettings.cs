using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{
    class FinishPageSettings
    {
        public string Template { get; set; }

        public FinishPageNameResolver NameResolver { get; set; }

        public Dictionary<string, double> PriceList { get; set; }
    }
}
