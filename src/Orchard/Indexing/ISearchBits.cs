using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Indexing {
    public interface ISearchBits {
        ISearchBits And(ISearchBits other);
        ISearchBits Or(ISearchBits other);
        ISearchBits Xor(ISearchBits other);
        long Count();
    }
}
