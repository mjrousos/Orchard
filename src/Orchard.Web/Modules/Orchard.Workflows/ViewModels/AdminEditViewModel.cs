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
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace Orchard.Workflows.ViewModels {
    public class AdminEditViewModel {
        public string LocalId { get; set; }
        public bool IsLocal { get; set; }
        public IEnumerable<IActivity> AllActivities { get; set; }
        public WorkflowDefinitionViewModel WorkflowDefinition { get; set; }
        public WorkflowRecord Workflow { get; set; } 
    }
    [Serializable]
    public class UpdatedActivityModel {
        public string ClientId { get; set; }
        public string Data { get; set; }
}
