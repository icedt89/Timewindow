using System.Collections.Generic;

namespace JanHafner.Timewindow.Month
{
    public static class MonthNumbers
    {
        public static readonly MonthNumber January = (MonthNumber)1;

        public static readonly MonthNumber February = (MonthNumber)2;

        public static readonly MonthNumber March = (MonthNumber)3;

        public static readonly MonthNumber April = (MonthNumber)4;

        public static readonly MonthNumber May = (MonthNumber)5;

        public static readonly MonthNumber Juni = (MonthNumber)6;

        public static readonly MonthNumber Juli = (MonthNumber)7;

        public static readonly MonthNumber August = (MonthNumber)8;

        public static readonly MonthNumber September = (MonthNumber)9;

        public static readonly MonthNumber October = (MonthNumber)10;

        public static readonly MonthNumber November = (MonthNumber)11;

        public static readonly MonthNumber December = (MonthNumber)12;

        public static readonly IReadOnlyCollection<MonthNumber> All = new[]
        {
            MonthNumbers.January,
            MonthNumbers.February,
            MonthNumbers.March,
            MonthNumbers.April,
            MonthNumbers.May,
            MonthNumbers.Juni,
            MonthNumbers.Juli,
            MonthNumbers.August,
            MonthNumbers.September,
            MonthNumbers.October,
            MonthNumbers.November,
            MonthNumbers.December,
        };
    }
}
