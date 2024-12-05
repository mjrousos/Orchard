using System;

namespace Orchard.Services {
    public interface IDateTimeFormatProvider {
        string[] ShortDateFormats { get; }
        string[] ShortTimeFormats { get; }
        string[] LongDateFormats { get; }
        string[] LongTimeFormats { get; }
        string[] MonthNames { get; }
        string[] MonthNamesShort { get; }
        string[] DayNames { get; }
        string[] DayNamesShort { get; }
        string ShortDateFormat { get; }
        string ShortTimeFormat { get; }
        string LongDateFormat { get; }
        string LongTimeFormat { get; }
        string DateTimeFormat { get; }
    }
}
