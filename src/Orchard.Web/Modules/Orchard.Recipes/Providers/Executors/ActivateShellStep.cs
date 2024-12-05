using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Configuration;
using Orchard.Recipes.Models;
using Orchard.Recipes.Services;

namespace Orchard.Recipes.Providers.Executors {
    public class ActivateShellStep : RecipeExecutionStep {
        private readonly ShellSettings _shellSettings;
        private readonly IShellSettingsManager _shellSettingsManager;
        public ActivateShellStep(ShellSettings shellSettings, IShellSettingsManager shellSettingsManager, RecipeExecutionLogger logger) 
            : base(logger) {
            _shellSettings = shellSettings;
            _shellSettingsManager = shellSettingsManager;
        }
        public override string Name { get { return "ActivateShell"; } }
        public override void Execute(RecipeExecutionContext context) {
            _shellSettings.State = TenantState.Running;
            _shellSettingsManager.SaveSettings(_shellSettings);
    }
}
