using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.FieldStorage;
using Orchard.Fields.Settings;

namespace Orchard.Fields.Fields {
    public class DateTimeField : ContentField {
        public DateTime? DateTime {
            get {
                var settings = PartFieldDefinition.Settings.GetModel<DateTimeFieldSettings>();
                var value = Storage.Get<DateTime?>();
                return value.HasValue && settings.Display == DateTimeFieldDisplays.DateOnly ?
                    new DateTime(value.Value.Year, value.Value.Month, value.Value.Day) : value;
            }
            set {
                if (value.HasValue) {
                    var settings = PartFieldDefinition.Settings.GetModel<DateTimeFieldSettings>();
                    Storage.Set(settings.Display == DateTimeFieldDisplays.DateOnly ?
                        new DateTime(value.Value.Year, value.Value.Month, value.Value.Day) : value.Value);
                }
                else {
                    Storage.Set<DateTime?>(null);
        }
        public DateTimeFieldDisplays Display {
                return PartFieldDefinition.Settings.GetModel<DateTimeFieldSettings>().Display;
    }
}
