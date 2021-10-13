using System;

namespace JanHafner.TimeWindow
{
    public static class Guard
    {
        public static void CheckStartEnd(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new ArgumentException("Start needs to be before end");
            }
        }
    }
}
