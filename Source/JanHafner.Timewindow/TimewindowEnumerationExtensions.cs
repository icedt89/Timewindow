using System;
using System.Linq;
using System.Collections.Generic;

namespace JanHafner.TimeWindow
{
    public static class TimewindowEnumerationExtensions
    {
        public static IEnumerable<Timewindow> EnumerateYears(this Timewindow timewindow)
        {
            return timewindow.EnumerateComponent(DateTimeComponent.Year);
        }

        public static IEnumerable<Timewindow> EnumerateMonths(this Timewindow timewindow)
        {
            return timewindow.EnumerateComponent(DateTimeComponent.Month);
        }

        public static IEnumerable<Timewindow> EnumerateDays(this Timewindow timewindow)
        {
            return timewindow.EnumerateComponent(DateTimeComponent.Day);
        }

        public static IEnumerable<Timewindow> EnumerateHours(this Timewindow timewindow)
        {
            return timewindow.EnumerateComponent(DateTimeComponent.Hour);
        }

        public static IEnumerable<Timewindow> EnumerateMinutes(this Timewindow timewindow)
        {
            return timewindow.EnumerateComponent(DateTimeComponent.Minute);
        }

        public static IEnumerable<Timewindow> EnumerateSeconds(this Timewindow timewindow)
        {
            return timewindow.EnumerateComponent(DateTimeComponent.Second);
        }

        public static IEnumerable<DateTime> EnumerateMilliseconds(this Timewindow timewindow)
        {
            return timewindow.EnumerateComponent(DateTimeComponent.Millisecond).Select(_ => _.Start);
        }

        public static IEnumerable<Timewindow> EnumerateComponent(this Timewindow timewindow, DateTimeComponent component)
        {
            return timewindow.EnumerateWithFactory(d => d.AddComponent(1, component));
        }

        private static IEnumerable<Timewindow> EnumerateWithFactory(this Timewindow timewindow, Func<DateTime, DateTime> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            var current = timewindow.Start;
            while (current <= timewindow.End)
            {
                var end = factory(current);

                yield return new Timewindow(current, end);

                current = factory(end);
            }
        }
    }
}
