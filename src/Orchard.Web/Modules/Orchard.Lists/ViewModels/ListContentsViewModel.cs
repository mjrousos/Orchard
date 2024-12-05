using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Core.Containers.ViewModels;

namespace Orchard.Lists.ViewModels {
    public class ListContentsViewModel  {
        public ListContentsViewModel() {
            Options = new ContentOptions();
        }
        public string FilterByContentType { get; set; }
        public int ContainerId { get; set; }
        public string ContainerDisplayName { get; set; }
        public int? Page { get; set; }
        public IList<Entry> Entries { get; set; }
        public ContentOptions Options { get; set; }
        public class Entry {
            public ContentItem ContentItem { get; set; }
            public ContentItemMetadata ContentItemMetadata { get; set; }
    }
    public class ContentOptions {
        public ContentOptions() {
            OrderBy = SortBy.Modified;
            BulkAction = ContentsBulkAction.None;
        public string SelectedFilter { get; set; }
        public SortBy OrderBy { get; set; }
        public ContentsBulkAction BulkAction { get; set; }
    
    public enum ContentsBulkAction {
        None,
        PublishNow,
        Unpublish,
        Remove,
        RemoveFromList,
        MoveToList
    public enum ListOperation {
        Shuffle,
        Reverse,
        Sort
}
