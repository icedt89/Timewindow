using System;
using System.Diagnostics;

namespace JanHafner.Timewindow.Calendarweek
{
    [DebuggerDisplay("{value}")]
    public readonly struct WeekNumber : IEquatable<WeekNumber>, IComparable<WeekNumber>
    {
        public const byte MaxValue = 53;

        public const byte MinValue = 1;

        private readonly byte value;

        private WeekNumber(byte value)
        {
            if (value < MinValue)
            {
                throw new ArgumentException($"{nameof(WeekNumber)} needs to be greater than {MinValue - 1}");
            }

            if (value > MaxValue)
            {
                throw new ArgumentException($"{nameof(WeekNumber)} needs to be smaller than {MaxValue + 1}");
            }

            this.value = value;
        }

        public override bool Equals(object? obj)
        {
            return this.value.Equals(obj);
        }

        public bool Equals(WeekNumber other)
        {
            return this.value.Equals(other.value);
        }

        public static explicit operator byte(WeekNumber value)
        {
            return value.value;
        }

        public static explicit operator WeekNumber(byte value)
        {
            return new WeekNumber(value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(WeekNumber left, WeekNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(WeekNumber left, WeekNumber right)
        {
            return !(left == right);
        }

        public int CompareTo(WeekNumber other)
        {
            return this.value.CompareTo(other.value);
        }
    }
}
