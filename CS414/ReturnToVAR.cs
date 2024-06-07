using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class ReturnToVAR : Metric
    {
        public ReturnToVAR(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
            {
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                double temp = ((VaRMin)wrapper.getObserver("Value At Risk")).getFinalVal();
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
            Console.WriteLine("Return To Value At Risk");
            base.onDataEnd();
        }

        public override void resetPeriod()
        {
            base.resetPeriod();
        }
    }
}
