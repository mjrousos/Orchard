using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿
namespace Orchard.Tags.Models {
    public class TagCount {
        public TagCount() {
            Bucket = 1;
        }

        public string TagName { get; set; }
        public int Count { get; set; }
        public int Bucket { get; set; }
    }
}
