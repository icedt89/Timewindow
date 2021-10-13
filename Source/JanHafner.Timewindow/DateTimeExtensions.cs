using JanHafner.Timewindow.Calendarweek;
using JanHafner.Timewindow.Quarter;
using System;
using System.Collections.Generic;

namespace JanHafner.TimeWindow
{
    public static class DateTimeExtensions
    {
        private static IEnumerable<Timewindow> EnumerateByComponent(this DateTime dateTime,
            TimeDirection timeDirection,
            DateTimeComponent component,
            bool includeCurrent = true)
        {
            if (timeDirection == TimeDirection.Past)
            {
                var offset = -1;
                var boundary = DateTime.MinValue;

                var current = includeCurrent ? dateTime : dateTime.AddComponent(offset, component);
                while (current >= boundary)
                {
                    var end = current.AddComponent(offset, component);

                    yield return new Timewindow(current, end);

                    current = current.AddMilliseconds(1);
                }
            }
            else
            {
                var offset = 1;
                var boundary = DateTime.MaxValue;

                var current = includeCurrent ? dateTime : dateTime.AddComponent(offset, component);
                while (current <= boundary)
                {
                    var end = current.AddComponent(offset, component);

                    yield return new Timewindow(current, end);

                    current = current.AddMilliseconds(1);
                }
            }
        }

        public static DateTime GetDateOfNextWeekday(this DateTime dateTime, DayOfWeek dayOfWeek, TimeDirection timeDirection = TimeDirection.Future)
        {
            var offset = timeDirection == TimeDirection.Future ? 1 : -1;

            var result = dateTime;
            while (result.DayOfWeek != dayOfWeek)
            {
                result = result.AddDays(offset);
            }

            return result;
        }

        public static int GetQuarterNumber(this DateTime dateTime)
        {
            return (dateTime.Month + 2) / 4;
        }

        public static Timewindow TimewindowByYearComponent(this DateTime dateTime)
        {
            return dateTime.TimewindowByComponent(DateTimeComponent.Year);
        }

        public static Timewindow TimewindowByMonthComponent(this DateTime dateTime)
        {
            return dateTime.TimewindowByComponent(DateTimeComponent.Month);
        }

        public static Timewindow TimewindowByDayComponent(this DateTime dateTime)
        {
            return dateTime.TimewindowByComponent(DateTimeComponent.Day);
        }

        public static Timewindow TimewindowByHourComponent(this DateTime dateTime)
        {
            return dateTime.TimewindowByComponent(DateTimeComponent.Hour);
        }

        public static Timewindow TimewindowByMinuteComponent(this DateTime dateTime)
        {
            return dateTime.TimewindowByComponent(DateTimeComponent.Minute);
        }

        public static Timewindow TimewindowBySecondComponent(this DateTime dateTime)
        {
            return dateTime.TimewindowByComponent(DateTimeComponent.Second);
        }

        public static Timewindow TimewindowByComponent(this DateTime dateTime, DateTimeComponent component)
        {
            return component switch
            {
                DateTimeComponent.Year => new Timewindow(dateTime.StartOfYear(), dateTime.EndOfYear()),
                DateTimeComponent.Month => new Timewindow(dateTime.StartOfMonth(), dateTime.EndOfMonth()),
                DateTimeComponent.Day => new Timewindow(dateTime.StartOfDay(), dateTime.EndOfDay()),
                DateTimeComponent.Hour => new Timewindow(dateTime.StartOfHour(), dateTime.EndOfHour()),
                DateTimeComponent.Minute => new Timewindow(dateTime.StartOfMinute(), dateTime.EndOfMinute()),
                DateTimeComponent.Second => new Timewindow(dateTime.StartOfSecond(), dateTime.EndOfSecond()),
                _ => throw new ArgumentOutOfRangeException(nameof(component), component, null),
            };
        }

        public static DateTime AddWeeks(this DateTime dateTime, int weeks)
        {
            return dateTime.AddDays(Calendarweek.COUNT_OF_DAYS_IN_WEEK * weeks);
        }

        public static DateTime AddQuarter(this DateTime dateTime, int quarters)
        {
            return dateTime.AddMonths(Quarter.COUNT_OF_MONTHS_IN_QUARTER * quarters);
        }

        public static DateTime AddComponent(this DateTime dateTime, int offset, DateTimeComponent component)
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

        public static int GetComponent(this DateTime dateTime, DateTimeComponent component)
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

        public static DateTime StartOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1, 0, 0, 0, dateTime.Millisecond, dateTime.Kind);
        }

        public static DateTime EndOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 12, 31, 23, 59, 59, 999, dateTime.Kind);
        }

        public static DateTime StartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0, dateTime.Millisecond, dateTime.Kind);
        }

        public static DateTime EndOfMonth(this DateTime dateTime)
        {
            var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            return new DateTime(dateTime.Year, dateTime.Month, daysInMonth, 23, 59, 59, 999, dateTime.Kind);
        }

        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
        }

        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999, dateTime.Kind);
        }

        public static DateTime StartOfHour(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Kind);
        }

        public static DateTime EndOfHour(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 59, 59, 999, dateTime.Kind);
        }

        public static DateTime StartOfMinute(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Kind);
        }

        public static DateTime EndOfMinute(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 59, 999, dateTime.Kind);
        }

        public static DateTime StartOfSecond(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Kind);
        }

        public static DateTime EndOfSecond(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, 999, dateTime.Kind);
        }

        public static DateTime ToCurrentYear(this DateTime dateTime)
        {
            return dateTime.ToYear(DateTime.Today.Year);
        }

        public static DateTime ToYear(this DateTime dateTime, int year)
        {
            var yearDifference = year - dateTime.Year;

            return dateTime.AddYears(yearDifference);
        }
    }
}