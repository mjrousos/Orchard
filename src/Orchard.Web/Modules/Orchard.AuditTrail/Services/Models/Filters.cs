using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Orchard.AuditTrail.Services.Models {
    public class Filters : Dictionary<string, string> {
        public Filters(IUpdateModel updateModel) {
            UpdateModel = updateModel;
        }
        public IUpdateModel UpdateModel { get; set; }
        public static Filters From(NameValueCollection nameValues, IUpdateModel updateModel) {
            var filters = new Filters(updateModel);
            foreach (string nameValue in nameValues) {
                if (!String.IsNullOrEmpty(nameValue)) {
                    filters.Add(nameValue, nameValues[nameValue]);
                }
            }
            return filters;
        public Filters AddFilter(string key, string value) {
            Add(key, value);
            return this;
    }
}
