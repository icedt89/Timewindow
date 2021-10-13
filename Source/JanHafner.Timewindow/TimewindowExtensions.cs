using System;

namespace JanHafner.TimeWindow
{
    public static class TimewindowExtensions
    {
        public static Timewindow ShiftYears(this Timewindow timewindow, int years)
        {
            return timewindow.ShiftComponent(years, DateTimeComponent.Year);
        }

        public static Timewindow ShiftQuarters(this Timewindow timewindow, int quarters)
        {
            var start = timewindow.Start.AddQuarter(quarters);
            var end = timewindow.End.AddQuarter(quarters);

            return new Timewindow(start, end);
        }

        public static Timewindow ShiftMonths(this Timewindow timewindow, int months)
        {
            return timewindow.ShiftComponent(months, DateTimeComponent.Month);
        }

        public static Timewindow ShiftWeeks(this Timewindow timewindow, int weeks)
        {
            var start = timewindow.Start.AddWeeks(weeks);
            var end = timewindow.End.AddWeeks(weeks);

            return new Timewindow(start, end);
        }

        public static Timewindow ShiftDays(this Timewindow timewindow, int days)
        {
            return timewindow.ShiftComponent(days, DateTimeComponent.Day);
        }

        public static Timewindow ShiftHours(this Timewindow timewindow, int hours)
        {
            return timewindow.ShiftComponent(hours, DateTimeComponent.Hour);
        }

        public static Timewindow ShiftMinutes(this Timewindow timewindow, int minutes)
        {
            return timewindow.ShiftComponent(minutes, DateTimeComponent.Minute);
        }

        public static Timewindow ShiftSeconds(this Timewindow timewindow, int seconds)
        {
            return timewindow.ShiftComponent(seconds, DateTimeComponent.Second);
        }

        public static Timewindow ShiftMilliseconds(this Timewindow timewindow, int milliseconds)
        {
            return timewindow.ShiftComponent(milliseconds, DateTimeComponent.Millisecond);
        }

        public static Timewindow ShiftComponent(this Timewindow timewindow, int offset, DateTimeComponent component)
        {
            var start = timewindow.Start.AddComponent(offset, component);
            var end = timewindow.End.AddComponent(offset, component);

            return new Timewindow(start, end);
        }

        public static TimeSpan ToTimeSpan(this Timewindow timewindow)
        {
            return timewindow.Start - timewindow.End;
        }

        public static bool Contains(this Timewindow timewindow, DateTime dateTime)
        {
            return dateTime >= timewindow.Start && dateTime <= timewindow.End;
        }

        public static TimewindowContainment Contains(this Timewindow timewindow, Timewindow timewindow1)
        {
            var containsStart = timewindow.Contains(timewindow1.Start);
            var containsEnd = timewindow.Contains(timewindow1.End);
            if (containsEnd && containsStart)
            {
                return TimewindowContainment.Full;
            }

            if ((timewindow1.Start < timewindow.Start && timewindow1.End < timewindow.Start)
             || (timewindow1.Start > timewindow.End && timewindow1.End > timewindow.End))
            {
                return TimewindowContainment.NotContained;
            }

            return TimewindowContainment.Partial;
        }
    }
}