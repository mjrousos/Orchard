using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Search.ViewModels {
    public class SearchSettingsIndexViewModel {
        public SearchSettingsIndexViewModel() {
            AvailableIndexes = new List<string>();
        }
        public string SelectedIndex { get; set; }
        public IList<string> AvailableIndexes { get; set; }
    }
    public class SearchSettingsFieldsViewModel {
        public SearchSettingsFieldsViewModel() {
            Entries = new List<IndexSettingsEntry>();
        public IList<IndexSettingsEntry> Entries { get; set; }
        public bool FilterCulture { get; set; }
        public string DisplayType { get; set; }
    public class IndexSettingsEntry {
        public IndexSettingsEntry() {
            Fields = new List<SearchSettingsEntry>();
        public string Index { get; set; }
        public IList<SearchSettingsEntry> Fields { get; set; }
    public class SearchSettingsEntry {
        public string Field { get; set; }
        public bool Selected { get; set; }
        public int Weight { get; set; }
}
