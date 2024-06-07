using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class AvgRet : RollEstIndBase
    {
        public AvgRet(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (getMonthInt(wrapper.getCurrent().date) != currentMonth)
            {
                currentMonth = getMonthInt(wrapper.getCurrent().date);
                //Print out the values
                
                double temp = ((ReturnIndicator)wrapper.getObserver("Return")).getValues().Average();
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
