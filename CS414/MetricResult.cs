using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class MetricResult
    {
        public string date { get; set; }
        public double sharpeMetric { get; set; }
        public double sortinoMetric { get; set; }
        public double returnToVARMetric { get; set; }
        public double calmarMetric { get; set; }
    }
}
