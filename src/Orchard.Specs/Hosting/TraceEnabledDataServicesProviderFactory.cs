using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using FluentNHibernate.Cfg.Db;
using Orchard.Data.Providers;
using MsSqlCeConfiguration = Orchard.Data.Providers.MsSqlCeConfiguration;

namespace Orchard.Specs.Hosting {
    public class TraceEnabledDataServicesProviderFactory : IDataServicesProviderFactory {
        public IDataServicesProvider CreateProvider(DataServiceParameters sessionFactoryParameters) {
            return new TraceEnabledBuilder(sessionFactoryParameters.DataFolder, sessionFactoryParameters.ConnectionString);
        }
        class TraceEnabledBuilder : SqlCeDataServicesProvider {
            public TraceEnabledBuilder(string dataFolder, string connectionString) : base(dataFolder, connectionString) {
            }
            public override IPersistenceConfigurer GetPersistenceConfigurer(bool createDatabase) {
                var config = (MsSqlCeConfiguration)base.GetPersistenceConfigurer(createDatabase);
                // Uncomment to display SQL while running tests
                // config.ShowSql();
                return config;
    }
}
