using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Xml.Linq;

namespace Orchard.ContentManagement.FieldStorage.InfosetStorage {
    public class Infoset {
        private XElement _element;
        private void SetElement(XElement value) {
            _element = value;
        }
        public XElement Element {
            get {
                return _element ?? (_element = new XElement("Data"));
            }
        public string Data {
                return _element == null ? null : Element.ToString(SaveOptions.DisableFormatting);
            set {
                SetElement(string.IsNullOrEmpty(value) ? null : XElement.Parse(value, LoadOptions.PreserveWhitespace));
    }
}
