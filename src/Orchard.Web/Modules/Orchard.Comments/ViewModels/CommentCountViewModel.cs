using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Comments.Models;

namespace Orchard.Comments.ViewModels {
    public class CommentCountViewModel {
        public CommentCountViewModel() {
        }
        public CommentCountViewModel(CommentsPart part) {
            Item = part.ContentItem;
            CommentCount = part.Comments.Count;
            PendingCount = part.PendingComments.Count;
        public ContentItem Item { get; set; }
        public int CommentCount { get; set; }
        public int PendingCount { get; set; }
    }
}
