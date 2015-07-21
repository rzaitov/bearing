using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{
    
    class MissedPriceStorage
    {
        readonly HashSet<string> missedPriceItems;


        public IEnumerable<string> ItemsWithoutPrice {
            get {
                return missedPriceItems;
            }
        }

        public MissedPriceStorage()
        {
            missedPriceItems = new HashSet<string>();
        }

        public void Add(string article)
        {
            missedPriceItems.Add(article);
        }
    }
}
