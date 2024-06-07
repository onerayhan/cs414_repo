using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class StockExpandedResult
    {
        [Index(0)]
        public string date { get; set; }
        [Index(1)]
        public double Caterpillar { get; set; }
        [Index(2)]
        public double Cummins { get; set; }
        [Index(3)]
        public double Deere { get; set; }
        [Index(4)]
        public double Dover { get; set; }
        [Index(5)]
        public double Idex { get; set; }
        [Index(6)]
        public double IllinoisToolWorks { get; set; }
        [Index(7)]
        public double Nordson { get; set; }
        [Index(8)]
        public double Paccar { get; set; }
        [Index(9)]
        public double ParkerHannifin{ get; set; }
        [Index(10)]
        public double SnapOn { get; set; }
        [Index(11)]
        public double HormelFoods { get; set; }
        [Index(12)]
        public double Kellogs{ get; set; }
        [Index(13)]
        public double Pepsi { get; set; }
        [Index(14)]
        public double TysonFoods { get; set; }

        public void setDate(string value)
        {
            date = value;
        }
        public void set(int index , double value)
        {
            switch (index)
            {
                case 1:
                    Caterpillar = value;
                    break;
                case 2:
                    Cummins = value;
                    break;
                case 3:
                    Deere = value;
                    break;
                case 4:
                    Dover = value;
                    break;
                case 5:
                    Idex = value;
                    break;
                case 6:
                    IllinoisToolWorks = value;
                    break;
                case 7:
                    Nordson = value;
                    break;
                case 8:
                    Paccar = value;
                    break;
                case 9:
                    ParkerHannifin = value;
                    break;
                case 10:
                    SnapOn = value;
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
