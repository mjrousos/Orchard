using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web.Mvc.Html;

namespace Orchard.Mvc.Html {
    public class MvcFormAntiForgeryPost : MvcForm {
        private readonly HtmlHelper _htmlHelper;
        public MvcFormAntiForgeryPost(HtmlHelper htmlHelper) : base(htmlHelper.ViewContext) {
            _htmlHelper = htmlHelper;
        }
        protected override void Dispose(bool disposing) {
            if (disposing) {
                _htmlHelper.ViewContext.Writer.Write(_htmlHelper.AntiForgeryTokenOrchard());
            }
            base.Dispose(disposing);
    }
}
