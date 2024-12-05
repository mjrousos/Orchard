using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Caching;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.SecureSocketsLayer.Models;

namespace Orchard.SecureSocketsLayer.Drivers {
    public class SslSettingsPartDriver : ContentPartDriver<SslSettingsPart> {
        private readonly ISignals _signals;
        private const string TemplateName = "Parts/SecureSocketsLayer.Settings";
        public SslSettingsPartDriver(ISignals signals) {
            _signals = signals;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        protected override string Prefix {
            get { return "SslSettings"; }
        protected override DriverResult Editor(SslSettingsPart part, dynamic shapeHelper) {
            return ContentShape("Parts_SslSettings_Edit",
                () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix))
                .OnGroup("Ssl");
        protected override DriverResult Editor(SslSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            if (updater.TryUpdateModel(part, Prefix, null, null)) {
                _signals.Trigger(SslSettingsPart.CacheKey);
                if (!part.Enabled) part.SecureEverything = false;
                if (!part.SecureEverything) part.SendStrictTransportSecurityHeaders = false;
                if (!part.StrictTransportSecurityIncludeSubdomains) part.StrictTransportSecurityPreload = false;
            }
            return Editor(part, shapeHelper);
        protected override void Importing(SslSettingsPart part, ImportContentContext context) {
            _signals.Trigger(SslSettingsPart.CacheKey);
    }
}
