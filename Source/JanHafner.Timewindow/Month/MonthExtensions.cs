namespace JanHafner.Timewindow.Month
{
    public static class MonthExtensions
    {
        public static Month ToMonth(this MonthNumber monthNumber, Year year)
        {
            return Month.ByMonthAndYear(monthNumber, year);
        }
    }
}
