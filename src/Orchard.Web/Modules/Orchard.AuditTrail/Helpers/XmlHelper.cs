using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Xml.Linq;

namespace Orchard.AuditTrail.Helpers {
    public static class XmlHelper {
        public static XElement Parse(string xml) {
            if (String.IsNullOrEmpty(xml))
                return null;
            try {
                return XElement.Parse(xml);
            }
            catch (Exception) {
        }
    }
}
