using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.Services.Tasks {

    /// <summary>
    /// Represents a specific configuration of a task provider for an individual task instance.
    /// </summary>
    public class TaskConfiguration {
        public TaskConfiguration(ITaskProvider provider) {
            TaskProvider = provider;
        }
        /// <summary>
        /// The provider that created this configuration
        /// </summary>
        public ITaskProvider TaskProvider { get; private set; }
        public dynamic EditorShape { get; set; }
        /// Used by the task provider to store the configuration information required to create an ITask instance.
        public dynamic Settings { get; set; }
    }
}
