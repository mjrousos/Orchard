using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentManagement.MetaData.Models {
    public class ContentTypePartDefinition {
    
        public ContentTypePartDefinition(ContentPartDefinition contentPartDefinition, SettingsDictionary settings) {
            PartDefinition = contentPartDefinition;
            Settings = settings;
        }

        public ContentTypePartDefinition() {
            Settings = new SettingsDictionary();
        public ContentPartDefinition PartDefinition { get; private set; }
        public SettingsDictionary Settings { get; private set; }
        public ContentTypeDefinition ContentTypeDefinition { get; set; }
    }
}
