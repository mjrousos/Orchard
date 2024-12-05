using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Newtonsoft.Json.Linq;
using Orchard.Layouts.Elements;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Services {
    public interface IElementSerializer : IDependency {
        Element Deserialize(string data, DescribeElementsContext describeContext);
        string Serialize(Element element);
        object ToDto(Element element, int index = 0);
        Element ParseNode(JToken node, Container parent, int index, DescribeElementsContext describeContext);
    }
}
