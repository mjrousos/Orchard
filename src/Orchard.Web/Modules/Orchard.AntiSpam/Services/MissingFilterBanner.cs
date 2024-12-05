using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.AntiSpam.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;

namespace Orchard.AntiSpam.Services {
    public class MissingFilterBanner : INotificationProvider {
        private readonly ISpamService _spamService;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        public MissingFilterBanner(ISpamService spamService, IContentDefinitionManager contentDefinitionManager) {
            _spamService = spamService;
            _contentDefinitionManager = contentDefinitionManager;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public IEnumerable<NotifyEntry> GetNotifications() {
            // if there is any content type with Spam Part, ensure there is a filter available
            var typeHasPart = _contentDefinitionManager.ListTypeDefinitions().Any(t => t.Parts.Any(p => p.PartDefinition.Name.Equals(typeof (SpamFilterPart).Name)));
            if(typeHasPart && !_spamService.GetSpamFilters().Any()) {
                yield return new NotifyEntry {Message = T("Anti-spam protection requires at least one anti-spam filter to be enabled and configured."), Type = NotifyType.Warning};
            }
    }
}
