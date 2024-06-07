using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class PeriodedPrices : ReturnIndBase
    {
        public PeriodedPrices(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (current != null && getMonthInt(current.date) == currentMonth)
            {
                currentMonth = getMonthInt(current.date);
                double temp = current.price;
                values.Add(temp);
                last = current;
            }
        }
        public override void resetPeriod()
        {
            base.resetPeriod();
            double temp = current.price;
            values.Add(temp);
            last = current;
        }
        public override void onDataEnd()
        {
            base.onDataEnd();
        }

    }
}
