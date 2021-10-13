using System;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace JanHafner.Timewindow
{
    [DebuggerDisplay("{value}")]
    public readonly struct Year : IEquatable<Year>, IComparable<Year>
    {
        public static readonly int MaxValue = DateTime.MaxValue.Year;

        public static readonly int MinValue = DateTime.MinValue.Year;

        private readonly ushort value;

        private Year(ushort value)
        {
            if (value < Year.MinValue)
            {
                throw new ArgumentException($"{nameof(Year)} needs to be greater than {Year.MinValue - 1}");
            }

            if (value > Year.MaxValue)
            {
                throw new ArgumentException($"{nameof(Year)} needs to be smaller than {Year.MaxValue + 1}");
            }

            this.value = value;
        }

        public override bool Equals(object? obj)
        {
            return this.value.Equals(obj);
        }

        public bool Equals(Year other)
        {
            return this.value.Equals(other.value);
        }

        public static explicit operator ushort(Year value)
        {
            return value.value;
        }

        public static explicit operator Year(ushort value)
        {
            return new Year(value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(Year left, Year right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Year left, Year right)
        {
            return !(left == right);
        }

        public int CompareTo(Year other)
        {
            return this.value.CompareTo(other.value);
        }
    }
}
