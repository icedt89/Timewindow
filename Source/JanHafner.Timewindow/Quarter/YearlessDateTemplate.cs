using JanHafner.Timewindow.Month;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace JanHafner.Timewindow.Quarter
{
    [DebuggerDisplay("{Day}.{Month}.XXXX")]
    public readonly struct YearlessDateTemplate : IEquatable<YearlessDateTemplate>, ISerializable
    {
        public YearlessDateTemplate(Month.MonthNumber monthNumber, Day day)
        {
            this.MonthNumber = monthNumber;
            this.Day = day;
        }

        public Month.MonthNumber MonthNumber { get; }

        public Day Day { get; }

        public static YearlessDateTemplate ByDateTime(DateTime dateTime)
        {
            return new YearlessDateTemplate((Month.MonthNumber)dateTime.Month, (Day)dateTime.Day);
        }

        #region IEquatable

        public bool Equals(YearlessDateTemplate other)
        {
            return this.MonthNumber.Equals(other.MonthNumber) && this.Day.Equals(other.Day);
        }

        public override bool Equals(object? obj)
        {
            return obj is Month.Month other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.MonthNumber, this.Day);
        }

        public static bool operator ==(YearlessDateTemplate left, YearlessDateTemplate right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(YearlessDateTemplate left, YearlessDateTemplate right)
        {
            return !(left == right);
        }

        #endregion

        #region ISerializable

        public YearlessDateTemplate(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.MonthNumber = (MonthNumber)info.GetByte("month");
            this.Day = (Day)info.GetByte("day");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("month", (byte)this.MonthNumber);
            info.AddValue("day", (byte)this.Day);
        }

        #endregion
    }
}