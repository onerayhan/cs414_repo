using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class MetricWrapper : Observable
    {
        static int fileNum = 21;
        static int indexNum = 1;
        //for updates to observers
        List<Observer> observers = new List<Observer>();
        //for observers to access other observers has to be public
        public Dictionary<string, Observer> observersDict = new Dictionary<string, Observer>();
        int prevMonth = -1;
        List<CloseP> prices; 
        CloseP current;
        List<StockExpandedResult> resultExpanded = new List<StockExpandedResult>();

        public MetricWrapper()
        {

        }
        //deprecated
        public MetricWrapper(List<CloseP> prices)
        {
            this.prices = prices;
        }

        public void initialize(List<string> indicatorsList, List<CloseP> prices)
        {
            this.clearObservers();
            IndicatorFactory factory = new IndicatorFactory();
            foreach(string indicator in indicatorsList)
            {
                Observer observer = factory.getObserver(indicator, this);
                this.attach(indicator, observer);
            }

        }
        public void iterate()
        {
            //possible iterator class Update????
            for (int i = 0; i < prices.Count(); i++)
            {
                this.current = prices[i];
                //Console.WriteLine(getMonthInt(this.current.date));
                int month = getMonthInt(this.current.date);
                notifyAllObservers();
                if(month != prevMonth)
                {
                    prevMonth = month;
                    notifyReset();
                }
            }
        }
        //list contains the metrics to be written
        // precondition: iterate has to be called first
        public void writeData(string filename)
        {
            List<MetricResult> resultsToWrite = new List<MetricResult>();
            for (int i = 0; i < ((Sharpe)getObserver("Sharpe")).getValues().Count(); i++)
            {
                MetricResult temp = new MetricResult();
                temp.date = ((Date)getObserver("Date")).getDateAt(i);
                temp.sharpeMetric = ((Sharpe)getObserver("Sharpe")).getValueAt(i);
                temp.sortinoMetric = ((Sortino)getObserver("Sortino")).getValueAt(i);
                temp.returnToVARMetric = ((ReturnToVAR)getObserver("Return To Value At Risk")).getValueAt(i);
                temp.calmarMetric = ((Calmar)getObserver("Calmar")).getValueAt(i);
                resultsToWrite.Add(temp);
            }
            string fileToBeWritten = filename.Substring(0, filename.Length - 5) + fileNum++ + ".csv";
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            using (var writer = new StreamWriter(fileToBeWritten))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(resultsToWrite);
            }

        }
        public void writeAverages(string filename)
        {
            string fileToBeWritten = filename.Substring(0, filename.Length - 5) + fileNum++ + ".csv";
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            using (var writer = new StreamWriter(fileToBeWritten))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(((YearlyAvg) getObserver("Yearly Average")).getValues());
            }

        }
        public void writeSharpe()
        {
            
            List<AverageResult> temps = ((YearlyAvg)getObserver("Yearly Average")).getValues();
            Console.WriteLine(temps.Count());
            if(indexNum == 1)
            {
                for (int i = 0; i < temps.Count(); i++)
                {
                    StockExpandedResult temp = new StockExpandedResult();
                    temp.setDate(temps[i].date);
                    temp.set(indexNum, temps[i].sharpeAverage);
                    resultExpanded.Add(temp);
                }
            }
            else
            {
                for (int i = 0; i < temps.Count(); i++)
                {
                    resultExpanded[i].set(indexNum, temps[i].sharpeAverage);

                }
            }
            indexNum++;
            

        }
        public void writeSortino()
        {

            List<AverageResult> temps = ((YearlyAvg)getObserver("Yearly Average")).getValues();
            Console.WriteLine(temps.Count());
            if (indexNum == 1)
            {
                for (int i = 0; i < temps.Count(); i++)
                {
                    StockExpandedResult temp = new StockExpandedResult();
                    temp.setDate(temps[i].date);
                    temp.set(indexNum, temps[i].sortinoAverage);
                    resultExpanded.Add(temp);
                }
            }
            else
            {
                for (int i = 0; i < temps.Count(); i++)
                {
                    resultExpanded[i].set(indexNum, temps[i].sortinoAverage);

                }
            }
            indexNum++;
        }
        public void writeReturnToVAR()
        {

            List<AverageResult> temps = ((YearlyAvg)getObserver("Yearly Average")).getValues();
            Console.WriteLine(temps.Count());
            if (indexNum == 1)
            {
                for (int i = 0; i < temps.Count(); i++)
                {
                    StockExpandedResult temp = new StockExpandedResult();
                    temp.setDate(temps[i].date);
                    temp.set(indexNum, temps[i].returnToVARAverage);
                    resultExpanded.Add(temp);
                }
            }
            else
            {
                for (int i = 0; i < temps.Count(); i++)
                {
                    resultExpanded[i].set(indexNum, temps[i].returnToVARAverage);

                }
            }
            indexNum++;
        }
        public void writeCalmar()
        {

            List<AverageResult> temps = ((YearlyAvg)getObserver("Yearly Average")).getValues();
            Console.WriteLine(temps.Count());
            if (indexNum == 1)
            {
                for (int i = 0; i < temps.Count(); i++)
                {
                    StockExpandedResult temp = new StockExpandedResult();
                    temp.setDate(temps[i].date);
                    temp.set(indexNum, temps[i].returnToVARAverage);
                    resultExpanded.Add(temp);
                }
            }
            else
            {
                for (int i = 0; i < temps.Count(); i++)
                {
                    resultExpanded[i].set(indexNum, temps[i].returnToVARAverage);

                }
            }
            indexNum++;
        }


        public void writeExpanded()
        {
            string fileToBeWritten = "Retur.csv";
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            using (var writer = new StreamWriter(fileToBeWritten))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(resultExpanded);
            }

        }

        public void onDataEnd()
        {
            notifyAllObserversDataEnd();
            current = null;
            prevMonth = -1;
        }
        public void attach(string name, Observer observer)
        {
            observers.Add(observer);
            observersDict.Add(name, observer);
        }
        public void clearObservers()
        {
            observers.Clear();
            observersDict.Clear();
        }

        public void notifyAllObservers()
        {
            foreach (Observer observer in observers) {
                observer.onBarUpdate();
            }
        }

        public void notifyReset()
        {
            foreach(Observer observer in observers)
            {
                observer.resetPeriod();
            }
        }

        public void notifyAllObserversDataEnd()
        {
            foreach (Observer observer in observers)
            {
                observer.onDataEnd();
            }
        }
        public CloseP getCurrent()
        {
            return this.current;
        }

        public void setPrices(List<CloseP> prices)
        {
            this.prices = prices;
        }
        //date format should be in DD.MM.YYYY
        public int getMonthInt(string date)
        {
            return Int32.Parse(date.Substring(date.IndexOf(".") + 1, 2 ));
        }
        public Observer getObserver(string indName)
        {
            return observersDict[indName];
        }
        // 0 returns first

    }
}
