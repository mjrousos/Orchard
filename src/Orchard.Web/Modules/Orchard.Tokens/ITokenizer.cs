using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Events;

namespace Orchard.Tokens {
    public interface ITokenizer : IDependency {
        IDictionary<string, object> Evaluate(IEnumerable<string> tokens, object data);
        IDictionary<string, object> Evaluate(IEnumerable<string> tokens, IDictionary<string, object> data);
        string Replace(string text, object data);
        string Replace(string text, object data, ReplaceOptions options);
        string Replace(string text, IDictionary<string, object> data);
        string Replace(string text, IDictionary<string, object> data, ReplaceOptions options);
    }
}
