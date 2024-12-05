using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Logging;
using Orchard.Recipes.Models;

namespace Orchard.Recipes.Services {
    public abstract class RecipeExecutionStep : IDependency, IRecipeExecutionStep {
        private readonly RecipeExecutionLogger _logger;
        public RecipeExecutionStep(RecipeExecutionLogger logger) {
            _logger = logger;
            _logger.ComponentType = GetType();
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public abstract string Name { get; }
        public virtual IEnumerable<string> Names {
            get { yield return Name; }
        public virtual LocalizedString DisplayName {
            get { return T(Name); }
        public virtual LocalizedString Description {
            get { return DisplayName; }
        protected virtual string Prefix {
            get { return GetType().Name; }
        protected virtual ILogger Logger {
            get { return _logger; }
        public virtual dynamic BuildEditor(dynamic shapeFactory) {
            return null;
        public virtual dynamic UpdateEditor(dynamic shapeFactory, IUpdateModel updater) {
        public virtual void Configure(RecipeExecutionStepConfigurationContext context) {
        public virtual void UpdateStep(UpdateRecipeExecutionStepContext context) {
        public abstract void Execute(RecipeExecutionContext context);
    }
}
