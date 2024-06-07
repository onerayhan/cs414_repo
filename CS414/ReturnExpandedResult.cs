using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class ReturnExpandedResult
    {
        [Index(0)]
        public string date { get; set; }
        [Index(1)]
        public double carsIndex { get; set; }
        [Index(2)]
        public double chemicalsIndex { get; set; }
        [Index(3)]
        public double clothingIndex { get; set; }
        [Index(4)]
        public double constructionIndex { get; set; }
        [Index(5)]
        public double durablesIndex { get; set; }
        [Index(6)]
        public double financeIndex { get; set; }
        [Index(7)]
        public double foodIndex { get; set; }
        [Index(8)]
        public double machineryIndex { get; set; }
        [Index(9)]
        public double miningIndex { get; set; }
        [Index(10)]
        public double oilIndex { get; set; }
        [Index(11)]
        public double retailIndex { get; set; }
        [Index(12)]
        public double steelIndex { get; set; }
        [Index(13)]
        public double transportationIndex { get; set; }
        [Index(14)]
        public double utilitiesIndex { get; set; }

        public void setDate(string value)
        {
            date = value;
        }
        public void set(int index, double value)
        {
            switch (index)
            {
                case 1:
                    carsIndex = value;
                    break;
                case 2:
                    chemicalsIndex = value;
                    break;
                case 3:
                    clothingIndex = value;
                    break;
                case 4:
                    constructionIndex = value;
                    break;
                case 5:
                    durablesIndex = value;
                    break;
                case 6:
                    financeIndex = value;
                    break;
                case 7:
                    foodIndex = value;
                    break;
                case 8:
                    machineryIndex = value;
                    break;
                case 9:
                    miningIndex = value;
                    break;
                case 10:
                    oilIndex = value;
                    break;
                case 11:
                    retailIndex = value;
                    break;
                case 12:
                    steelIndex = value;
                    break;
                case 13:
                    transportationIndex = value;
                    break;
                case 14:
                    utilitiesIndex = value;
                    break;
                default:
                    break;
            }
        }
    }
}
