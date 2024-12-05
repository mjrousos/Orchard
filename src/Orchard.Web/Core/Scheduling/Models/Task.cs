using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.Tasks.Scheduling;

namespace Orchard.Core.Scheduling.Models {
    public class Task : IScheduledTask {
        private readonly IContentManager _contentManager;
        private readonly ScheduledTaskRecord _record;
        private ContentItem _item;
        private bool _itemInitialized;
        public Task(IContentManager contentManager, ScheduledTaskRecord record) {
            // in spite of appearances, this is actually a created class, not IoC, 
            // but dependencies are passed in for lazy initialization purposes
            _contentManager = contentManager;
            _record = record;
        }
        public string TaskType {
            get { return _record.TaskType; }
        public DateTime? ScheduledUtc {
            get { return _record.ScheduledUtc; }
        public ContentItem ContentItem {
            get {
                if (!_itemInitialized) {
                    if (_record.ContentItemVersionRecord != null) {
                        _item = _contentManager.Get(
                            _record.ContentItemVersionRecord.ContentItemRecord.Id,
                            VersionOptions.VersionRecord(_record.ContentItemVersionRecord.Id));
                    }
                    _itemInitialized = true;
                }
                return _item;
            }
    }
}
