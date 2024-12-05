using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Scripting.Compiler;

namespace Orchard.Scripting.Ast {
    public interface IAstNodeWithToken {
        Token Token { get; }
    }
}
