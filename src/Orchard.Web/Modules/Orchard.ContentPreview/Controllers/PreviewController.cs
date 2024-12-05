using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Core.Common.Models;
using Orchard.Mvc;
using Orchard.Themes;
using Orchard.UI.Notify;
using Orchard.Security;
using Orchard.Localization;
using Orchard.Services;

namespace Orchard.ContentPreview.Controllers {
    [Themed]
    public class PreviewController : Controller {
        private readonly IContentManager _contentManager;
        private readonly INotifier _notifier;
        private readonly IClock _clock;
        private readonly IAuthorizer _authorizer;
        private readonly IHttpContextAccessor _hca;

        public PreviewController(
            IContentManager contentManager,
            INotifier notifier,
            IClock clock,
            IAuthorizer authorizer,
            IHttpContextAccessor hca) {
            _clock = clock;
            _notifier = notifier;
            _contentManager = contentManager;
            _authorizer = authorizer;
            _hca = hca;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public IActionResult Render([FromForm] string contentItemType) {
            if (!_authorizer.Authorize(Permissions.ContentPreview)) {
                return Unauthorized();
            }

            var contentItem = _contentManager.New(contentItemType);
            contentItem.VersionRecord = new ContentItemVersionRecord();

            var commonPart = contentItem.As<CommonPart>();
            if (commonPart != null) {
                commonPart.CreatedUtc = commonPart.ModifiedUtc = commonPart.PublishedUtc = _clock.UtcNow;
            }

            var model = _contentManager.UpdateEditor(contentItem, this);
            if (!ModelState.IsValid) {
                return View();
            }

            _notifier.Warning(T("The Content Preview feature doesn't support properties where there are relationships to ContentPartRecord (e.g. Taxonomies, Tags). These won't update in the preview windows but otherwise keep working."));
            model = _contentManager.BuildDisplay(contentItem, "Detail");
            return View(model);
        }

        public bool TryUpdateModelAsync<TModel>(TModel model, string prefix, string[] includeProperties = null, string[] excludeProperties = null) where TModel : class {
            return TryUpdateModelAsync(model, prefix).Result;
        }

        public void AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
    }
}
