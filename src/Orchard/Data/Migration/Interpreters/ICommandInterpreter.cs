using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Migration.Schema;

namespace Orchard.Data.Migration.Interpreters {
    /// <summary>
    /// This interface can be implemented to provide a data migration behavior
    /// </summary>
    public interface ICommandInterpreter<in T> : ICommandInterpreter
    where T : ISchemaBuilderCommand {
        string[] CreateStatements(T command);
    }
    public interface ICommandInterpreter : IDependency {
        string DataProvider { get; }
}
