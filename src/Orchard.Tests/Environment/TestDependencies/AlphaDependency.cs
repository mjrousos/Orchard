using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Tests.Environment.TestDependencies {

    public interface IAlphaDependency : IDependency {
    }
    public class AlphaDependency : IAlphaDependency {
}
