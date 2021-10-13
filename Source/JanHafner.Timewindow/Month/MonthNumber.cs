using System;
using System.Diagnostics;

namespace JanHafner.Timewindow.Month
{
    [DebuggerDisplay("{value}")]
    public readonly struct MonthNumber : IEquatable<MonthNumber>, IComparable<MonthNumber>
    {
        public const byte MaxValue = 12;

        public const byte MinValue = 1;

        private readonly byte value;

        private MonthNumber(byte value)
        {
            if (value < MinValue)
            {
                throw new ArgumentException($"{nameof(MonthNumber)} needs to be greater than {MinValue - 1}");
            }

            if (value > MaxValue)
            {
                throw new ArgumentException($"{nameof(MonthNumber)} needs to be smaller than {MaxValue + 1}");
            }

            this.value = value;
        }

        public override bool Equals(object? obj)
        {
            return this.value.Equals(obj);
        }

        public bool Equals(MonthNumber other)
        {
            return this.value.Equals(other.value);
        }

        public static explicit operator byte(MonthNumber value)
        {
            return value.value;
        }

        public static explicit operator MonthNumber(byte value)
        {
            return new MonthNumber(value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(MonthNumber left, MonthNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MonthNumber left, MonthNumber right)
        {
            return !(left == right);
        }

        public int CompareTo(MonthNumber other)
        {
            return this.value.CompareTo(other.value);
        }
    }
}
