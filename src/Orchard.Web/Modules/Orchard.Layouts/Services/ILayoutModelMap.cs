using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Newtonsoft.Json.Linq;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Services {
    public interface ILayoutModelMap : IDependency {
        int Priority { get; }
        string LayoutElementType { get; }
        bool CanMap(Element element);
        Element ToElement(IElementManager elementManager, DescribeElementsContext describeContext, JToken node);
        void FromElement(Element element, DescribeElementsContext describeContext, JToken node);
    }
}
