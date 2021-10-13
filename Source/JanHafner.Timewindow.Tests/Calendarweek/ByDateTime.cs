using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace JanHafner.Timewindow.Tests.Calendarweek
{
    public sealed class ByDateTime
    {
        [Theory]
        [InlineData("30.12.2019", "30.12.2019", "05.01.2020", 1, 2020)]
        [InlineData("02.01.2020", "30.12.2019", "05.01.2020", 1, 2020)]
        [InlineData("05.01.2020", "30.12.2019", "05.01.2020", 1, 2020)]
        [InlineData("04.01.2021", "04.01.2021", "10.01.2021", 1, 2021)]
        [InlineData("07.01.2021", "04.01.2021", "10.01.2021", 1, 2021)]
        [InlineData("10.01.2021", "04.01.2021", "10.01.2021", 1, 2021)]
        [InlineData("25.01.2021", "25.01.2021", "31.01.2021", 4, 2021)]
        [InlineData("29.01.2021", "25.01.2021", "31.01.2021", 4, 2021)]
        [InlineData("31.01.2021", "25.01.2021", "31.01.2021", 4, 2021)]
        public void ComputesTheCorrectCalendarweek(string dateToCheckString,
            string expectedWeekStartString,
            string expectedWeekEndString,
            byte expectedWeekNumber,
            ushort expectedYear)
        {
            // Arrange
            var culture = CultureInfo.GetCultureInfo("de-DE");
            var dateToCheck = DateTime.ParseExact(dateToCheckString, "dd.MM.yyyy", culture);
            var expectedWeekStart = DateTime.ParseExact(expectedWeekStartString, "dd.MM.yyyy", culture);
            var expectedWeekEnd = DateTime.ParseExact(expectedWeekEndString, "dd.MM.yyyy", culture);

            // Act
            var calendarweek = JanHafner.Timewindow.Calendarweek.Calendarweek.ByDateTime(dateToCheck, culture.Calendar);

            // Assert
            calendarweek.Start.Date.Should().Be(expectedWeekStart);
            calendarweek.End.Date.Should().Be(expectedWeekEnd);
            calendarweek.WeekNumber.Should().Be((JanHafner.Timewindow.Calendarweek.WeekNumber)expectedWeekNumber);
            calendarweek.Year.Should().Be((JanHafner.Timewindow.Year)expectedYear);
        }
    }
}
