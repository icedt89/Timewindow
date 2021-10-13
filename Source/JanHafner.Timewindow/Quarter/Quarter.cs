using JanHafner.Timewindow.Month;
using JanHafner.TimeWindow;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace JanHafner.Timewindow.Quarter
{
    [DebuggerDisplay("Q{QuarterNumber}/{Year} ({Start} - {End})")]
    public readonly struct Quarter : IEquatable<Quarter>, ISerializable, ITimewindow
    {
        public const byte COUNT_OF_QUARTERS_IN_YEAR = 4;

        public const byte COUNT_OF_MONTHS_IN_QUARTER = 3;

        public static readonly IReadOnlyDictionary<QuarterNumber, YearlessDateTemplate> QuarterTemplates = new Dictionary<QuarterNumber, YearlessDateTemplate>
        {
            {
                (QuarterNumber)1,
                new YearlessDateTemplate((MonthNumber)1, (Day)1)
            },
            {
                (QuarterNumber)2,
                new YearlessDateTemplate((MonthNumber)4, (Day)1)
            },
            {
                (QuarterNumber)3,
                new YearlessDateTemplate((MonthNumber)7, (Day)1)
            },
            {
                (QuarterNumber)4,
                new YearlessDateTemplate((MonthNumber)10, (Day)1)
            }
        };

        private Quarter(DateTime start, DateTime end, Year year, QuarterNumber quarterNumber)
        {
            Guard.CheckStartEnd(start, end);

            this.Start = start;
            this.End = end;
            this.Year = year;
            this.QuarterNumber = quarterNumber;
        }

        public Year Year { get; }

        public QuarterNumber QuarterNumber { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public static IEnumerable<Quarter> EnumerateQuartersOfYear(Year year)
        {
            return QuarterTemplates.Select(qt =>
            {
                var quarterStart = qt.Value.ToDateTime(year);
                var quarterEnd = quarterStart.AddQuarter(1).AddMilliseconds(-1).StartOfDay();

                return new Quarter(quarterStart, quarterEnd, year, qt.Key);
            });
        }

        public bool Equals(Quarter other)
        {
            return this.Start.Equals(other.Start) && this.End.Equals(other.End) && this.QuarterNumber.Equals(other.QuarterNumber) && this.Year.Equals(other.Year);
        }

        public override bool Equals(object? obj)
        {
            return obj is Month.Month other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Start, this.End, this.QuarterNumber, this.Year);
        }

        public static bool operator ==(Quarter left, Quarter right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Quarter left, Quarter right)
        {
            return !(left == right);
        }

        #region ISerializable

        public Quarter(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.Year = (Year)info.GetUInt16("year");
            this.QuarterNumber = (QuarterNumber)info.GetByte("quarterNumber");
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
            info.AddValue("quarterNumber", (byte)this.QuarterNumber);
            info.AddValue("start", this.Start);
            info.AddValue("end", this.End);
        }

        #endregion
    }
}