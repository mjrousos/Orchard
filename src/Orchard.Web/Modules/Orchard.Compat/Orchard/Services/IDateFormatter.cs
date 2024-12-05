using System;

namespace Orchard.Services {
    public interface IDateFormatter {
        string FormatDateTime(DateTime? dateTime, string format);
        string FormatTimeSpan(TimeSpan? timeSpan);
    }
}
