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
    {
        string[] ShortDateFormats { get; }
        string[] ShortTimeFormats { get; }
        string[] LongDateFormats { get; }
        string[] LongTimeFormats { get; }
    }

    public interface IDateFormatter
    {
        string FormatDateTime(DateTime dateTime, string format);
        string FormatTimeSpan(TimeSpan timeSpan);
    }

    public interface IDateLocalizationServices
    {
        string ConvertToLocalizedDateString(DateTime dateTime);
        string ConvertToLocalizedTimeString(DateTime dateTime);
        string ConvertToLocalizedString(DateTime dateTime);
    }

    public interface IWorkContextAccessor
    {
        WorkContext GetContext();
        IWorkContextScope CreateWorkContextScope();
    }

    public interface IWorkContextScope : IDisposable
    {
        WorkContext WorkContext { get; }
    }
}
