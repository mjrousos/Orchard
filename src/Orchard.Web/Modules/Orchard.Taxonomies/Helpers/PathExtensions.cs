using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.ViewModels;

namespace Orchard.Taxonomies.Helpers {
    public static class TermExtensions {
        public static int GetLevels(this TermPart term) {
            return String.IsNullOrEmpty(term.Path) ? 0 : term.Path.Count(c => c == '/') - 1;
        }
        public static int GetLevels(this TermEntry term) {
        public static TermEntry CreateTermEntry(this TermPart term) {
            return new TermEntry {
                Id = term.Id,
                Name = term.Name,
                Selectable = term.Selectable,
                Count = term.Count,
                Path = term.Path,
                Weight = term.Weight,
                IsChecked = false,
                ContentItem = term.ContentItem,
                HasDraft = term.ContentItem.HasDraft()
            };
    }
}
