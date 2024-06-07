using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS414
{
    public interface Observer
    {
        public void onBarUpdate();
        public void resetPeriod();
        public void onDataEnd();
        //date format should be in DD.MM.YYYY
        public int getDayInt(string date)
        {
            return Int32.Parse(date.Substring(0, date.IndexOf(".")));
        }

    }
}
