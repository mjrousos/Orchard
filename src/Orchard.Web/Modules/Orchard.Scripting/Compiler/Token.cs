using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Scripting.Compiler {
    public class Token {
        public TokenKind Kind { get; set; }
        public int Position { get; set; }
        public object Value { get; set; }
        public override string ToString() {
            return Value == null ? String.Format("Token '{0}' at position {1}", Kind, Position) : String.Format("Token '{0}' ({1}) at position {2}", Kind, Value, Position);
        }
    }
}
