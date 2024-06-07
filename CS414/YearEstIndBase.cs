using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class YearEstIndBase : Observer
    {
        protected MetricWrapper wrapper;
        protected List<AverageResult> values = new List<AverageResult>();
        protected bool counter = false;
        protected int currentMonth = -1;
        protected int currentYear = -1;

        public YearEstIndBase(MetricWrapper wrapper)
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

        }
        public virtual void resetPeriod()
        {

        }

        public virtual void onDataEnd()
        {
            values.Clear();
            counter = false;
            currentMonth = -1;
            currentYear = -1;
        }
        //date format should be in DD.MM.YYYY
        public int getMonthInt(string date)
        {
            return Int32.Parse(date.Substring(date.IndexOf(".") + 1, 2));
        }
        public int getYearInt(string date)
        {
            return Int32.Parse(date.Substring((date.Length) - 4));
        }
        public AverageResult getFinalVal()
        {
            return values[values.Count() - 1];
        }
        public AverageResult getValueAt(int index)
        {
            if (index < 0)
                return values[values.Count() + index];
            else
                return values[index];
        }
        public List<AverageResult> getValues()
        {
            return values;
        }

    }
}
