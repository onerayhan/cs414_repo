using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public class IndicatorFactory
    {
        public IndicatorFactory()
        {
        }

        public Observer getObserver(string indicatorName, MetricWrapper wrapper)
        {
            switch (indicatorName)
            {
                case "Prices":
                    return new PeriodedPrices(wrapper);
                case "Return":
                    return new ReturnIndicator(wrapper);
                case "Average Return":
                    return new AvgRet(wrapper);
                case "Standard Deviation":
                    return new StdDevt(wrapper);
                case "Negative Returns Squared":
                    return new NegReturnsSq(wrapper);
                case "Semi Deviation":
                    return new SemiDevt(wrapper);
                case "Value At Risk":
                    return new VaRMin(wrapper);
                case "Max":
                    return new MaxInPeriod(wrapper);
                case "Max Drawdown":
                    return new MaxDrawdown(wrapper);
                case "Date":
                    return new Date(wrapper);
                case "Sharpe":
                    return new Sharpe(wrapper);
                case "Sortino":
                    return new Sortino(wrapper);
                case "Return To Value At Risk":
                    return new ReturnToVAR(wrapper);
                case "Calmar":
                    return new Calmar(wrapper);
                case "Yearly Average":
                    return new YearlyAvg(wrapper);
                case "Yearly Standard Deviation":
                    return new YearlyStd(wrapper);
                default:
                    throw new ArgumentException("You've given an incorrect Indicator name");

            }

        }
    }
}
