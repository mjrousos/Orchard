using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Conventions;

namespace Orchard.Workflows.Models {
    /// <summary>
    /// Represents an activity in a <see cref="WorkflowDefinitionRecord"/>
    /// </summary>
    public class ActivityRecord {
        public virtual int Id { get; set; }
        
        /// <summary>
        /// The type of the activity.
        /// </summary>
        public virtual string Name { get; set; }
        /// The serialized state of the activity.
        [StringLengthMax]
        public virtual string State { get; set; }
        /// The left coordinate of the activity.
        public virtual int X { get; set; }
        /// The top coordinate of the activity.
        public virtual int Y { get; set; }
        /// Whether the activity is a start state for a WorkflowDefinition.
        public virtual bool Start { get; set; }
        /// The parent <see cref="WorkflowDefinitionRecord"/> 
        /// containing this activity.
        public virtual WorkflowDefinitionRecord WorkflowDefinitionRecord { get; set; }
        /// Gets the Id which can be used on the client. 
        /// <returns>An unique Id to represent this activity on the client.</returns>
        public string GetClientId() {
            return Name + "_" + Id;
        }
    }
}
