﻿#region Using directives
using System;
using System.Globalization;
#endregion

namespace Blazorise.Utilities
{
    /// <summary>
    /// Various methods for parsing dates and times.
    /// </summary>
    public static class Parsers
    {
        /// <summary>
        /// Internal date format. Compatible with HTML date inputs.
        /// </summary>
        public const string InternalDateFormat = "yyyy-MM-dd";

        /// <summary>
        /// Internal date-time format. Compatible with HTML date inputs.
        /// </summary>
        public const string InternalDateTimeFormat = "yyyy-MM-ddTHH:mm";

        /// <summary>
        /// Default date format.
        /// </summary>
        public const string ExternalDateFormat = "dd.MM.yyyy";

        /// <summary>
        /// Default date format.
        /// </summary>
        public const string ExternalDateTimeFormat = "dd.MM.yyyy HH:mm";

        /// <summary>
        /// Internal time format. Compatible with HTML time inputs.
        /// </summary>
        public const string InternalTimeFormat = "hh\\:mm\\:ss";

        /// <summary>
        /// Possible date formats.
        /// </summary>
        public static readonly string[] SupportedDateFormats = new string[]
        {
            InternalDateFormat,
            ExternalDateFormat,
            "yyyy-MM-ddTHH:mm",
            CultureInfo.InvariantCulture.DateTimeFormat.LongDatePattern,
            CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern,
            "o", // a string representing UTC
        };

        /// <summary>
        /// Possible date-time formats.
        /// </summary>
        public static readonly string[] SupportedDateTimeFormats = new string[]
        {
            InternalDateTimeFormat,
            ExternalDateTimeFormat,
            "yyyy-MM-ddTHH:mm",
            CultureInfo.InvariantCulture.DateTimeFormat.LongDatePattern,
            CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern,
            "o", // a string representing UTC
        };

        /// <summary>
        /// Possible time formats.
        /// </summary>
        public static readonly string[] SupportedTimeFormats = new string[]
        {
            InternalTimeFormat,
            "hh\\:mm",
            CultureInfo.InvariantCulture.DateTimeFormat.LongTimePattern,
            CultureInfo.InvariantCulture.DateTimeFormat.ShortTimePattern,
        };

        /// <summary>
        /// Tries to parse a date from a given string value.
        /// </summary>
        /// <typeparam name="TValue">The type of object to return.</typeparam>
        /// <param name="value">String to parse.</param>
        /// <param name="inputMode">Hint for parsing method.</param>
        /// <param name="result">An object whose value represents the parsed string.</param>
        /// <returns>True if parsing was successful.</returns>
        public static bool TryParseDate<TValue>( string value, DateInputMode inputMode, out TValue result )
        {
            if ( string.IsNullOrWhiteSpace( value ) )
            {
                result = default;
                return false;
            }

            var supportedFormats = inputMode == DateInputMode.DateTime
                ? SupportedDateTimeFormats
                : SupportedDateFormats;

            var type = Nullable.GetUnderlyingType( typeof( TValue ) ) ?? typeof( TValue );

            if ( type == typeof( DateTime ) && DateTime.TryParseExact( value, supportedFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt ) )
            {
                result = (TValue)(object)dt;
                return true;
            }

            if ( type == typeof( DateTime ) && DateTimeOffset.TryParse( value, out var dto ) )
            {
                result = (TValue)(object)dto.DateTime;
                return true;
            }

            if ( type == typeof( DateTimeOffset ) && DateTimeOffset.TryParse( value, out var dto2 ) )
            {
                result = (TValue)(object)dto2;
                return true;
            }

            result = default;

            return false;
        }

        /// <summary>
        /// Tries to parse a time from a given string value.
        /// </summary>
        /// <typeparam name="TValue">The type of object to return.</typeparam>
        /// <param name="value">String to parse.</param>
        /// <param name="result">An object whose value represents the parsed string.</param>
        /// <returns>True if parsing was successful.</returns>
        public static bool TryParseTime<TValue>( string value, out TValue result )
        {
            if ( string.IsNullOrWhiteSpace( value ) )
            {
                result = default;
                return false;
            }

            var type = Nullable.GetUnderlyingType( typeof( TValue ) ) ?? typeof( TValue );

            if ( type == typeof( TimeSpan ) && TimeSpan.TryParseExact( value, SupportedTimeFormats, CultureInfo.InvariantCulture, TimeSpanStyles.None, out var time ) )
            {
                result = (TValue)(object)time;
                return true;
            }

            if ( type == typeof( DateTime ) && DateTime.TryParseExact( value, SupportedTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt ) )
            {
                result = (TValue)(object)dt;
                return true;
            }

            result = default;

            return false;
        }
    }
}
