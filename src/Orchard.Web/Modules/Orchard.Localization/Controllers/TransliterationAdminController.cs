using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Environment.Extensions;
using Orchard.Localization.Services;
using Orchard.Localization.ViewModels;

namespace Orchard.Localization.Controllers {
    [OrchardFeature("Orchard.Localization.Transliteration")]
    [Admin, ValidateInput(false)]
    public class TransliterationAdminController : Controller {
        private readonly ITransliterationService _transliterationService;
        public TransliterationAdminController(ITransliterationService transliterationService,
            IShapeFactory shapeFactory) {
            _transliterationService = transliterationService;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
        }
        dynamic Shape { get; set; }
        public Localizer T { get; set; }
        public ActionResult Index() {
            var specifications = _transliterationService.GetSpecifications();
            var viewModel = Shape.ViewModel()
                .Specifications(specifications);
            return View(viewModel);
        public ActionResult Create() {
            var viewModel = new CreateTransliterationViewModel();
        [HttpPost, ActionName("Create")]
        public ActionResult CreatePost(CreateTransliterationViewModel viewModel) {
            if (!ModelState.IsValid) {
                return View(viewModel);
            }
            _transliterationService.Create(viewModel.CultureFrom, viewModel.CultureTo, viewModel.Rules);
            return RedirectToAction("Index");
        public ActionResult Edit(int id) {
            var record = _transliterationService.Get(id);
            var viewModel = new EditTransliterationViewModel {
                Id = record.Id,
                CultureFrom = record.CultureFrom,
                CultureTo = record.CultureTo,
                Rules = record.Rules
            };
            return View(viewModel);            
        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(EditTransliterationViewModel viewModel) {
            _transliterationService.Update(viewModel.Id, viewModel.CultureFrom, viewModel.CultureTo, viewModel.Rules);
        public ActionResult Remove(int id) {
            _transliterationService.Remove(id);
    }
}
