using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class ReturnIndicator : ReturnIndBase
    {

        public ReturnIndicator(MetricWrapper wrapper) : base(wrapper) { }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if(current!= null && currentMonth == getMonthInt(current.date))
            {
                double temp = (current.price / last.price) - 1;
                values.Add(temp);
                last = current;
            }
        }
        public override void resetPeriod()
        {
            base.resetPeriod();
            double temp = (current.price / last.price) - 1;
            values.Add(temp);
            last = current;
        }

        public override void onDataEnd()
        {
            base.onDataEnd();
            

        }
    }
}
