using FluentAssertions;
using System;
using Xunit;

namespace JanHafner.Timewindow.Tests.Day
{
    public sealed class Constructor
    {
        [Fact]
        public void ThrowsExceptionIfMinValueIsExceeded()
        {
            // Arrange
            var value = JanHafner.Timewindow.Day.MinValue - 1;

            try
            {
                // Act, Assert
                var day = (JanHafner.Timewindow.Day)value;

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
            var value = JanHafner.Timewindow.Day.MinValue;

            // Act
            var day = (JanHafner.Timewindow.Day)value;

            // Assert
            value.Should().Be((byte)day);
        }

        [Fact]
        public void ThrowsExceptionIfMaxValueIsExceeded()
        {
            // Arrange
            var value = JanHafner.Timewindow.Day.MaxValue + 1;

            try
            {
                // Act, Assert
                var day = (JanHafner.Timewindow.Day)value;

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
            var value = JanHafner.Timewindow.Day.MaxValue;

            // Act
            var day = (JanHafner.Timewindow.Day)value;

            // Assert
            value.Should().Be((byte)day);
        }

        [Fact]
        public void RunsCorrectly()
        {
            // Arrange
            var value = new Random().Next(JanHafner.Timewindow.Day.MinValue, JanHafner.Timewindow.Day.MaxValue + 1);

            // Act
            var day = (JanHafner.Timewindow.Day)value;

            // Assert
            value.Should().Be((byte)day);
        }
    }
}
