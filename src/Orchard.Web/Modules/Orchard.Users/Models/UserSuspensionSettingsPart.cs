using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Users.Models {
    public class UserSuspensionSettingsPart : ContentPart {
        public bool SuspendInactiveUsers {
            get { return this.Retrieve(x => x.SuspendInactiveUsers); }
            set { this.Store(x => x.SuspendInactiveUsers, value); }
        }
        public int AllowedInactivityDays {
            get { return this.Retrieve(x => x.AllowedInactivityDays, 90); }
            set { this.Store(x => x.AllowedInactivityDays, value); }
        public int MinimumSweepInterval {
            get { return this.Retrieve(x => x.MinimumSweepInterval, 12); }
            set { this.Store(x => x.MinimumSweepInterval, value); }
        public DateTime? LastSweepUtc {
            get { return this.Retrieve(x => x.LastSweepUtc); }
            set { this.Store(x => x.LastSweepUtc, value); }
    }
}
