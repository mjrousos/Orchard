using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.Data.Migration {
    public interface IDataMigrationManager : IDependency {
        /// <summary>
        /// Whether a feature has already been installed, i.e. one of its Data Migration class has already been processed
        /// </summary>
        bool IsFeatureAlreadyInstalled(string feature);
        /// Returns the features which have at least one Data Migration class with a corresponding Upgrade method to be called
        IEnumerable<string> GetFeaturesThatNeedUpdate();
        /// Updates the database to the latest version for the specified feature
        void Update(string feature);
        /// Updates the database to the latest version for the specified features
        void Update(IEnumerable<string> features);
        /// Execute a script to delete any information relative to the feature
        /// <param name="feature"></param>
        void Uninstall(string feature);
    }
}
