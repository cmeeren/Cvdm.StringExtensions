namespace Cvdm.StringExtensions
{
    using System;

    using JetBrains.Annotations;

    /// <summary>Provides extension methods for <see cref="string" />.</summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Appends the specified suffix to the string if the string does not already end with the suffix as
        ///     determined using the specified comparison option.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="suffix">The suffix to compare and possibly append to the end of the source string.</param>
        /// <param name="comparisonType">
        ///     One of the enumeration values that determines how <paramref name="source" /> and
        ///     <paramref name="suffix" /> are compared.
        /// </param>
        /// <returns>
        ///     The source string with the suffix appended if the source string did not end with the suffix;
        ///     otherwise, the source string is returned unmodified.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source" /> or <paramref name="suffix" /> is <see langword="null" />.
        /// </exception>
        [Pure]
        public static string EnsureEndsWith(
            this string source,
            string suffix,
            StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (suffix == null) throw new ArgumentNullException(nameof(suffix));

            return source.EndsWith(suffix, comparisonType)
                ? source
                : source + suffix;
        }

        /// <summary>
        ///     Indicates whether the specified substring occurs within this string when compared using the
        ///     specified comparison option.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">The substring to search for in the source string.</param>
        /// <param name="comparison">
        ///     One of the enumeration values that determines how <paramref name="source" /> and
        ///     <paramref name="value" /> is compared.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the <paramref name="value" /> parameter occurs within this string, or if
        ///     <paramref name="value" /> is the empty string (""); otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> or <paramref name="source" /> is null.</exception>
        [Pure]
        public static bool Contains(this string source, string value, StringComparison comparison)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (value == null) throw new ArgumentNullException(nameof(value));

            return source.IndexOf(value, comparison) >= 0;
        }

        /// <summary>Converts empty strings to <see langword="null" />.</summary>
        /// <param name="source">The string to convert.</param>
        /// <returns><see langword="null" /> if the string is empty; otherwise, the input string is returned unmodified.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is null.</exception>
        [Pure]
        [CanBeNull]
        public static string NullIfEmpty(this string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return string.IsNullOrEmpty(source) ? null : source;
        }

        /// <summary>Converts whitespace-only strings to <see langword="null" />.</summary>
        /// <param name="source">The string to convert.</param>
        /// <returns>
        ///     <see langword="null" /> if the string is empty or contains only whitespace; otherwise, the input
        ///     string is returned unmodified.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is null.</exception>
        [Pure]
        [CanBeNull]
        public static string NullIfWhitespace(this string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return string.IsNullOrWhiteSpace(source) ? null : source;
        }
    }
}