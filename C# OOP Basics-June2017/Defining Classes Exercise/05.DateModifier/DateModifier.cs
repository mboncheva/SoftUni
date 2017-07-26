using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DateModifier
{
    public static int DifferentBetweenTwoDates(string date1,string date2)
    {
        var firstDate = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);

        return  Math.Abs((firstDate - secondDate).Days);
    }
}
