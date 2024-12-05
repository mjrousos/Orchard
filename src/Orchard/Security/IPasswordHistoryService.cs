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
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Security {
    public interface IPasswordHistoryService : IDependency {
        void CreateEntry(PasswordHistoryEntry context);
        IEnumerable<PasswordHistoryEntry> GetLastPasswords(IUser user, int count);
        bool PasswordMatchLastOnes(string Password, IUser user, int count);
    }
}
