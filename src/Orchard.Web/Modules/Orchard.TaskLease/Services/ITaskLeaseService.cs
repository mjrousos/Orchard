using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.TaskLease.Services {
    /// <summary>
    /// Describes a service to save and acquire task leases. A task lease can't be acquired by two different machines,
    /// for a specific amount of time. Optionnally a State can be saved along with the lease.
    /// </summary>
    [Obsolete("Use Orchard.Tasks.Locking.IDistributedLockService instead.")]
    public interface ITaskLeaseService : IDependency {
    
        /// <summary>
        /// Acquires a lease for the specified task name, and amount of time.
        /// </summary>
        /// <returns>The state of the lease if it was acquired, otherwise <c>null</c>.</returns>
        string Acquire(string taskName, DateTime expiredUtc);
        /// Updates a lease for the current machine if it exists
        void Update(string taskName, string state);
        void Update(string taskName, string state, DateTime expiredUtc);
    }
}
