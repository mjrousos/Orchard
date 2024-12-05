using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.MetaData.Builders;

namespace Orchard.Roles.Models {
    public static class UserSimulation {
        public static IUser Create(string role) {
            var simulationType = new ContentTypeDefinitionBuilder().Named("User").Build();
            var simulation = new ContentItemBuilder(simulationType)
                .Weld<SimulatedUser>()
                .Weld<SimulatedUserRoles>()
                .Build();
            simulation.As<SimulatedUserRoles>().Roles = new[] {role};
            return simulation.As<IUser>();
        }
        class SimulatedUser : ContentPart, IUser {
            public string UserName { get { return null; } }
            public string Email { get { return null; } }
        class SimulatedUserRoles : ContentPart, IUserRoles {
            public IList<string> Roles { get; set; }
    }
}
