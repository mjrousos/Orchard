using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Core.Common.ViewModels;

namespace Orchard.Fields.ViewModels {
    public class DateTimeFieldViewModel {
        public string Name { get; set; }
        public string Hint { get; set; }
        public DateTime? Value { get; set; }
        public bool IsRequired { get; set; }
        public DateTimeEditor Editor { get; set; }
    }
}
