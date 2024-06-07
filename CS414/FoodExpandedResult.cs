using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class FoodExpandedResult
    {    
        [Index(0)]
        public string date { get; set; }
        [Index(1)]
        public double AltriaGroup { get; set; }
        [Index(2)]
        public double ArcherDaniels { get; set; }
        [Index(3)]
        public double BrownForman { get; set; }
        [Index(4)]
        public double CampbellSoup { get; set; }
        [Index(5)]
        public double CocaCola { get; set; }
        [Index(6)]
        public double ConagraBrands { get; set; }
        [Index(7)]
        public double ConstellationBrands { get; set; }
        [Index(8)]
        public double GeneralMills { get; set; }
        [Index(9)]
        public double GeneralMotors { get; set; }
        [Index(10)]
        public double Hersheys { get; set; }
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
                    AltriaGroup = value;
                    break;
                case 2:
                    ArcherDaniels = value;
                    break;
                case 3:
                    BrownForman = value;
                    break;
                case 4:
                    CampbellSoup = value;
                    break;
                case 5:
                    CocaCola = value;
                    break;
                case 6:
                    ConagraBrands = value;
                    break;
                case 7:
                    ConstellationBrands = value;
                    break;
                case 8:
                    GeneralMills = value;
                    break;
                case 9:
                    GeneralMotors = value;
                    break;
                case 10:
                    Hersheys = value;
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
