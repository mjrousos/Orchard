using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Comments.Services {
    public class CreateCommentContext {
        public virtual string Author { get; set; }
        public virtual string SiteName { get; set; }
        public virtual string Email { get; set; }
        public virtual string CommentText { get; set; }
        public virtual int CommentedOn { get; set; }
    }
}
