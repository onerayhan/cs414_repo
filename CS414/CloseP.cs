using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class CloseP
    {
        [Index(0)]
        public string date { get; set; }
        [Index(1)]
        public double price { get; set; }
    }
}
