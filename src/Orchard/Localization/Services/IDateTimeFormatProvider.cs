using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Orchard.Localization.Services {
    /// <summary>
    /// Provides a set of properties which control the formatting of dates and times in Orchard.
    /// </summary>
    public interface IDateTimeFormatProvider : IDependency {
        /// <summary>
        /// Gets a list of month names.
        /// </summary>
        string[] MonthNames {
            get;
        }
        /// Gets a list of genitive month names (used in contexts when a day is involved).
        string[] MonthNamesGenitive {
        /// Gets a list of abbreviated month names.
        string[] MonthNamesShort {
        /// Gets a list of abbreviated genivite month names (used in contexts when a day is involved).
        string[] MonthNamesShortGenitive {
        /// Gets a list of weekday names.
        string[] DayNames {
        /// Gets a list of abbreviated weekday names.
        string[] DayNamesShort {
        /// Gets a list of maximally abbreviated weekday names.
        string[] DayNamesMin {
        /// Gets a custom DateTime format string used to format dates for short date display.
        string ShortDateFormat {
        /// Gets a custom DateTime format string used to format dates for short time display.
        string ShortTimeFormat {
        /// Gets a custom DateTime format string used to format dates for general (short) date and time display.
        string ShortDateTimeFormat {
        /// Gets a custom DateTime format string used to format dates for long date display.
        string LongDateFormat {
        /// Gets a custom DateTime format string used to format dates for long time display.
        string LongTimeFormat {
        /// Gets a custom DateTime format string used to format dates for full date and time display.
        string LongDateTimeFormat {
        /// Gets the full list of custom DateTime format strings supported to format dates for date display.
        IEnumerable<string> AllDateFormats {
        /// Gets the full list of custom DateTime format strings supported to format dates for time display.
        IEnumerable<string> AllTimeFormats {
        /// Gets the full list of custom DateTime format strings supported to format dates for date and time display.
        IEnumerable<string> AllDateTimeFormats {
        /// Gets an integer representing the first day of the week, where 0 is Sunday, 1 is Monday etc.
        int FirstDay {
        /// Gets a boolean indicating whether 24-hour time is used as opposed to 12-hour time.
        bool Use24HourTime {
        /// Gets the string that separates the components of date, that is, the year, month and day.
        string DateSeparator {
        /// Gets the string that separates the components of time, that is, the hour, minute, and second.
        string TimeSeparator {
        /// Gets the string that separates the time from the AM and PM designators.
        string AmPmPrefix {
        /// Gets a list of strings used as display text for the AM and PM designators.
        string[] AmPmDesignators {
        /// Returns a string containing the name of the specified era.
        string GetEraName(int era);
        /// Returns a string containing the abbreviated name of the specified era, if an abbreviation exists.
        string GetShortEraName(int era);
        /// Returns the integer representing the specified era.
        int GetEra(string eraName);
    }
}
