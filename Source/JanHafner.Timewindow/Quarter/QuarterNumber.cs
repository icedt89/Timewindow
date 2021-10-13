using System;
using System.Diagnostics;

namespace JanHafner.Timewindow.Quarter
{
    [DebuggerDisplay("{value}")]
    public readonly struct QuarterNumber : IEquatable<QuarterNumber>, IComparable<QuarterNumber>
    {
        public const byte MaxValue = 4;

        public const byte MinValue = 1;

        private readonly byte value;

        private QuarterNumber(byte value)
        {
            if (value < QuarterNumber.MinValue)
            {
                throw new ArgumentException($"{nameof(QuarterNumber)} needs to be greater than {QuarterNumber.MinValue - 1}");
            }

            if (value > QuarterNumber.MaxValue)
            {
                throw new ArgumentException($"{nameof(QuarterNumber)} needs to be smaller than {QuarterNumber.MaxValue + 1}");
            }

            this.value = value;
        }

        public override bool Equals(object? obj)
        {
            return this.value.Equals(obj);
        }

        public bool Equals(QuarterNumber other)
        {
            return this.value.Equals(other.value);
        }

        public static explicit operator byte(QuarterNumber value)
        {
            return value.value;
        }

        public static explicit operator QuarterNumber(byte value)
        {
            return new QuarterNumber(value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(QuarterNumber left, QuarterNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuarterNumber left, QuarterNumber right)
        {
            return !(left == right);
        }

        public int CompareTo(QuarterNumber other)
        {
            return this.value.CompareTo(other.value);
        }
    }
}
