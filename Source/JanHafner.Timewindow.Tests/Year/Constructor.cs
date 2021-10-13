using FluentAssertions;
using System;
using Xunit;

namespace JanHafner.Timewindow.Tests.Year
{
    public sealed class Constructor
    {
        [Fact]
        public void ThrowsExceptionIfMinValueIsExceeded()
        {
            // Arrange
            var value = Timewindow.Year.MinValue - 1;

            try
            {
                // Act, Assert
                var year = (Timewindow.Year)value;

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
            var value = Timewindow.Year.MinValue;

            // Act
            var year = (Timewindow.Year)value;

            // Assert
            value.Should().Be((ushort)year);
        }

        [Fact]
        public void ThrowsExceptionIfMaxValueIsExceeded()
        {
            // Arrange
            var value = Timewindow.Year.MaxValue + 1;

            try
            {
                // Act, Assert
                var year = (Timewindow.Year)value;

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
            var value = Timewindow.Year.MaxValue;

            // Act
            var year = (Timewindow.Year)value;

            // Assert
            value.Should().Be((ushort)year);
        }

        [Fact]
        public void RunsCorrectly()
        {
            // Arrange
            var value = new Random().Next(Timewindow.Year.MinValue, Timewindow.Year.MaxValue + 1);

            // Act
            var year = (Timewindow.Year)value;

            // Assert
            value.Should().Be((ushort)year);
        }
    }
}
