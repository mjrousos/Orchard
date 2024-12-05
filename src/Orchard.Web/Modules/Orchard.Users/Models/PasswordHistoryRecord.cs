using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Orchard.Users.Models {
    public class PasswordHistoryRecord {
        public virtual int Id { get; set; }
        public virtual UserPartRecord UserPartRecord { get; set; }
        public virtual string Password { get; set; }
        public virtual MembershipPasswordFormat PasswordFormat { get; set; }
        public virtual string HashAlgorithm { get; set; }
        public virtual string PasswordSalt { get; set; }
        public virtual DateTime? LastPasswordChangeUtc { get; set; }
    }
}
