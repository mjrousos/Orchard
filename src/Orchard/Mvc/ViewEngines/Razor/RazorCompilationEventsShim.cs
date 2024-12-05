using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Threading;
using System.Web.Razor.Generator;
using System.Web.WebPages.Razor;
using Orchard.Environment;

namespace Orchard.Mvc.ViewEngines.Razor {
    public class RazorCompilationEventsShim : IShim {
        private static int _initialized;
        private RazorCompilationEventsShim() {
            OrchardHostContainerRegistry.RegisterShim(this);
            RazorBuildProvider.CodeGenerationStarted += RazorBuildProviderCodeGenerationStarted;
            RazorBuildProvider.CodeGenerationCompleted += RazorBuildProviderCodeGenerationCompleted;
        }
        public IOrchardHostContainer HostContainer { get; set; }
        private void RazorBuildProviderCodeGenerationStarted(object sender, EventArgs e) {
            var provider = (RazorBuildProvider)sender;
            HostContainer.Resolve<IRazorCompilationEvents>().CodeGenerationStarted(provider);
        private void RazorBuildProviderCodeGenerationCompleted(object sender, CodeGenerationCompleteEventArgs e) {
            HostContainer.Resolve<IRazorCompilationEvents>().CodeGenerationCompleted(provider, e);
        public static void EnsureInitialized() {
            var uninitialized = Interlocked.CompareExchange(ref _initialized, 1, 0) == 0;
            if (uninitialized)
                new RazorCompilationEventsShim();
    }
}
