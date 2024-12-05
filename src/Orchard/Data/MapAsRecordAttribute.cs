using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Data {
    /// <summary>
    /// Marks whether a class should be mapped as an NHibernate record
    /// </summary>
    public class MapAsRecordAttribute : Attribute {
        private readonly bool _enabled;
        public MapAsRecordAttribute() : this(true) { }
        public MapAsRecordAttribute(bool enabled) {
            _enabled = enabled;
        }
        public bool Enabled => _enabled;
    }
}
