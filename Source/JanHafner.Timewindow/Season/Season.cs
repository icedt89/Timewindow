using JanHafner.TimeWindow;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace JanHafner.Timewindow.Season
{
    [DebuggerDisplay("{number}")]
    public readonly struct Season : IEquatable<Season>, IComparable<Season>, ISerializable, ITimewindow
    {
        public const byte MaxValue = 4;

        public const byte MinValue = 1;

        private Season(SeasonNumber number, DateTime start, DateTime end)
        {
            Guard.CheckStartEnd(start, end);

            this.Number = number;
            this.Start = start;
            this.End = end;
        }

        public SeasonNumber Number { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public static Season ByMonthAndYear(SeasonNumber seasonNumber, Year year)
        {
            var startOfMonth = new DateTime((int)year, (int)seasonNumber, 1);
            var endOfMonth = startOfMonth.EndOfMonth();

            return new Season(seasonNumber, startOfMonth, endOfMonth);
        }

        public override bool Equals(object? obj)
        {
            return obj is Season other && this.Equals(other);
        }

        public bool Equals(Season other)
        {
            return this.Number.Equals(other.Number) && this.Start.Equals(other.Start) && this.End.Equals(other.End);
        }

        public override string ToString()
        {
            return this.Number.ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Number, this.Start, this.End);
        }

        public static bool operator ==(Season left, Season right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Season left, Season right)
        {
            return !(left == right);
        }

        public int CompareTo(Season other)
        {
            return this.Number.CompareTo(other.Number);
        }

        #region ISerializable

        public Season(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.Number = (SeasonNumber)info.GetByte("number");
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
