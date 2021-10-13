using System.Collections.Generic;

namespace JanHafner.Timewindow.Season
{
    public static class Seasons
    {
        public static readonly SeasonNumber Spring = (SeasonNumber)1;

        public static readonly SeasonNumber Summer = (SeasonNumber)2;

        public static readonly SeasonNumber Fall = (SeasonNumber)3;

        public static readonly SeasonNumber Winter = (SeasonNumber)4;

        public static readonly IReadOnlyCollection<SeasonNumber> All = new[]
        {
            Seasons.Spring,
            Seasons.Summer,
            Seasons.Fall,
            Seasons.Winter,
        };
    }
}
