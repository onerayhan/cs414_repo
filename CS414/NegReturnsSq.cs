using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class NegReturnsSq : ReturnIndBase
    {
        public NegReturnsSq(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (current != null && currentMonth == getMonthInt(current.date))
            {
                
                double temp = ((ReturnIndicator) wrapper.getObserver("Return")).getValueAt(-1);
                if(temp < 0)
                    values.Add(temp * temp);
                else
                    values.Add(0);
                
            }        
        }
        public override void resetPeriod()
        {
            base.resetPeriod();
            double temp = ((ReturnIndicator)wrapper.getObserver("Return")).getValueAt(-1);
            if (temp < 0)
                values.Add(temp * temp);
            else
                values.Add(0);
            last = current;

        }

        public override void onDataEnd()
        {
            base.onDataEnd();
        }
    }
}
