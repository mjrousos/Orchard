using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;

namespace Orchard.Data.Migration {
    public class DataMigrationNotificationProvider: INotificationProvider {
        private readonly IDataMigrationManager _dataMigrationManager;
        public DataMigrationNotificationProvider(IDataMigrationManager dataMigrationManager) {
            _dataMigrationManager = dataMigrationManager;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public IEnumerable<NotifyEntry> GetNotifications() {
            var features = _dataMigrationManager.GetFeaturesThatNeedUpdate();
            if(features.Any()) {
                yield return new NotifyEntry { Message = T("Some features need to be upgraded: {0}", String.Join(", ", features)), Type = NotifyType.Warning};
            }
    }
}
