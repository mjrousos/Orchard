using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.MediaLibrary.Providers;

namespace Orchard.MediaLibrary.Implementation {
    public class DefaultMediaUsername : IMediaFolderProvider {
        public virtual string GetFolderName(IUser content) {
                string folder = "";
                foreach (char c in content.UserName) {
                    if (char.IsLetterOrDigit(c)) {
                        folder += c;
                    }
                    else
                        folder += "_" + String.Format("{0:X}", Convert.ToInt32(c));
                }
                return folder;
        }
    }
}
