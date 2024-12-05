using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;
using System.Text;
using System.Web;

namespace Orchard.Mvc.Spooling {
    public class HtmlStringWriter : TextWriter ,IHtmlString {
        private readonly TextWriter _writer;
        public HtmlStringWriter() {
            _writer = new StringWriter();
        }
        public override Encoding Encoding {
            get { return _writer.Encoding; }
        public string ToHtmlString() {
            return _writer.ToString();
        public override string ToString() {
        public override void Write(string value) {
            _writer.Write(value);
        public override void Write(char value) {
    }
}
