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
using Orchard.Environment.Extensions.Models;

namespace Orchard.MultiTenancy.Services {
    public interface ITenantService : IDependency {
        /// <summary>
        /// Retrieves ShellSettings objects for all tenants.
        /// </summary>
        IEnumerable<ShellSettings> GetTenants();
        /// Creates a new tenant.
        /// <param name="settings">A ShellSettings object specifying the settings for the new tenant.</param>
        void CreateTenant(ShellSettings settings);
        /// Updates the settings of a tenant.
        /// <param name="settings">The new ShellSettings object for the tenant.</param>
        void UpdateTenant(ShellSettings settings);
        /// Resets a tenant to its uninitialized state.
        /// <param name="settings">A ShellSettings object to identify the tenant to reset.</param>
        /// <param name="dropDatabaseTables">A boolean indicated whether tenant database tables should be dropped also.</param>
        /// <param name="force">A boolean indicating whether reset should be performed even if the tenant state is <c>TenantState.Running</c>.</param>
        void ResetTenant(ShellSettings settings, bool dropDatabaseTables, bool force);
        /// Returns a list of all known database tables in a tenant.
        /// <param name="settings">A ShellSettings object to identify the tenant.</param>
        /// <returns>A list of known database table names for the tenant.</returns>
        IEnumerable<string> GetTenantDatabaseTableNames(ShellSettings settings);
        /// Returns a list of all installed themes.
        IEnumerable<ExtensionDescriptor> GetInstalledThemes();
        /// Returns a list of all installed modules
        IEnumerable<ExtensionDescriptor> GetInstalledModules();
    }
}
