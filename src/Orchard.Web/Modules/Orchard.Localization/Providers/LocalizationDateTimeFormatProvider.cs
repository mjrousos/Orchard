using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.Environment.Extensions;
using Orchard.Localization.Services;
using Orchard.Utility.Extensions;

namespace Orchard.Localization.Providers {
    /// <summary>
    /// Provides an implementation of IDateTimeFormatProvider which uses Localizer to obtain
    /// property values. The strings used to resolve values through Localizer can be changed
    /// for other cultures using the normal string localization process. This is useful for
    /// adding additional or different translations than those provided by CultureInfo.
    /// </summary>
    [OrchardFeature("Orchard.Localization.DateTimeFormat")]
    [OrchardSuppressDependency("Orchard.Localization.Services.CultureDateTimeFormatProvider")]
    public class LocalizationDateTimeFormatProvider : IDateTimeFormatProvider {
        // Even though space is a possible character to be found in a month or day name in some cultures/languages,
        // those are not widely used and quite improbable to have Orchard translations.
        private static readonly char[] _valueSeparators = new char[] { ',', ' ' };
        public LocalizationDateTimeFormatProvider() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public string[] MonthNames =>
            T("January, February, March, April, May, June, July, August, September, October, November, December").Text.StrictlySplit(_valueSeparators);
        public virtual string[] MonthNamesGenitive => MonthNames;
        public string[] MonthNamesShort =>
            T("Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec").Text.StrictlySplit(_valueSeparators);
        public virtual string[] MonthNamesShortGenitive => MonthNamesShort;
        public string[] DayNames =>
            T("Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday").Text.StrictlySplit(_valueSeparators);
        public string[] DayNamesShort =>
            T("Sun, Mon, Tue, Wed, Thu, Fri, Sat").Text.StrictlySplit(_valueSeparators);
        public string[] DayNamesMin =>
            T("Su, Mo, Tu, We, Th, Fr, Sa").Text.StrictlySplit(_valueSeparators);
        public string ShortDateFormat {
            get {
                return T("M/d/yyyy").Text;
            }
        public string ShortTimeFormat {
                return T("h:mm tt").Text;
        public string ShortDateTimeFormat {
                return T("M/d/yyyy h:mm tt").Text;
        public string LongDateFormat {
                return T("dddd, MMMM d, yyyy").Text;
        public string LongTimeFormat {
                return T("h:mm:ss tt").Text;
        public string LongDateTimeFormat {
                return T("dddd, MMMM d, yyyy h:mm:ss tt").Text;
        public IEnumerable<string> AllDateFormats {
                return new[] { ShortDateFormat, LongDateFormat };
        public IEnumerable<string> AllTimeFormats {
                return new[] { ShortTimeFormat, LongTimeFormat };
        public IEnumerable<string> AllDateTimeFormats {
                return new[] { ShortDateTimeFormat, LongDateTimeFormat };
        public int FirstDay {
                var firstDay = 1;
                var t = T("firstDay: 1").Text;
                var parts = t.Split(':');
                if (parts.Length == 2) {
                    Int32.TryParse(parts[1], out firstDay);
                }
                return firstDay;
        public bool Use24HourTime {
                var use24HourTime = false;
                var t = T("use24HourTime: false").Text;
                    Boolean.TryParse(parts[1], out use24HourTime);
                return use24HourTime;
        public string DateSeparator {
                return "/"; // Since we can't do it with TimeSeparator why do it with this one...
        public string TimeSeparator {
                return ":"; // No good way to put a colon through a colon-separated translation process...
        public string AmPmPrefix {
                return " "; // No good way to put a single space through a string-based translation process...
        public string[] AmPmDesignators {
                var t = T("AM;PM").Text;
                var parts = t.Split(';');
                    return parts;
                return new string[] { "AM", "PM" };
        public string GetEraName(int era) {
            var t = T("A.D.;A.D.").Text;
            var parts = t.Split(';');
            if (parts.Length >= era + 1) {
                return parts[era];
            return null;
        public string GetShortEraName(int era) {
            var t = T("AD;AD").Text;
        public int GetEra(string eraName) {
            var parts = t.ToLowerInvariant().Split(';');
            if (parts.Contains(eraName.ToLowerInvariant())) {
                return parts.ToList().IndexOf(eraName.ToLowerInvariant());
            throw new ArgumentOutOfRangeException("eraName");
    }
}
