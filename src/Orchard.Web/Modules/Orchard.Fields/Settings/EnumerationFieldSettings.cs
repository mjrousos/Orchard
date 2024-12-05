using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Fields.Settings {

    public enum ListMode {
        Dropdown,
        Radiobutton,
        Listbox,
        Checkbox
    }
    public class EnumerationFieldSettings {
        public string Hint { get; set; }
        public bool Required { get; set; }
        public string Options { get; set; }
        public ListMode ListMode { get; set; }
        public string DefaultValue { get; set; }
        public EnumerationFieldSettings() {
            ListMode = ListMode.Dropdown;
        }
}
