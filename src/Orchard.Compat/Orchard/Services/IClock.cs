using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Services
{
    public interface IClock
    {
        DateTime UtcNow { get; }
        DateTime Now { get; }
        TimeZoneInfo CurrentTimeZone { get; }
        DateTime ConvertToLocal(DateTime utc);
        DateTime ConvertToUtc(DateTime local);
    }
    public interface IDateTimeFormatProvider
        string[] ShortDateFormats { get; }
        string[] ShortTimeFormats { get; }
        string[] LongDateFormats { get; }
        string[] LongTimeFormats { get; }
    public interface IDateFormatter
        string FormatDateTime(DateTime dateTime, string format);
        string FormatTimeSpan(TimeSpan timeSpan);
    public interface IDateLocalizationServices
        string ConvertToLocalizedDateString(DateTime dateTime);
        string ConvertToLocalizedTimeString(DateTime dateTime);
        string ConvertToLocalizedString(DateTime dateTime);
    public interface IWorkContextAccessor
        WorkContext GetContext();
        IWorkContextScope CreateWorkContextScope();
    public interface IWorkContextScope : IDisposable
        WorkContext WorkContext { get; }
}
namespace Orchard.Localization
    public class LocalizedString
        private readonly string _text;
        private readonly string _textHint;
        public LocalizedString(string text)
        {
            _text = text;
            _textHint = text;
        }
        public LocalizedString(string text, string textHint)
            _textHint = textHint;
        public string Text => _text;
        public string TextHint => _textHint;
        public static implicit operator string(LocalizedString str)
            return str?._text;
        public static implicit operator LocalizedString(string str)
            return new LocalizedString(str);
        public override string ToString()
            return _text;
    public delegate LocalizedString Localizer(string text, params object[] args);
