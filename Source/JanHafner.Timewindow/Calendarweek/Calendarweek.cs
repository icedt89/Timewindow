using JanHafner.TimeWindow;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace JanHafner.Timewindow.Calendarweek
{
    [DebuggerDisplay("CW {WeekNumber}/{Year} ({Start} - {End})")]
    public readonly struct Calendarweek : ISerializable, IEquatable<Calendarweek>, ITimewindow
    {
        public const byte COUNT_OF_DAYS_IN_WEEK = 7;

        public Calendarweek(DateTime start, DateTime end, Year year, WeekNumber weekNumber)
        {
            Guard.CheckStartEnd(start, end);

            this.Start = start;
            this.End = end;
            this.Year = year;
            this.WeekNumber = weekNumber;
        }

        public Year Year { get; }

        public WeekNumber WeekNumber { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public bool IsYearCrossing => this.Start.Year != this.End.Year;

        public static IEnumerable<Calendarweek> EnumerateCalendarweeksOfYear(Year year,
            Calendar? calendar = null,
            CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFourDayWeek,
            DayOfWeek weekStart = DayOfWeek.Monday)
        {
            calendar ??= CultureInfo.GetCultureInfo("de-DE").Calendar;

            var datum = new DateTime((int)year, 1, 1);
            while (datum.Year == (int)year)
            {
                yield return Calendarweek.ByDateTime(datum, calendar, calendarWeekRule, weekStart);

                datum = calendar.AddWeeks(datum, 1);
            }
        }

        public static Calendarweek ByDateTime(DateTime dateTime,
            Calendar calendar,
            CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFourDayWeek,
            DayOfWeek weekStart = DayOfWeek.Monday)
        {
            if (calendar is null)
            {
                throw new ArgumentNullException(nameof(calendar));
            }

            var iso8601WeekNumber = ComputeISO8601WeekNumber(dateTime, calendar, calendarWeekRule, weekStart);

            var adjustedYearOfCalendarweek = ComputeAdjustedYearOfWeekNumber(dateTime, iso8601WeekNumber);

            var startOfWeek = dateTime.GetDateOfNextWeekday(weekStart, TimeDirection.Past);
            var endOfWeek = startOfWeek.AddDays(COUNT_OF_DAYS_IN_WEEK - 1);

            return new Calendarweek(startOfWeek, endOfWeek, adjustedYearOfCalendarweek, iso8601WeekNumber);
        }

        public static WeekNumber ComputeISO8601WeekNumber(DateTime dateTime,
            Calendar calendar,
            CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFourDayWeek,
            DayOfWeek weekStart = DayOfWeek.Monday)
        {
            if (calendar is null)
            {
                throw new ArgumentNullException(nameof(calendar));
            }

            var day = calendar.GetDayOfWeek(dateTime);
            if (day >= weekStart && day <= DayOfWeek.Wednesday)
            {
                dateTime = dateTime.AddDays(3);
            }

            return (WeekNumber)calendar.GetWeekOfYear(dateTime, calendarWeekRule, weekStart);
        }

        public static Year ComputeAdjustedYearOfWeekNumber(DateTime dateTime, WeekNumber weekNumber)
        {
            return (Year)(dateTime.Month == 1 && (byte)weekNumber == 53 ? dateTime.Year - 1 : dateTime.Month == 12 && (byte)weekNumber == 1 ? dateTime.Year + 1 : dateTime.Year);
        }

        #region ISerializable

        public Calendarweek(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.Year = (Year)info.GetUInt16("year");
            this.WeekNumber = (WeekNumber)info.GetByte("weekNumber");
            this.Start = info.GetDateTime("start");
            this.End = info.GetDateTime("end");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("year", (ushort)this.Year);
            info.AddValue("weekNumber", (byte)this.WeekNumber);
            info.AddValue("start", this.Start);
            info.AddValue("end", this.End);
        }

        #endregion

        #region IEquatable

        public bool Equals(Calendarweek other)
        {
            return this.Start.Equals(other.Start) && this.End.Equals(other.End) && this.WeekNumber.Equals(other.WeekNumber) && this.Year.Equals(other.Year);
        }

        public override bool Equals(object? obj)
        {
            return obj is Calendarweek other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Start, this.End, this.Year, this.WeekNumber);
        }

        public static bool operator ==(Calendarweek left, Calendarweek right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Calendarweek left, Calendarweek right)
        {
            return !(left == right);
        }

        #endregion
    }
}