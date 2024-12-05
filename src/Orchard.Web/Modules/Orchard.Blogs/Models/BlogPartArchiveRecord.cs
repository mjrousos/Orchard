using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.ContentManagement.Records;

namespace Orchard.Blogs.Models {
    public class BlogPartArchiveRecord {
        public virtual int Id { get; set; }
        public virtual ContentItemRecord BlogPart { get; set; }
        public virtual int Year { get; set; }
        public virtual int Month { get; set; }
        public virtual int PostCount { get; set; }
    }
}
