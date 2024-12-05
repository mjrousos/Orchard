using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Orchard.Tags.Models {
    public class TagsPart : ContentPart<TagsPartRecord> {
        public IEnumerable<string> CurrentTags {
            get { return ParseTags(Retrieve<string>("CurrentTags")); }
            set { Store("CurrentTags", String.Join(",", value)); }
        }
        private IEnumerable<string> ParseTags(string tags) {
            return (tags ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    }
}
