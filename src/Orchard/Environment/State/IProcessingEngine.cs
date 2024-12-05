using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Configuration;
using Orchard.Environment.Descriptor.Models;

namespace Orchard.Environment.State
{
    public interface IProcessingEngine
    {
        /// <summary>
        /// Init a new tasks list in the http context or in a new logical context.
        /// </summary>
        void Initialize();
        /// Queue an event to fire inside of an explicitly decribed shell context
        /// </summary>        
        string AddTask(
            ShellSettings shellSettings, 
            ShellDescriptor shellDescriptor, 
            string messageName, 
            Dictionary<string, object> parameters);
        /// Called by a component responsible for causing tasks to execute. Can be called from 
        /// anyplace which needs to know if work needs to be performed.
        bool AreTasksPending();
        /// Called by a component responsible for causing tasks to execute. Must only be called
        /// at a point where a full context-specific transaction scope may run. (*Not* inside the processing
        /// of a request)
        void ExecuteNextTask();
    }
}
