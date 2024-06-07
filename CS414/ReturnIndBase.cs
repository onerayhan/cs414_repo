using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class ReturnIndBase : Observer
    {
        protected MetricWrapper wrapper;
        protected List<double> values = new List<double>();
        protected bool counter = false;
        protected int currentMonth = -1;
        protected CloseP current;
        protected CloseP last;

        public ReturnIndBase(MetricWrapper wrapper)
        {
            this.wrapper = wrapper;
             
        }

        public virtual void resetPeriod()
        {

            values.Clear();
            current = wrapper.getCurrent();
            currentMonth = getMonthInt(wrapper.getCurrent().date);
        }

        public virtual void onBarUpdate()
        {
            if (counter == false)
            {
                counter = true;
                last = wrapper.getCurrent();
                current = wrapper.getCurrent();
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                return;
            }
            current = wrapper.getCurrent();

        }

        public virtual void onDataEnd()
        {
            counter = false;
            values.Clear();
            
        }

        public double getValueAt(int index) 
        {
            if (index < 0)
                return values[values.Count() + index];
            else
                return values[index];
        }
        public List<double> getValues()
        {
            return values;
        }
        //date format should be in DD.MM.YYYY
        public int getMonthInt(string date)
        {
            return Int32.Parse(date.Substring(date.IndexOf(".") + 1, 2));
        }
    }
}
