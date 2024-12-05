using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Comments.Models {
    public class CommentsPartRecord : ContentPartRecord {
        public CommentsPartRecord() {
            CommentPartRecords = new List<CommentPartRecord>();
        }
        public virtual bool CommentsShown { get; set; }
        public virtual bool CommentsActive { get; set; }
        public virtual bool ThreadedComments { get; set; }
        public virtual int CommentsCount { get; set; }
        [CascadeAllDeleteOrphan]
        public virtual IList<CommentPartRecord> CommentPartRecords { get; set; }
    }
}
