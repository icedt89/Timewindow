using System;
using System.Diagnostics;

namespace JanHafner.Timewindow.Season
{
    [DebuggerDisplay("{value}")]
    public readonly struct SeasonNumber : IEquatable<SeasonNumber>, IComparable<SeasonNumber>
    {
        public const byte MaxValue = 4;

        public const byte MinValue = 1;

        private readonly byte value;

        private SeasonNumber(byte value)
        {
            if (value < MinValue)
            {
                throw new ArgumentException($"{nameof(Month)} needs to be greater than {MinValue - 1}");
            }

            if (value > MaxValue)
            {
                throw new ArgumentException($"{nameof(Month)} needs to be smaller than {MaxValue + 1}");
            }

            this.value = value;
        }

        public override bool Equals(object? obj)
        {
            return this.value.Equals(obj);
        }

        public bool Equals(SeasonNumber other)
        {
            return this.value.Equals(other.value);
        }

        public static explicit operator byte(SeasonNumber value)
        {
            return value.value;
        }

        public static explicit operator SeasonNumber(byte value)
        {
            return new SeasonNumber(value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(SeasonNumber left, SeasonNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SeasonNumber left, SeasonNumber right)
        {
            return !(left == right);
        }

        public int CompareTo(SeasonNumber other)
        {
            return this.value.CompareTo(other.value);
        }
    }
}
