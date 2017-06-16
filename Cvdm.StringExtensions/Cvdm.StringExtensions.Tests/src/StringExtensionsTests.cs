namespace Cvdm.StringExtensions.Tests
{
    using System;

    using Cvdm.StringExtensions;

    using FluentAssertions;

    using Xunit;

    public sealed class StringExtensionsTests
    {
        [Theory]
        [InlineData(StringComparison.Ordinal, "foo", "bar", "foobar")]
        [InlineData(StringComparison.Ordinal, "foobar", "bar", "foobar")]
        [InlineData(StringComparison.Ordinal, "foobar", "BAR", "foobarBAR")]
        [InlineData(StringComparison.Ordinal, "foo", "", "foo")]
        [InlineData(StringComparison.Ordinal, "", "foo", "foo")]
        [InlineData(StringComparison.Ordinal, "", "", "")]
        [InlineData(StringComparison.OrdinalIgnoreCase, "foobar", "BAR", "foobar")]
        public void EnsureEndsWith_ConvertsCorrectly(StringComparison comparison, string source, string suffix, string expected)
        {
            source.EnsureEndsWith(suffix, comparison).Should().Be(expected);
        }

        [Fact]
        public void EnsureEndsWith_DefaultComparisonIsCaseSensitive()
        {
            "foobar".EnsureEndsWith("BAR").Should().Be("foobarBAR");
        }

        [Fact]
        public void EnsureEndsWith_ThrowsIfSourceIsNull()
        {
            // Act
            Action act = () => StringExtensions.EnsureEndsWith(null, "foo");

            // Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void EnsureEndsWith_ThrowsIfSuffixIsNull()
        {
            // Act
            Action act = () => "foo".EnsureEndsWith(null);

            // Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(StringComparison.Ordinal, "foo", "foo", true)]
        [InlineData(StringComparison.Ordinal, "foo", "fo", true)]
        [InlineData(StringComparison.Ordinal, "foo", "oo", true)]
        [InlineData(StringComparison.Ordinal, "foo", "f", true)]
        [InlineData(StringComparison.Ordinal, "foo", "o", true)]
        [InlineData(StringComparison.Ordinal, "foo", "", true)]
        [InlineData(StringComparison.Ordinal, "foo", "bar", false)]
        [InlineData(StringComparison.Ordinal, "foo", "FOO", false)]
        [InlineData(StringComparison.OrdinalIgnoreCase, "foo", "FOO", true)]
        

        public void Contains_ReturnsCorrectValue(StringComparison comparison, string source, string value, bool expected)
        {
            source.Contains(value, comparison).Should().Be(expected);
        }

        [Fact]
        public void Contains_ThrowsIfSourceIsNull()
        {
            // Act
            Action act = () => StringExtensions.Contains(null, "foo", StringComparison.CurrentCulture);

            // Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Contains_ThrowsIfValueIsNull()
        {
            // Act
            Action act = () => "foo".Contains(null, StringComparison.CurrentCulture);

            // Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData("foo", "foo")]
        [InlineData(" ", " ")]
        [InlineData("", null)]
        public void NullIfEmpty_ReturnsNullOnlyIfEmpty(string source, string expected)
        {
            source.NullIfEmpty().Should().Be(expected);
        }

        [Fact]
        public void NullIfEmpty_ThrowsIfValueIsNull()
        {
            // Act
            Action act = () => StringExtensions.NullIfEmpty(null);

            // Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData("foo", "foo")]
        [InlineData("", null)]
        [InlineData(" ", null)]
        [InlineData(" \n\r\f\t\v", null)]
        public void NullIfWhitespace_ReturnsNullOnlyIfEmptyOrWhitespace(string source, string expected)
        {
            source.NullIfWhitespace().Should().Be(expected);
        }

        [Fact]
        public void NullIfWhitespace_ThrowsIfValueIsNull()
        {
            // Act
            Action act = () => StringExtensions.NullIfWhitespace(null);

            // Assert
            act.ShouldThrow<ArgumentNullException>();
        }
    }
}