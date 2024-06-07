using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class YearlyAvg : YearEstIndBase
    {
        public YearlyAvg(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if(getYearInt(wrapper.getCurrent().date) != currentYear)
            {
                currentYear = getYearInt(wrapper.getCurrent().date);
                AverageResult temp = new AverageResult();
                temp.date = wrapper.getCurrent().date;
                temp.sharpeAverage = ((Sharpe)wrapper.getObserver("Sharpe")).getRollingValues().Average();
                temp.sortinoAverage = ((Sortino)wrapper.getObserver("Sortino")).getRollingValues().Average();
                temp.returnToVARAverage = ((ReturnToVAR)wrapper.getObserver("Return To Value At Risk")).getRollingValues().Average();
                temp.calmarAverage = ((Calmar)wrapper.getObserver("Calmar")).getRollingValues().Average();
                values.Add(temp);
            }
        }

        public override void onDataEnd()
        {
            base.onDataEnd();

        }

        public override void resetPeriod()
        {
            base.resetPeriod();
        }
    }
}
