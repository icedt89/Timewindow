using JanHafner.Timewindow;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace JanHafner.TimeWindow
{
    [DebuggerDisplay("{Start} - {End}")]
    public readonly struct Timewindow : IEquatable<Timewindow>, ISerializable, ITimewindow
    {
        public Timewindow(DateTime start, DateTime end)
        {
            Guard.CheckStartEnd(start, end);

            this.Start = start;
            this.End = end;
        }

        public DateTime Start { get; }

        public DateTime End { get; }

        public static Timewindow ByYear(Year year)
        {
            var startOfYear = new DateTime((int)year, 1, 1);

            return startOfYear.TimewindowByYearComponent();
        }

        public bool Equals(Timewindow other)
        {
            return this.Start.Equals(other.Start) && this.End.Equals(other.End);
        }

        public override bool Equals(object? obj)
        {
            return obj is Timewindow other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Start, this.End);
        }

        public static bool operator ==(Timewindow left, Timewindow right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Timewindow left, Timewindow right)
        {
            return !(left == right);
        }

        #region ISerializable

        public Timewindow(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.Start = info.GetDateTime("start");
            this.End = info.GetDateTime("end");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("start", this.Start);
            info.AddValue("end", this.End);
        }

        #endregion
    }
}