using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class StdDevt : RollEstIndBase
    {
        public StdDevt(MetricWrapper wrapper) : base(wrapper)
        {
        }

        //calculates according to population standard deviation
        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
            {
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                double temp =((ReturnIndicator)wrapper.getObserver("Return")).getValues().Average();
                List<double> returns = ((ReturnIndicator)wrapper.getObserver("Return")).getValues();
                temp = Math.Sqrt(returns.Average(v => Math.Pow(v - temp, 2)));
                values.Add(temp);
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
