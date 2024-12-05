using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;

namespace Orchard.Core.Navigation.Models {
    public class AdminMenuPart : ContentPart<AdminMenuPartRecord> {
        public bool OnAdminMenu {
            get { return Record.OnAdminMenu; }
            set { Record.OnAdminMenu = value; }
        }
        [StringLength(AdminMenuPartRecord.DefaultMenuTextLength)]
        public string AdminMenuText {
            get { return Record.AdminMenuText; }
            set { Record.AdminMenuText = value; }
        public string AdminMenuPosition {
            get { return Record.AdminMenuPosition; }
            set { Record.AdminMenuPosition = value; }
    }
}
