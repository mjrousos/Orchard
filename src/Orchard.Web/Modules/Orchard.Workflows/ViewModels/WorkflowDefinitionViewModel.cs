using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Workflows.ViewModels {
    public class WorkflowDefinitionViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JsonData { get; set; }
    }
    public class ActivityViewModel {
        /// <summary>
        /// The local id used for connections
        /// </summary>
        public string ClientId { get; set; }
        /// The name of the activity
        public IDictionary<string, string> State { get; set; }
    public class ConnectionViewModel {
        public string SourceClientId { get; set; }
        public string Outcome { get; set; }
        public string DestinationClientId { get; set; }
}
