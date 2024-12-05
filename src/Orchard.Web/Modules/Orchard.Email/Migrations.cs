using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using System.Xml;
using Orchard.Data.Migration;
using Orchard.Email.Models;

namespace Orchard.Email {
    public class Migrations : DataMigrationImpl {
        private readonly IContentManager _contentManager;
        public Migrations(IContentManager contentManager) => _contentManager = contentManager;
        // The first migration without any content should not exist but it has been deployed so we need to keep it.
        public int Create() => 1;
        public int UpdateFrom1() {
            // Migrate existing SmtpSettingPart.Address because we rename it to FromAddress.
            var siteSettingsItem = _contentManager.Query(contentTypeNames: "Site")
                .Slice(1)
                .SingleOrDefault();
            var siteSettingsRecord = siteSettingsItem?.Record;
            if (siteSettingsRecord != null) {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(siteSettingsRecord.Data);
                var smtpSettingNode = xmlDoc.SelectSingleNode("//SmtpSettingsPart");
                if (smtpSettingNode != null) {
                    var smtpSettingsPart = siteSettingsItem.As<SmtpSettingsPart>();
                    smtpSettingsPart.FromAddress = smtpSettingNode.Attributes["Address"]?.Value;
                }
            }
            return 2;
        }
    }
}
