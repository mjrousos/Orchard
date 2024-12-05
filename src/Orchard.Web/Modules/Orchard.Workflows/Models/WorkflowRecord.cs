using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Workflows.Models {
    /// <summary>
    /// Reprensents a running workflow instance.
    /// </summary>
    public class WorkflowRecord {
        public WorkflowRecord() {
            AwaitingActivities = new List<AwaitingActivityRecord>();
        }
        public virtual int Id { get; set; }
        /// <summary>
        /// Serialized state of the workflow.
        /// </summary>
        [StringLengthMax]
        public virtual string State { get; set; }
        /// List of activities the current workflow instance is waiting on 
        /// for continuing its process.
        [CascadeAllDeleteOrphan]
        public virtual IList<AwaitingActivityRecord> AwaitingActivities { get; set; }
        /// The associated content item
        public virtual ContentItemRecord ContentItemRecord { get; set; }
        /// Parent <see cref="WorkflowDefinitionRecord"/>
        public virtual WorkflowDefinitionRecord WorkflowDefinitionRecord { get; set; }
    }
}
