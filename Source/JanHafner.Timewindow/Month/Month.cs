using JanHafner.TimeWindow;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace JanHafner.Timewindow.Month
{
    [DebuggerDisplay("{Number} {Start} - {End}")]
    public readonly struct Month : IEquatable<Month>, ISerializable, IComparable<Month>, ITimewindow
    {
        private Month(MonthNumber number, DateTime start, DateTime end)
        {
            Guard.CheckStartEnd(start, end);

            this.Number = number;
            this.Start = start;
            this.End = end;
        }

        public MonthNumber Number { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public static Month ByMonthAndYear(MonthNumber monthNumber, Year year)
        {
            var startOfMonth = new DateTime((int)year, (int)monthNumber, 1);
            var endOfMonth = startOfMonth.EndOfMonth();

            return new Month(monthNumber, startOfMonth, endOfMonth);
        }

        public bool Equals(Month other)
        {
            return this.Number.Equals(other.Number) && this.Start.Equals(other.Start) && this.End.Equals(other.End);
        }

        public override bool Equals(object? obj)
        {
            return obj is Month other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Number, this.Start, this.End);
        }

        public static bool operator ==(Month left, Month right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Month left, Month right)
        {
            return !(left == right);
        }

        public int CompareTo(Month other)
        {
            return this.Number.CompareTo(other.Number);
        }

        #region ISerializable

        public Month(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.Number = (MonthNumber)info.GetByte("number");
            this.Start = info.GetDateTime("start");
            this.End = info.GetDateTime("end");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("number", this.Number);
            info.AddValue("start", this.Start);
            info.AddValue("end", this.End);
        }

        #endregion
    }
}