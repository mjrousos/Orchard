using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;

namespace Orchard.Data.Bags.Serialization {
    public interface IBagSerializer : IDependency {
        void Serialize(TextWriter tw, Bag o);
        Bag Deserialize(TextReader tr);
    }
}
