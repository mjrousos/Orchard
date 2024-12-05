using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Layouts.Settings;

namespace Orchard.Layouts.Models {
    public class LayoutPart : ContentPart<LayoutPartRecord>, ILayoutAspect {
        public string SessionKey {
            get {
                var key = this.Retrieve(x => x.SessionKey);
                if (String.IsNullOrEmpty(key)) {
                    SessionKey = key = Guid.NewGuid().ToString();
                }
                return key;
            }
            set { this.Store(x => x.SessionKey, value); }
        }
        public string LayoutData {
            get { return RetrieveVersioned<string>("LayoutData") ?? RetrieveVersioned<string>("LayoutState"); } // Temporary code to allow existing sites to still function.
            set { this.Store(x => x.LayoutData, value, versioned: true); }
        public bool IsTemplate {
            get { return TypePartDefinition.Settings.GetModel<LayoutTypePartSettings>().IsTemplate; }
        public int? TemplateId {
            get { return Retrieve(x => x.TemplateId); }
            set { Store(x => x.TemplateId, value); }
    }
}
