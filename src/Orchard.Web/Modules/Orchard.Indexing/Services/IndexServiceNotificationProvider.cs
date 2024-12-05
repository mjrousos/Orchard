using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;

namespace Orchard.Indexing.Services {
    public class IndexServiceNotificationProvider: INotificationProvider {
        private readonly IIndexManager _indexManager;
        public IndexServiceNotificationProvider(IIndexManager indexManager) {
            _indexManager = indexManager;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public IEnumerable<NotifyEntry> GetNotifications() {
            if(!_indexManager.HasIndexProvider()) {
                yield return new NotifyEntry { Message = T("You need to enable an index implementation module like Lucene." ), Type = NotifyType.Warning};
            }
    }
}
