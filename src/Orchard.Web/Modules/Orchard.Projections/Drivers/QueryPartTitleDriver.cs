using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Title.Models;

namespace Orchard.Projections.Drivers {
    public class QueryPartTitleDriver : ContentPartDriver<TitlePart> {
        private readonly IContentManager _contentManager;
        public QueryPartTitleDriver(IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public Localizer T { get; set; }
        protected override DriverResult Editor(TitlePart part, IUpdateModel updater, dynamic shapeHelper) {
            if (updater == null) {
                return null;
            }
            if(part.ContentItem.ContentType != "Query") {
            updater.TryUpdateModel(part, "Title", null, null);
            var query = _contentManager.Query("Query").Where<TitlePartRecord>(x => x.Title == part.Title).Slice(0, 1).FirstOrDefault();
            if (query != null && query.Id != part.ContentItem.Id) {
                updater.AddModelError("Title", T("A query with the same title already exists"));
            return null;
    }
}
