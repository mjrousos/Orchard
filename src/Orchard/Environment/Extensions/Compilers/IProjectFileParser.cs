using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;

namespace Orchard.Environment.Extensions.Compilers {
    public interface IProjectFileParser {
        ProjectFileDescriptor Parse(string virtualPath);
        ProjectFileDescriptor Parse(Stream stream);
    }
}
