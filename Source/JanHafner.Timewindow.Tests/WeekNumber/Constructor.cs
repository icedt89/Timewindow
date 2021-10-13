using FluentAssertions;
using System;
using Xunit;

namespace JanHafner.Timewindow.Tests.WeekNumber
{
    public sealed class Constructor
    {
        [Fact]
        public void ThrowsExceptionIfMinValueIsExceeded()
        {
            // Arrange
            var value = JanHafner.Timewindow.Calendarweek.WeekNumber.MinValue - 1;

            try
            {
                // Act, Assert
                var weekNumber = (JanHafner.Timewindow.Calendarweek.WeekNumber)value;

                throw new InvalidOperationException("Test should throw but doesnt");
            }
            catch (ArgumentException)
            {
            }
        }

        [Fact]
        public void RunsCorrectlyIfMinValueIsReached()
        {
            // Arrange
            var value = JanHafner.Timewindow.Calendarweek.WeekNumber.MinValue;

            // Act
            var weekNumber = (JanHafner.Timewindow.Calendarweek.WeekNumber)value;

            // Assert
            value.Should().Be((byte)weekNumber);
        }

        [Fact]
        public void ThrowsExceptionIfMaxValueIsExceeded()
        {
            // Arrange
            var value = JanHafner.Timewindow.Calendarweek.WeekNumber.MaxValue + 1;

            try
            {
                // Act, Assert
                var weekNumber = (JanHafner.Timewindow.Calendarweek.WeekNumber)value;

                throw new InvalidOperationException("Test should throw but doesnt");
            }
            catch (ArgumentException)
            {
            }
        }

        [Fact]
        public void RunsCorrectlyIfMaxValueIsReached()
        {
            // Arrange
            var value = JanHafner.Timewindow.Calendarweek.WeekNumber.MaxValue;

            // Act
            var weekNumber = (JanHafner.Timewindow.Calendarweek.WeekNumber)value;

            // Assert
            value.Should().Be((byte)weekNumber);
        }

        [Fact]
        public void RunsCorrectly()
        {
            // Arrange
            var value = new Random().Next(JanHafner.Timewindow.Calendarweek.WeekNumber.MinValue, JanHafner.Timewindow.Calendarweek.WeekNumber.MaxValue + 1);

            // Act
            var weekNumber = (JanHafner.Timewindow.Calendarweek.WeekNumber)value;

            // Assert
            value.Should().Be((byte)weekNumber);
        }
    }
}
