using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Workflows.Models {
    /// <summary>
    /// Reprensents a transition between two <see cref="ActivityRecord"/>
    /// </summary>
    public class TransitionRecord {

        public virtual int Id { get; set; }
        /// <summary>
        /// The source <see cref="ActivityRecord"/>
        /// </summary>
        public virtual ActivityRecord SourceActivityRecord { get; set; }
        /// The name of the endpoint on the source <see cref="ActivityRecord"/>
        public virtual string SourceEndpoint { get; set; }
        /// The destination <see cref="ActivityRecord"/>
        public virtual ActivityRecord DestinationActivityRecord { get; set; }
        /// The name of the endpoint on the destination <see cref="ActivityRecord"/>
        public virtual string DestinationEndpoint { get; set; }
        /// The parent <see cref="WorkflowDefinitionRecord"/>
        public virtual WorkflowDefinitionRecord WorkflowDefinitionRecord { get; set; }
    }
}
