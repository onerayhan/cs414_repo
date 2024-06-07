using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    class YearlyStd : YearEstIndBase
    {
        public YearlyStd(MetricWrapper wrapper) : base(wrapper)
        {
        }

        public override void onBarUpdate()
        {
            base.onBarUpdate();
            if (getYearInt(wrapper.getCurrent().date) != currentYear)
            {
                currentYear = getYearInt(wrapper.getCurrent().date);
                AverageResult temp = new AverageResult();
                temp.date = wrapper.getCurrent().date;
                temp.sharpeAverage = getStdDevt(((Sharpe)wrapper.getObserver("Sharpe")).getRollingValues());
                temp.sortinoAverage = getStdDevt(((Sortino)wrapper.getObserver("Sortino")).getRollingValues());
                temp.returnToVARAverage = getStdDevt(((ReturnToVAR)wrapper.getObserver("Return To Value At Risk")).getRollingValues());
                temp.calmarAverage = getStdDevt(((Calmar)wrapper.getObserver("Calmar")).getRollingValues());
                values.Add(temp);
            }
        }

        public double getStdDevt(List<double> list)
        {
            double temp = list.Average();
            temp = Math.Sqrt(list.Average(v => Math.Pow(v - temp, 2)));
            return temp;

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
