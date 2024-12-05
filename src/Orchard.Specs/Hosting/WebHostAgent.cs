using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Web.Hosting;

namespace Orchard.Specs.Hosting {
    public class WebHostAgent : MarshalByRefObject {
        public SerializableDelegate<Action> Execute(SerializableDelegate<Action> shuttle) {
            shuttle.Delegate();
            return shuttle;
        }
        public void Shutdown() {
            HostingEnvironment.InitiateShutdown();
    }
}
