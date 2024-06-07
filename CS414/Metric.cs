using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class Metric : Observer
    {
        protected MetricWrapper wrapper;
        protected List<double> values = new List<double>();
        protected List<double> rollingValues = new List<double>();
        protected bool counter = false;
        protected double currentReturn;
        protected int currentMonth = -1;
        protected int currentYear = -1;
        public Metric(MetricWrapper wrapper)
        {
            this.wrapper = wrapper;
        }

        public virtual void onBarUpdate()
        {
            if (counter == false)
            {
                counter = true;
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                currentYear = getYearInt(wrapper.getCurrent().date);
                return;
            }
            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
                currentReturn = ((AvgRet)wrapper.getObserver("Average Return")).getFinalVal();
        }

        public virtual void onDataEnd()
        {
            counter = false;
            currentMonth = -1;
            currentYear = -1;
            values.Clear();
        }

        public virtual void  resetPeriod()
        {
            if (getYearInt(wrapper.getCurrent().date) != currentYear)
            {
                currentYear = getYearInt(wrapper.getCurrent().date);
                rollingValues.Clear();
                if(values.Count() != 0)
                    rollingValues.Add(values[values.Count() -1]);
            }

        }
        public List<double> getValues()
        {
            return values;
        }
        public List<double> getRollingValues()
        {
            return rollingValues;
        }

        public double getValueAt(int index)
        {
            if (index < 0)
                return values[values.Count() + index];
            else
                return values[index];
        }
        //date format should be in DD.MM.YYYY
        public int getMonthInt(string date)
        {
            return Int32.Parse(date.Substring(date.IndexOf(".") + 1, 2 ));
        }
        public int getYearInt(string date)
        {
            return Int32.Parse(date.Substring(date.Length - 4));
        }
    }
}
