using System;
using System.Diagnostics;

namespace JanHafner.Timewindow
{
    [DebuggerDisplay("{value}")]
    public readonly struct Day : IEquatable<Day>, IComparable<Day>
    {
        public const byte MaxValue = 31;

        public const byte MinValue = 1;

        private readonly byte value;

        private Day(byte value)
        {
            if (value < Day.MinValue)
            {
                throw new ArgumentException($"{nameof(Day)} needs to be greater than {Day.MinValue - 1}");
            }

            if (value > Day.MaxValue)
            {
                throw new ArgumentException($"{nameof(Day)} needs to be smaller than {Day.MaxValue + 1}");
            }

            this.value = value;
        }

        public override bool Equals(object? obj)
        {
            return this.value.Equals(obj);
        }

        public bool Equals(Day other)
        {
            return this.value.Equals(other.value);
        }

        public static explicit operator byte(Day value)
        {
            return value.value;
        }

        public static explicit operator Day(byte value)
        {
            return new Day(value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public int CompareTo(Day other)
        {
            return this.value.CompareTo(other.value);
        }

        public static bool operator ==(Day left, Day right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Day left, Day right)
        {
            return !(left == right);
        }
    }
}
