using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Fields.Fields;
using Orchard.Fields.Settings;
namespace Orchard.Fields.ViewModels {

    public class NumericFieldViewModel {
        public NumericField Field { get; set; }
        public NumericFieldSettings Settings { get; set; }
        public string Value { get; set; }
    }
}
