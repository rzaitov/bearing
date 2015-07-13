using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{
    public class RowData
    {
        public string FinishPageUrl { get; set; }
        public List<string> Values { get; set; }

        public RowData()
        {
            Values = new List<string>();
        }
    }

    public class TablePage
    {
        public List<string> Headers { get; set; }
        public List<RowData> Rows { get; set; }

        public TablePage()
        {
            Headers = new List<string>();
            Rows = new List<RowData>();
        }
    }
}
