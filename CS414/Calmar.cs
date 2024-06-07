using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class Calmar : Metric
    {
        public Calmar(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
            {
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                double temp = ((MaxDrawdown)wrapper.getObserver("Max Drawdown")).getFinalVal();
                temp = currentReturn / Math.Abs(temp);
                values.Add(temp);
                if (getYearInt(wrapper.getCurrent().date) == currentYear)
                {
                    rollingValues.Add(temp);
                }
            }
        }

        public override void onDataEnd()
        {
            Console.WriteLine("Calmar");
            base.onDataEnd();
        }

        public override void resetPeriod()
        {
            base.resetPeriod();
        }
    }
}
