using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class Sharpe : Metric
    {
        public Sharpe(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
            {
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                double temp = ((StdDevt)wrapper.getObserver("Standard Deviation")).getFinalVal();
                temp = currentReturn / temp;
                values.Add(temp);
                if (getYearInt(wrapper.getCurrent().date) == currentYear)
                {
                    rollingValues.Add(temp);
                }          
            }
        }

        public override void onDataEnd()
        {
            Console.WriteLine("Sharpe");
            base.onDataEnd();
        }

        public override void resetPeriod()
        {
            base.resetPeriod();
            
        }
    }
}
