using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Autofac;

namespace Orchard.Environment {
    public interface IShellContainerRegistrations {
        Action<ContainerBuilder> Registrations { get; }
    }
    public class ShellContainerRegistrations : IShellContainerRegistrations {
        public ShellContainerRegistrations() {
            Registrations = builder => { return; };
        }
        public Action<ContainerBuilder> Registrations { get; private set; }
}
