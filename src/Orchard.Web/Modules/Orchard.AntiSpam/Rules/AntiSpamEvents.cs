using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Events;

namespace Orchard.AntiSpam.Rules {
    public interface IEventProvider : IEventHandler {
        void Describe(dynamic describe);
    }
    public class AntiSpamEvents : IEventProvider {
        public AntiSpamEvents() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public void Describe(dynamic describe) {
            Func<dynamic, bool> alwaysTrue = c => true;
            describe.For("AntiSpam", T("Anti-Spam"), T("Anti-Spam"))
                .Element("Spam", T("Spam Reported"), T("Content is categorized as spam."), alwaysTrue, (Func<dynamic, LocalizedString>)(context => T("When content is categorized as spam.")), null)
                .Element("Ham", T("Ham Reported"), T("Content is categorized as ham."), alwaysTrue, (Func<dynamic, LocalizedString>)(context => T("When content is categorized as ham.")), null)
                ;
}
