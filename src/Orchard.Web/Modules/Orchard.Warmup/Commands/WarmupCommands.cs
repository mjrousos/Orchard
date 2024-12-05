using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Commands;
using Orchard.Warmup.Services;

namespace Orchard.Warmup.Commands {
    public class WarmupCommands : DefaultOrchardCommandHandler {
        private readonly IWarmupUpdater _warmupUpdater;
        [OrchardSwitch]
        public bool Force { get; set; }
        public WarmupCommands(IWarmupUpdater warmupUpdater) {
            _warmupUpdater = warmupUpdater;
        }
        [CommandName("warmup generate")]
        [CommandHelp("warmup generate [/Force:true] \r\n\t Generates all the static pages for the warmup feature.")]
        [OrchardSwitches("Force")]
        public void Generate() {
            if(Force) {
                _warmupUpdater.Generate();
            }
            else {
                _warmupUpdater.EnsureGenerate();
            Context.Output.WriteLine(T("Generation finished"));
    }
}
