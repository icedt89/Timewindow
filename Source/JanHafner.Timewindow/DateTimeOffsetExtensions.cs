using JanHafner.Timewindow.Calendarweek;
using JanHafner.Timewindow.Quarter;
using System;

namespace JanHafner.TimeWindow
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset GetDateOfNextWeekday(this DateTimeOffset dateTime, DayOfWeek dayOfWeek, TimeDirection timeDirection = TimeDirection.Future)
        {
            var offset = timeDirection == TimeDirection.Future ? 1 : -1;

            var result = dateTime;
            while (result.DayOfWeek != dayOfWeek)
            {
                result = result.AddDays(offset);
            }

            return result;
        }

        public static int GetQuarterNumber(this DateTimeOffset dateTime)
        {
            return (dateTime.Month + 2) / 4;
        }

        public static DateTimeOffset AddWeeks(this DateTimeOffset dateTime, int weeks)
        {
            return dateTime.AddDays(Calendarweek.COUNT_OF_DAYS_IN_WEEK * weeks);
        }

        public static DateTimeOffset AddQuarter(this DateTimeOffset dateTime, int quarters)
        {
            return dateTime.AddMonths(Quarter.COUNT_OF_MONTHS_IN_QUARTER * quarters);
        }

        public static DateTimeOffset AddComponent(this DateTimeOffset dateTime, int offset, DateTimeComponent component)
        {
            return component switch
            {
                DateTimeComponent.Year => dateTime.AddYears(offset),
                DateTimeComponent.Month => dateTime.AddMonths(offset),
                DateTimeComponent.Day => dateTime.AddDays(offset),
                DateTimeComponent.Hour => dateTime.AddHours(offset),
                DateTimeComponent.Minute => dateTime.AddMinutes(offset),
                DateTimeComponent.Second => dateTime.AddSeconds(offset),
                DateTimeComponent.Millisecond => dateTime.AddMilliseconds(offset),
                _ => throw new ArgumentOutOfRangeException(nameof(component), component, null),
            };
        }

        public static int GetComponent(this DateTimeOffset dateTime, DateTimeComponent component)
        {
            return component switch
            {
                DateTimeComponent.Year => dateTime.Year,
                DateTimeComponent.Month => dateTime.Month,
                DateTimeComponent.Day => dateTime.Day,
                DateTimeComponent.Hour => dateTime.Hour,
                DateTimeComponent.Minute => dateTime.Minute,
                DateTimeComponent.Second => dateTime.Second,
                DateTimeComponent.Millisecond => dateTime.Millisecond,
                _ => throw new ArgumentOutOfRangeException(nameof(component), component, null),
            };
        }

        public static DateTimeOffset StartOfYear(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, 1, 1, 0, 0, 0, dateTime.Millisecond, dateTime.Offset);
        }

        public static DateTimeOffset EndOfYear(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, 12, 31, 23, 59, 59, 999, dateTime.Offset);
        }

        public static DateTimeOffset StartOfMonth(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, 1, 0, 0, 0, dateTime.Millisecond, dateTime.Offset);
        }

        public static DateTimeOffset EndOfMonth(this DateTimeOffset dateTime)
        {
            var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            return new DateTimeOffset(dateTime.Year, dateTime.Month, daysInMonth, 23, 59, 59, 999, dateTime.Offset);
        }

        public static DateTimeOffset StartOfDay(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Offset);
        }

        public static DateTimeOffset EndOfDay(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999, dateTime.Offset);
        }

        public static DateTimeOffset StartOfHour(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Offset);
        }

        public static DateTimeOffset EndOfHour(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 59, 59, 999, dateTime.Offset);
        }

        public static DateTimeOffset StartOfMinute(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Offset);
        }

        public static DateTimeOffset EndOfMinute(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 59, 999, dateTime.Offset);
        }

        public static DateTimeOffset StartOfSecond(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Offset);
        }

        public static DateTimeOffset EndOfSecond(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, 999, dateTime.Offset);
        }

        public static DateTimeOffset ToCurrentYear(this DateTimeOffset dateTime)
        {
            return dateTime.ToYear(DateTime.Today.Year);
        }

        public static DateTimeOffset ToYear(this DateTimeOffset dateTime, int year)
        {
            var yearDifference = year - dateTime.Year;

            return dateTime.AddYears(yearDifference);
        }
    }
}