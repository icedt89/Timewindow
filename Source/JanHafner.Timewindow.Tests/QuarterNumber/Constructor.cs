using FluentAssertions;
using System;
using Xunit;

namespace JanHafner.Timewindow.Tests.QuarterNumber
{
    public sealed class Constructor
    {
        [Fact]
        public void ThrowsExceptionIfMinValueIsExceeded()
        {
            // Arrange
            var value = Timewindow.Quarter.QuarterNumber.MinValue - 1;

            try
            {
                // Act, Assert
                var quarterNumber = (Timewindow.Quarter.QuarterNumber)value;

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
            var value = Timewindow.Quarter.QuarterNumber.MinValue;

            // Act
            var quarterNumber = (Timewindow.Quarter.QuarterNumber)value;

            // Assert
            value.Should().Be((byte)quarterNumber);
        }

        [Fact]
        public void ThrowsExceptionIfMaxValueIsExceeded()
        {
            // Arrange
            var value = Timewindow.Quarter.QuarterNumber.MaxValue + 1;

            try
            {
                // Act, Assert
                var quarterNumber = (Timewindow.Quarter.QuarterNumber)value;

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
            var value = Timewindow.Quarter.QuarterNumber.MaxValue;

            // Act
            var quarterNumber = (Timewindow.Quarter.QuarterNumber)value;

            // Assert
            value.Should().Be((byte)quarterNumber);
        }

        [Fact]
        public void RunsCorrectly()
        {
            // Arrange
            var value = new Random().Next(Timewindow.Quarter.QuarterNumber.MinValue, Timewindow.Quarter.QuarterNumber.MaxValue + 1);

            // Act
            var quarterNumber = (Timewindow.Quarter.QuarterNumber)value;

            // Assert
            value.Should().Be((byte)quarterNumber);
        }
    }
}
