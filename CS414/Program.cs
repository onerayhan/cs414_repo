using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CS414
{
    class Program
    {
        // link for class diagram -> https://online.visual-paradigm.com/app/diagrams/#diagram:proj=0&type=ClassDiagram&width=11&height=8.5&unit=inch
        static List<CloseP> prices = new List<CloseP>();
        static MetricWrapper singleStockWrapper = new MetricWrapper();
        static List<string> indicatorsList = new List<string>()
            {
                "Prices",
                "Return",
                "Average Return",
                "Standard Deviation",
                "Negative Returns Squared",
                "Semi Deviation",
                "Value At Risk",
                //"Max",
                "Max Drawdown",
                "Date",
                "Sharpe",
                "Sortino",
                "Return To Value At Risk",
                "Calmar",
                "Yearly Average",
                "Yearly Standard Deviation"

            };
        static void Main(string[] args)
        {

            readWithinFolder();
            Console.WriteLine("wweeqsd");

        }


        public static void readWithinFolder()
        {
            foreach (string file in Directory.EnumerateFiles("MachineryStocks", "*.csv"))
            {
                prices = readCSVFromFile(file);
                singleStockWrapper.setPrices(prices);
                singleStockWrapper.initialize(indicatorsList, prices);
                singleStockWrapper.iterate();
                //singleStockWrapper.writeAverages(file);
                singleStockWrapper.writeCalmar();
                singleStockWrapper.onDataEnd();

            }
            singleStockWrapper.writeExpanded();


        }
        //delimiter should be set to ";" for excel(xlsx) converted csv files 
        public static List<CloseP> readCSVFromFile(string filename)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ";",
            };
            using (var reader = new StreamReader(filename, Encoding.UTF8))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<CloseP>().ToList();
                //records.Skip(3);
                return records;
            }

        }
        public static void writeToCSV() { }



    }
}


