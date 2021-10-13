using System;

namespace JanHafner.Timewindow.Quarter
{
    public static class YearlessDateTemplateExtensions
    {
        public static DateTime ToDateTime(this YearlessDateTemplate yearlessDateTemplate, Year year)
        {
            return new DateTime((int)year, (int)yearlessDateTemplate.MonthNumber, (int)yearlessDateTemplate.Day);
        }

        public static YearlessDateTemplate ToYearlessDateTemplate(this DateTime dateTime)
        {
            return YearlessDateTemplate.ByDateTime(dateTime);
        }
    }
}