using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Recipes.Models;

namespace Orchard.Recipes.Services {
    public abstract class RecipeBuilderStep : Component, IRecipeBuilderStep {
        public abstract string Name { get; }
        public abstract LocalizedString DisplayName { get; }
        public abstract LocalizedString Description { get; }
        public virtual int Priority { get { return 0; } }
        public virtual int Position { get { return 0; } }
        public virtual bool IsVisible { get { return true; } }
        protected virtual string Prefix {
            get { return GetType().Name; }
        }
        public virtual dynamic BuildEditor(dynamic shapeFactory) {
            return null;
        public virtual dynamic UpdateEditor(dynamic shapeFactory, IUpdateModel updater) {
        public virtual void Configure(RecipeBuilderStepConfigurationContext context) {
        public virtual void ConfigureDefault() {
        public virtual void Build(BuildContext context) {}
    }
}
