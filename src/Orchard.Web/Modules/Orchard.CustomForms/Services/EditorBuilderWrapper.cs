using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.CustomForms.Services {
    public class EditorBuilderWrapper : IEditorBuilderWrapper {
        private readonly IContentManager _contentManager;
        public EditorBuilderWrapper(
            IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public dynamic BuildEditor(IContent content) {
            return _contentManager.BuildEditor(content);
        public dynamic UpdateEditor(IContent content, IUpdateModel updateModel) {
            return _contentManager.UpdateEditor(content, updateModel);
    }
}
