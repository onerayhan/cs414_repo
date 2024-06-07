using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class RollEstIndBase : Observer
    {

        protected MetricWrapper wrapper;
        protected List<double> values = new List<double>();
        protected bool counter = false;
        protected int currentMonth = -1;

        public RollEstIndBase(MetricWrapper wrapper)
        {
            this.wrapper = wrapper;
        }



        public virtual void onBarUpdate()
        {
            if (counter == false)
            {
                counter = true;
                currentMonth = getMonthInt(wrapper.getCurrent().date);
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
        }
        //date format should be in DD.MM.YYYY
        public int getMonthInt(string date)
        {
            return Int32.Parse(date.Substring(date.IndexOf(".") + 1, 2 ));
        }
        public double getFinalVal()
        {
            return values[values.Count() - 1];
        }
        public double getValueAt(int index)
        {
            if (index < 0)
                return values[values.Count() + index];
            else
                return values[index];
        }
    }
}
