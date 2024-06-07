using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class Date : Metric
    {
        List<string> dates = new List<string>();
        public Date(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
            {
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                string temp = wrapper.getCurrent().date;
                dates.Add(temp);
            }
        }

        public override void onDataEnd()
        {
            base.onDataEnd();
            dates.Clear();
        }
        public List<string> getDates()
        {
            return dates;
        }
        public string getDateAt(int index)
        {
            return dates[index];
        }

        public override void resetPeriod()
        {
            base.resetPeriod();
        }
    }
}
