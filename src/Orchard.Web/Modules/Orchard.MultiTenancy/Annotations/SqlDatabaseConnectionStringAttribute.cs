using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Orchard.MultiTenancy.Annotations {
    public class SqlDatabaseConnectionStringAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            if (value is string && ((string) value).Length > 0) {
                try {
                    var connectionStringBuilder = new SqlConnectionStringBuilder(value as string);
                    //TODO: (erikpo) Should the keys be checked here to ensure that a valid combination was entered? Needs investigation.
                }
                catch {
                    return false;
            }
            return true;
        }
    }
}
