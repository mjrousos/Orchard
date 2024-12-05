using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;

namespace Orchard.Data.Providers {
    public interface IDataServicesProvider : ITransientDependency {
        Configuration BuildConfiguration(SessionFactoryParameters sessionFactoryParameters);
        IPersistenceConfigurer GetPersistenceConfigurer(bool createDatabase);
    }
}
