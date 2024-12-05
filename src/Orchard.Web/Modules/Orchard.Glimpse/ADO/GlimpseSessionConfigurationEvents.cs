using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Orchard.Utility;

namespace Orchard.Glimpse.ADO {
    [OrchardFeature(FeatureNames.SQL)]
    public class GlimpseSessionConfigurationEvents : ISessionConfigurationEvents {
        public void Created(FluentConfiguration cfg, AutoPersistenceModel defaultModel) {}
        public void Prepared(FluentConfiguration cfg) {}
        public void Building(Configuration cfg) {}
        public void Finished(Configuration cfg) {
            cfg.SetProperty("connection.provider", "Orchard.Glimpse.ADO.GlimpseConnectionProvider, Orchard.Glimpse");
        }
        public void ComputingHash(Hash hash) {}
    }
}
