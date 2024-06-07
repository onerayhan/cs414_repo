using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class SemiDevt : RollEstIndBase
    {
        public SemiDevt(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
            {
                currentMonth = getMonthInt(wrapper.getCurrent().date); 
                double temp = ((NegReturnsSq)wrapper.getObserver("Negative Returns Squared")).getValues().Sum();
                temp = Math.Sqrt(temp);
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
