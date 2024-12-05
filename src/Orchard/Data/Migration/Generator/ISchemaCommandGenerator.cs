using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Data.Migration.Schema;

namespace Orchard.Data.Migration.Generator {
    public interface ISchemaCommandGenerator : IDependency {
        /// <summary>
        /// Returns a set of <see cref="SchemaCommand"/> instances to execute in order to create the tables requiered by the specified feature. 
        /// </summary>
        /// <param name="feature">The name of the feature from which the tables need to be created.</param>
        /// <param name="drop">Whether to generate drop commands for the created tables.</param>
        IEnumerable<SchemaCommand> GetCreateFeatureCommands(string feature, bool drop);
        
        /// Automatically updates the tables in the database.
        void UpdateDatabase();
        /// Creates the tables in the database.
        void CreateDatabase();
    }
}
