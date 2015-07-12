using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator.Model
{
    class TablePage
    {
        public List<string> Headers { get; set; }
        public List<List<string>> Data { get; set; }
    }
}
