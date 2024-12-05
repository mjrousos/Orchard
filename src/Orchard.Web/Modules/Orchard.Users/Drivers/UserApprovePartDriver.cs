using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Mvc;
using Orchard.Users.Models;
using Orchard.Users.ViewModels;

namespace Orchard.Users.Drivers {
    public class UserApprovePartDriver : ContentPartDriver<UserPart> {
        private const string TemplateName = "Parts/User.Approve";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrchardServices _orchardServices;
        public UserApprovePartDriver(
            IHttpContextAccessor httpContextAccessor,
            IOrchardServices orchardServices
            ) {
            _httpContextAccessor = httpContextAccessor;
            _orchardServices = orchardServices;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        protected override DriverResult Editor(UserPart part, dynamic shapeHelper) {
            var model = new UserEditViewModel { User = part };
            return ContentShape("Parts_UserApprove_Edit",
                                () => {
                                    if (!_orchardServices.Authorizer.Authorize(Permissions.ManageUsers, T("Not authorized to manage users"))) {
                                        return null;
                                    }
                                    return shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: model, Prefix: Prefix);
                                 });
        protected override DriverResult Editor(UserPart part, IUpdateModel updater, dynamic shapeHelper) {
                              () => {
                                  if (!_orchardServices.Authorizer.Authorize(Permissions.ManageUsers, T("Not authorized to manage users"))) { 
                                      return null;
                                  }
                                  return shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: model, Prefix: Prefix);
                              });
    }
}
