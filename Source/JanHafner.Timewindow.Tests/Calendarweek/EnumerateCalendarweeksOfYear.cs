using FluentAssertions;
using JanHafner.Timewindow.Calendarweek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace JanHafner.Timewindow.Tests.Calendarweek
{
    public sealed class EnumerateCalendarweeksOfYear
    {
        [Fact]
        public void EnumeratesTheWeeksOf2020Correctly()
        {
            // Arrange
            var year = (JanHafner.Timewindow.Year)2020;
            var expectedCalendarweeks = new[]
            {
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2019, 12, 30), new DateTime(2020, 1, 5), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)1),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 1, 6), new DateTime(2020, 1, 12), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)2),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 1, 13), new DateTime(2020, 1, 19), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)3),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 1, 20), new DateTime(2020, 1, 26), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)4),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 1, 27), new DateTime(2020, 2, 2), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)5),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 2, 3), new DateTime(2020, 2, 9), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)6),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 2, 10), new DateTime(2020, 2, 16), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)7),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 2, 17), new DateTime(2020, 2, 23), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)8),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 2, 24), new DateTime(2020, 3, 1), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)9),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 3, 2), new DateTime(2020, 3, 8), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)10),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 3, 9), new DateTime(2020, 3, 15), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)11),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 3, 16), new DateTime(2020, 3, 22), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)12),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 3, 23), new DateTime(2020, 3, 29), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)13),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 3, 30), new DateTime(2020, 4, 5), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)14),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 4, 6), new DateTime(2020, 4, 12), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)15),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 4, 13), new DateTime(2020, 4, 19), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)16),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 4, 20), new DateTime(2020, 4, 26), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)17),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 4, 27), new DateTime(2020, 5, 3), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)18),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 5, 4), new DateTime(2020, 5, 10), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)19),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 5, 11), new DateTime(2020, 5, 17), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)20),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 5, 18), new DateTime(2020, 5, 24), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)21),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 5, 25), new DateTime(2020, 5, 31), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)22),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 6, 1), new DateTime(2020, 6, 7), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)23),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 6, 8), new DateTime(2020, 6, 14), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)24),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 6, 15), new DateTime(2020, 6, 21), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)25),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 6, 22), new DateTime(2020, 6, 28), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)26),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 6, 29), new DateTime(2020, 7, 5), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)27),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 7, 6), new DateTime(2020, 7, 12), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)28),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 7, 13), new DateTime(2020, 7, 19), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)29),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 7, 20), new DateTime(2020, 7, 26), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)30),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 7, 27), new DateTime(2020, 8, 2), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)31),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 8, 3), new DateTime(2020, 8, 9), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)32),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 8, 10), new DateTime(2020, 8, 16), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)33),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 8, 17), new DateTime(2020, 8, 23), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)34),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 8, 24), new DateTime(2020, 8, 30), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)35),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 8, 31), new DateTime(2020, 9, 6), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)36),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 9, 7), new DateTime(2020, 9, 13), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)37),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 9, 14), new DateTime(2020, 9, 20), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)38),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 9, 21), new DateTime(2020, 9, 27), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)39),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 9, 28), new DateTime(2020, 10, 4), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)40),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 10, 5), new DateTime(2020, 10, 11), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)41),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 10, 12), new DateTime(2020, 10, 18), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)42),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 10, 19), new DateTime(2020, 10, 25), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)43),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 10, 26), new DateTime(2020, 11, 1), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)44),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 11, 2), new DateTime(2020, 11, 8), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)45),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 11, 9), new DateTime(2020, 11, 15), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)46),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 11, 16), new DateTime(2020, 11, 22), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)47),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 11, 23), new DateTime(2020, 11, 29), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)48),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 11, 30), new DateTime(2020, 12, 6), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)49),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 12, 7), new DateTime(2020, 12, 13), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)50),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 12, 14), new DateTime(2020, 12, 20), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)51),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 12, 21), new DateTime(2020, 12, 27), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)52),
                new JanHafner.Timewindow.Calendarweek.Calendarweek(new DateTime(2020, 12, 28), new DateTime(2021, 1, 3), (JanHafner.Timewindow.Year)2020, (JanHafner.Timewindow.Calendarweek.WeekNumber)53),
            };

            // Act
            var calendarweeks = JanHafner.Timewindow.Calendarweek.Calendarweek.EnumerateCalendarweeksOfYear(year)
                                                                              .ToList();

            // Assert
            calendarweeks.Should().HaveCount(expectedCalendarweeks.Count());

            foreach(var calendarweek in calendarweeks)
            {
                expectedCalendarweeks.Should().Contain(calendarweek);
            }
        }
    }
}
