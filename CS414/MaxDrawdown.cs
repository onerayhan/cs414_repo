using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class MaxDrawdown : RollEstIndBase
    {
        public MaxDrawdown(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            
            //CloseP tempC = wrapper

            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
            {
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                double max = ((PeriodedPrices)wrapper.getObserver("Prices")).getValues().Max();
                double min = ((PeriodedPrices)wrapper.getObserver("Prices")).getValues().Min();
                values.Add((min - max) / max);

            }
        }
        public override void resetPeriod()
        {
            base.resetPeriod();
        }

        public override void onDataEnd()
        {
            base.onDataEnd();
        }
    }
}
