using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class ChemicalsExpandedResult
    {
        [Index(0)]
        public string date { get; set; }
        [Index(1)]
        public double AirPRDS { get; set; }
        [Index(2)]
        public double Albemarle { get; set; }
        [Index(3)]
        public double Eastman { get; set; }
        [Index(4)]
        public double Ecolab { get; set; }
        [Index(5)]
        public double FMC { get; set; }
        [Index(6)]
        public double IntlFlavors { get; set; }
        [Index(7)]
        public double Linde { get; set; }
        [Index(8)]
        public double Mosaic { get; set; }
        [Index(9)]
        public double PPGIndustries { get; set; }
        [Index(10)]
        public double SherwinWilliams { get; set; }
        [Index(11)]
        public double HormelFoods { get; set; }
        [Index(12)]
        public double Kellogs { get; set; }
        [Index(13)]
        public double Pepsi { get; set; }
        [Index(14)]
        public double TysonFoods { get; set; }

        public void setDate(string value)
        {
            date = value;
        }
        public void set(int index, double value)
        {
            switch (index)
            {
                case 1:
                    AirPRDS = value;
                    break;
                case 2:
                    Albemarle = value;
                    break;
                case 3:
                    Eastman = value;
                    break;
                case 4:
                    Ecolab = value;
                    break;
                case 5:
                    FMC = value;
                    break;
                case 6:
                    IntlFlavors = value;
                    break;
                case 7:
                    Linde = value;
                    break;
                case 8:
                    Mosaic = value;
                    break;
                case 9:
                    PPGIndustries = value;
                    break;
                case 10:
                    SherwinWilliams = value;
                    break;
                case 11:
                    HormelFoods = value;
                    break;
                case 12:
                    Kellogs = value;
                    break;
                case 13:
                    Pepsi = value;
                    break;
                case 14:
                    TysonFoods = value;
                    break;
                default:
                    break;
            }
        }

    }
}
