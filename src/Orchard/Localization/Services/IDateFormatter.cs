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
using System.Globalization;
using System.Linq;
using Orchard.Localization.Models;

namespace Orchard.Localization.Services {
    public interface IDateFormatter : IDependency {
        /// <summary>
        /// Parses a date/time string into a <c>DateTimeParts</c> instance.
        /// </summary>
        /// <param name="dateTimeString">The date/time string to parse.</param>
        /// <returns></returns>
        DateTimeParts ParseDateTime(string dateTimeString);
        /// Parses a date/time string into a <c>DateTimeParts</c> instance using the specified format.
        /// <param name="format">A custom DateTime format string with which to parse the string.</param>
        DateTimeParts ParseDateTime(string dateTimeString, string format);
        /// Parses a date string into a <c>DateParts</c> instance.
        /// <param name="dateString">The date string to parse.</param>
        DateParts ParseDate(string dateString);
        /// Parses a date string into a <c>DateParts</c> instance using the specified format.
        DateParts ParseDate(string dateString, string format);
        /// Parses a time string into a <c>TimeParts</c> instance.
        /// <param name="timeString">The time string to parse.</param>
        TimeParts ParseTime(string timeString);
        /// Parses a time string into a <c>TimeParts</c> instance using the specified format.
        /// <param name="timeString">The date string to parse.</param>
        TimeParts ParseTime(string timeString, string format);
        /// Formats a <c>DateTimeParts</c> instance into a short date/time string.
        /// <param name="parts">The <c>DateTimeParts</c> instance to format.</param>
        string FormatDateTime(DateTimeParts parts);
        /// Formats a <c>DateTimeParts</c> instance into a string.
        /// <param name="format">A custom DateTime format string with which to format the string.</param>
        string FormatDateTime(DateTimeParts parts, string format);
        /// Formats a <c>DateParts</c> instance into a short date string.
        /// <param name="parts">The <c>DateParts</c> instance to format.</param>
        string FormatDate(DateParts parts);
        /// Formats a <c>DateParts</c> instance into a string.
        string FormatDate(DateParts parts, string format);
        /// Formats a <c>TimeParts</c> instance into a long time string.
        string FormatTime(TimeParts parts);
        /// Formats a <c>TimeParts</c> instance into a string.
        /// <param name="parts">The <c>TimeParts</c> instance to format.</param>
        string FormatTime(TimeParts parts, string format);
    }
}
