using System.Collections.Generic;

namespace JanHafner.Timewindow.Quarter
{
    public sealed class YearlessDateTemplateEqualityComparer : IEqualityComparer<YearlessDateTemplate>
    {
        public static readonly YearlessDateTemplateEqualityComparer Instance = new YearlessDateTemplateEqualityComparer();

        public bool Equals(YearlessDateTemplate x, YearlessDateTemplate y)
        {
            return object.Equals(x, y);
        }

        public int GetHashCode(YearlessDateTemplate obj)
        {
            return obj.GetHashCode();
        }
    }
}