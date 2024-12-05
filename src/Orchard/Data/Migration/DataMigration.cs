using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration.Schema;
using Orchard.Environment.Extensions.Models;

namespace Orchard.Data.Migration {
    /// <summary>
    /// Data Migration classes can inherit from this class to get a SchemaBuilder instance configured with the current tenant database prefix
    /// </summary>
    public abstract class DataMigrationImpl : IDataMigration {
        public virtual SchemaBuilder SchemaBuilder { get; set; }
        public virtual IContentDefinitionManager ContentDefinitionManager { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
