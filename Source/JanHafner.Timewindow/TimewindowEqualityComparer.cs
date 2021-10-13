using JanHafner.Timewindow.Month;
using System.Collections.Generic;

namespace JanHafner.TimeWindow
{
    public sealed class TimewindowEqualityComparer : IEqualityComparer<Month>
    {
        public static readonly TimewindowEqualityComparer Instance = new TimewindowEqualityComparer();

        public bool Equals(Month x, Month y)
        {
            return object.Equals(x, y);
        }

        public int GetHashCode(Month obj)
        {
            return obj.GetHashCode();
        }
    }
}