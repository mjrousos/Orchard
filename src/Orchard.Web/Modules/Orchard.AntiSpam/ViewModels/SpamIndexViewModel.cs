using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.AntiSpam.Models;

namespace Orchard.AntiSpam.ViewModels {
    public class SpamIndexViewModel {
        public IList<SpamEntry> Spams { get; set; }
        public SpamIndexOptions Options { get; set; }
        public dynamic Pager { get; set; }
    }
    public class SpamEntry {
        public SpamFilterPart Spam { get; set; }
        public dynamic Shape { get; set; }
        public bool IsChecked { get; set; }
    public class SpamIndexOptions {
        public SpamIndexOptions() {
            Filter = SpamFilter.Spam;
        }
        public string Search { get; set; }
        public SpamOrder Order { get; set; }
        public SpamFilter Filter { get; set; }
        public SpamBulkAction BulkAction { get; set; }
    public enum SpamOrder {
        Creation
    public enum SpamFilter {
        Spam,
        Ham,
        All,
    public enum SpamBulkAction {
        None,
        Delete
}
