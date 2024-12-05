using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Utilities;
using Orchard.Environment.Extensions;

namespace Orchard.Tags.Models {
    [OrchardFeature("Orchard.Tags.TagCloud")]
    public class TagCloudPart : ContentPart {
        internal readonly LazyField<IList<TagCount>> _tagCountField = new LazyField<IList<TagCount>>();
        public IList<TagCount> TagCounts { get { return _tagCountField.Value; } }
        public int Buckets { 
            get { return this.Retrieve(r => r.Buckets, 5); }
            set { this.Store(r => r.Buckets, value); }
        }
        public string Slug {
            get { return this.Retrieve(r => r.Slug); }
            set { this.Store(r => r.Slug, value); }
    }
}
