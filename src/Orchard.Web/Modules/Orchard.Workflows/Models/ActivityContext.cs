using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Workflows.Services;

namespace Orchard.Workflows.Models {
    public class ActivityContext {
        
        public IActivity Activity { get; set; }
        public ActivityRecord Record { get; set; }
        public Lazy<dynamic> State { private get; set; }
        public T GetState<T>(string key) {
            if (State == null || State.Value == null) {
                return default(T);
            }
            dynamic value = State.Value[key];
            if (value == null) {
            return value;
        }
    }
}
