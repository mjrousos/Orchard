using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.Models.Assets {
    public class DisplayLocator {
        public DisplayLocator(string name, string id, string url) {
            Name = name;
            Id = id;
            Url = url;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }
        public string Url { get; private set; }
    }
}
