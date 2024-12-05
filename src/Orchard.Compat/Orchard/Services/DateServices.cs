using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Globalization;

namespace Orchard.Services
{
    public interface IDateTimeFormatProvider
    {
        string[] ShortDateFormats { get; }
        string[] ShortTimeFormats { get; }
        string[] LongDateFormats { get; }
        string[] LongTimeFormats { get; }
        string[] DateTimeFormats { get; }
    }
    public interface IDateFormatter
        string Format(DateTime date, string format);
        string Format(DateTime date, string format, CultureInfo culture);
        string FormatDateTime(DateTime date);
        string FormatSortableDateTimeFilter(DateTime date);
        string FormatTimeSpan(TimeSpan timeSpan);
    public interface IDateLocalizationServices
        DateTime ConvertToSiteTimeZone(DateTime dateUtc);
        DateTime ConvertFromSiteTimeZone(DateTime dateLocal);
        TimeZoneInfo GetSiteTimeZone();
    public class LocalizedString
        private readonly string _text;
        public LocalizedString(string text)
        {
            _text = text;
        }
        public static implicit operator string(LocalizedString s)
            return s?._text;
        public static implicit operator LocalizedString(string s)
            return new LocalizedString(s);
        public override string ToString()
            return _text;
    public class Localizer
        public LocalizedString this[string text]
            get { return new LocalizedString(text); }
        public LocalizedString this[string text, params object[] args]
            get { return new LocalizedString(string.Format(text, args)); }
}
