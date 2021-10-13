using FluentAssertions;
using System;
using Xunit;

namespace JanHafner.Timewindow.Tests.MonthNumber
{
    public sealed class Constructor
    {
        [Fact]
        public void ThrowsExceptionIfMinValueIsExceeded()
        {
            // Arrange
            var value = Timewindow.Month.MonthNumber.MinValue - 1;

            try
            {
                // Act, Assert
                var month = (Timewindow.Month.MonthNumber)value;

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
            var value = Timewindow.Month.MonthNumber.MinValue;

            // Act
            var month = (Timewindow.Month.MonthNumber)value;

            // Assert
            value.Should().Be((byte)month);
        }

        [Fact]
        public void ThrowsExceptionIfMaxValueIsExceeded()
        {
            // Arrange
            var value = Timewindow.Month.MonthNumber.MaxValue + 1;

            try
            {
                // Act, Assert
                var month = (Timewindow.Month.MonthNumber)value;

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
            var value = Timewindow.Month.MonthNumber.MaxValue;

            // Act
            var month = (Timewindow.Month.MonthNumber)value;

            // Assert
            value.Should().Be((byte)month);
        }

        [Fact]
        public void RunsCorrectly()
        {
            // Arrange
            var value = new Random().Next(Timewindow.Month.MonthNumber.MinValue, Timewindow.Month.MonthNumber.MaxValue + 1);

            // Act
            var month = (Timewindow.Month.MonthNumber)value;

            // Assert
            value.Should().Be((byte)month);
        }
    }
}
