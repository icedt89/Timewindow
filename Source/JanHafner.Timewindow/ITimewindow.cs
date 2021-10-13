using System;

namespace JanHafner.TimeWindow
{
    public interface ITimewindow
    {
        public DateTime Start { get; }

        public DateTime End { get; }
    }
}