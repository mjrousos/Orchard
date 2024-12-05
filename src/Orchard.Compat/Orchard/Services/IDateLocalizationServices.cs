using System;

namespace Orchard.Services {
    public interface IDateLocalizationServices {
        DateTime ConvertToSiteTimeZone(DateTime dateUtc);
        DateTime ConvertFromSiteTimeZone(DateTime dateLocal);
        TimeZoneInfo GetSiteTimeZone();
    }
}
