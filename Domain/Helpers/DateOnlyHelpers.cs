using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class DateOnlyHelpers
    {
        public static int GetOverlappingDaysBetweenTwoDateRanges(DateOnly checkInDate,
            DateOnly checkOutDate,
            DateOnly priceListFromDate,
            DateOnly priceListToDate)
        {
            var maxStart = checkInDate > priceListFromDate ? checkInDate : priceListFromDate;
            var minEnd = checkOutDate < priceListToDate ? checkOutDate : priceListToDate;
            var numberOfDays = minEnd.DayNumber - maxStart.DayNumber + 1;

            return numberOfDays > default(int) ? numberOfDays : default;
        }
    }
}
