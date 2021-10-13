using JanHafner.Timewindow.Month;

namespace JanHafner.Timewindow.Season
{
    public static class SeasonExtensions
    {
        public static Season ToMonth(this SeasonNumber seasonNumber, Year year)
        {
            return Season.ByMonthAndYear(seasonNumber, year);
        }
    }
}
