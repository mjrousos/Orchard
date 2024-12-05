using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Autoroute.Services;
using Orchard.ContentManagement.Aspects;
using Orchard.Environment.Extensions;
using Orchard.Localization.Services;

namespace Orchard.Localization.Events {
    [OrchardFeature("Orchard.Localization.Transliteration.SlugGeneration")]
    public class TransliterationSlugEventHandler : ISlugEventHandler {
        private readonly ITransliterationService _transliterationService;
        public TransliterationSlugEventHandler(ITransliterationService transliterationService) {
            _transliterationService = transliterationService;
        }
        public void FillingSlugFromTitle(FillSlugContext context) {
            var localizationAspect = context.Content.As<ILocalizableAspect>();
            if (localizationAspect == null) return;
            context.Title = _transliterationService.Convert(context.Title, localizationAspect.Culture);
        public void FilledSlugFromTitle(FillSlugContext context) {
    }
}
