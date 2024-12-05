using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Tests.Environment.TestDependencies {

    public interface IBetaDependency : IDependency {
    }
    public class BetaDependency : IBetaDependency {
        public IAlphaDependency Alpha { get; set; }
        public BetaDependency(IAlphaDependency alpha) {
            Alpha = alpha;
        }
}
