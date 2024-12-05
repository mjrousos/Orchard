using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.State.Models;

namespace Orchard.Environment.State {
    public interface IShellStateManager : IDependency {
        ShellState GetShellState();
        void UpdateEnabledState(ShellFeatureState featureState, ShellFeatureState.State value);
        void UpdateInstalledState(ShellFeatureState featureState, ShellFeatureState.State value);
    }
}
