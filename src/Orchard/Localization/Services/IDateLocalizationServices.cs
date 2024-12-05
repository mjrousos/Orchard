using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Localization.Models;

namespace Orchard.Localization.Services {
    /// <summary>
    /// Provides conversion and formatting of dates according to the Orchard configured
    /// time zone, culture and calendar (as opposed to the system configured time zone and
    /// culture).
    /// </summary>
    public interface IDateLocalizationServices : IDependency {
        /// <summary>
        /// Converts a date from UTC to the Orchard configured time zone.
        /// </summary>
        /// <param name="dateUtc">The UTC date to convert.</param>
        /// <returns></returns>
        DateTime ConvertToSiteTimeZone(DateTime dateUtc);
        /// Converts a date from the Orchard configured time zone to UTC.
        /// <param name="dateLocal">The local date to convert.</param>
        DateTime ConvertFromSiteTimeZone(DateTime dateLocal);
        /// Converts a date from Gregorian calendar to the Orchard configured calendar.
        /// <param name="date">The Gregorian calendar date to convert.</param>
        /// <param name="offset">A TimeSpan representing the offset from UTC of the supplied date parameter.</param>
        /// <returns>A <c>DateTimeParts</c> instance representing the converted date.</returns>
        DateTimeParts ConvertToSiteCalendar(DateTime date, TimeSpan offset);
        /// Converts a date from the Orchard configured calendar to Gregorian calendar.
        /// <param name="parts">A <c>DateTimeParts</c> instance representing the Orchard configured calendar date to convert.</param>
        /// <returns>A <c>DateTime</c> instance representing the converted date.</returns>
        DateTime ConvertFromSiteCalendar(DateTimeParts parts);
        /// Converts a non-nullable UTC date in Gregorian calendar to a localized short date string.
        /// <param name="date">The non-nullable UTC date to convert. DateTime.MinValue is translated to null.</param>
        /// <param name="options">An optional <c>DateLocalizationOptions</c> instance used to control various aspects of the conversion process.</param>
        string ConvertToLocalizedDateString(DateTime date, DateLocalizationOptions options = null);
        /// Converts a nullable UTC date in Gregorian calendar to a localized short date string.
        /// <param name="date">The nullable UTC date to convert.</param>
        string ConvertToLocalizedDateString(DateTime? date, DateLocalizationOptions options = null);
        /// Converts a non-nullable UTC date in Gregorian calendar to a localized long time string.
        string ConvertToLocalizedTimeString(DateTime date, DateLocalizationOptions options = null);
        /// Converts a nullable UTC date in Gregorian calendar to a localized long time string.
        string ConvertToLocalizedTimeString(DateTime? date, DateLocalizationOptions options = null);
        /// Converts a non-nullable UTC date in Gregorian calendar to a localized short date/time string.
        string ConvertToLocalizedString(DateTime date, DateLocalizationOptions options = null);
        /// Converts a nullable UTC date in Gregorian calendar to a localized short date/time string.
        string ConvertToLocalizedString(DateTime? date, DateLocalizationOptions options = null);
        /// Converts a non-nullable UTC date in Gregorian calendar to a localized string with the specified format.
        /// <param name="format">A standard or custom DateTime format string to use when formatting the date.</param>
        string ConvertToLocalizedString(DateTime date, string format, DateLocalizationOptions options = null);
        /// Converts a nullable UTC date in Gregorian calendar to a localized string with the specified format.
        string ConvertToLocalizedString(DateTime? date, string format, DateLocalizationOptions options = null);
        /// Converts a localized date string to a UTC date in Gregorian calendar.
        /// <param name="dateString">The localized date string to convert.</param>
        /// <returns>A <c>DateTime</c> instance where the time component equals that of DateTime.MinValue.</returns>
        /// <remarks>
        /// If the dateString parameter is null or equal to DateLocalizationOptions.NullText property, this method returns null.
        /// </remarks>
        DateTime? ConvertFromLocalizedDateString(string dateString, DateLocalizationOptions options = null);
        /// Converts a localized time string to a UTC date in Gregorian calendar.
        /// <param name="timeString">The localized time string to convert.</param>
        /// <returns>A <c>DateTime</c> instance where the date component equals that of DateTime.MinValue.</returns>
        /// If the timeString parameter is null or equal to DateLocalizationOptions.NullText property, this method returns null.
        DateTime? ConvertFromLocalizedTimeString(string timeString, DateLocalizationOptions options = null);
        /// Converts separate localized date and time strings to a single UTC date in Gregorian calendar.
        /// <param name="dateString">The localized date/time string to convert.</param>
        /// If the dateString parameter is null or equal to DateLocalizationOptions.NullText property, the returned <c>DateTime</c> instance will have a date component that equals that of DateTime.MinValue.
        /// If the timeString parameter is null or equal to DateLocalizationOptions.NullText property, the returned <c>DateTime</c> instance will have a time component that equals that of DateTime.MinValue.
        /// If both dateString and timeString parameters are null or equal to DateLocalizationOptions.NullText property, this method returns null.
        DateTime? ConvertFromLocalizedString(string dateString, string timeString, DateLocalizationOptions options = null);
        /// Converts a localized date/time string to a UTC date in Gregorian calendar.
        /// <param name="dateTimeString">The localized date/time string to convert.</param>
        /// If the dateTimeString parameter is null or equal to DateLocalizationOptions.NullText property, this method returns null.
        DateTime? ConvertFromLocalizedString(string dateTimeString, DateLocalizationOptions options = null);
    }
}
