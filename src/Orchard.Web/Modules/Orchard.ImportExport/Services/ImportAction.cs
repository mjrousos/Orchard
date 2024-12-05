using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ImportExport.Models;

namespace Orchard.ImportExport.Services {
    public abstract class ImportAction : Component, IImportAction {
        public virtual int Priority { get { return 0; } }
        public abstract string Name { get; }
        protected virtual string Prefix {
            get { return GetType().Name; }
        }
        public virtual dynamic BuildEditor(dynamic shapeFactory) {
            return null;
        public virtual dynamic UpdateEditor(dynamic shapeFactory, IUpdateModel updater) {
        public virtual void Configure(ImportActionConfigurationContext context) {
        public abstract void Execute(ImportActionContext context);
    }
}
