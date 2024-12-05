using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Core.Title.Models;

namespace Orchard.Projections.Models {
    public class QueryPart : ContentPart<QueryPartRecord> {
        public string Name {
            get { return this.As<TitlePart>().Title; }
            set { this.As<TitlePart>().Title = value; }
        }
        public QueryVersionScopeOptions VersionScope {
            get { return Retrieve(x => x.VersionScope); }
            set { Store(x => x.VersionScope, value); }
        public IList<SortCriterionRecord> SortCriteria {
            get { return Record.SortCriteria; }
        public IList<FilterGroupRecord> FilterGroups {
            get { return Record.FilterGroups; }
        public IList<LayoutRecord> Layouts {
            get { return Record.Layouts; }
    }
}
