using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.JobsQueue.Models;
using Orchard.JobsQueue.ViewModels;
using Orchard.Messaging.Models;

namespace Orchard.JobsQueue.Drivers {
    public class JobsQueueSettingsPartDriver : ContentPartDriver<JobsQueueSettingsPart> {
        private const string TemplateName = "Parts/JobsQueueSettings";
        public IOrchardServices Services { get; set; }
        public JobsQueueSettingsPartDriver(IOrchardServices services) {
            Services = services;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        protected override string Prefix { get { return "JobsQueueSettings"; } }
        protected override DriverResult Editor(JobsQueueSettingsPart part, dynamic shapeHelper) {
            var model = new JobsQueueSettingsPartViewModel {
                JobsQueueSettings = part
            };
            return ContentShape("Parts_JobsQueueSettings_Edit", () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: model, Prefix: Prefix));
        protected override DriverResult Editor(JobsQueueSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(model, Prefix, null, null);
    }
}
