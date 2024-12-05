using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using StackExchange.Redis;

namespace Orchard.Redis.Configuration {
    public interface IRedisConnectionProvider : ISingletonDependency {
        ConnectionMultiplexer GetConnection(string connectionString);
        string GetConnectionString(string service);
    }
}
