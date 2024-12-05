using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Localization.Models {
    public class DateLocalizationOptions {
        public DateLocalizationOptions() {
            NullText = String.Empty;
            EnableTimeZoneConversion = true;
            EnableCalendarConversion = true;
            IgnoreDate = false;
        }
        /// <summary>
        /// Gets on sets the string to use in place of a null date when converting to and from a string. The default is an empty string.
        /// </summary>
        public string NullText { get; set; }
        /// Gets or sets a boolean indicating whether to perform time zone conversion as part of converting a date to and from a string. The default is true.
        public bool EnableTimeZoneConversion { get; set; }
        /// Gets or sets a boolean indicating whether to perform calendar conversion as part of converting a date to and from a string. The default is true.
        public bool EnableCalendarConversion { get; set; }
        /// Gets or sets a boolean indicating whether to ignore the date component of the source date and assume today when converting to a time string. The default is false.
        /// <remarks>
        /// This affects time zone conversion as the DST offset can be different on different days of the year.
        /// </remarks>
        public bool IgnoreDate { get; set; }
    }
}
