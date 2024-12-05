using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Microsoft.AspNetCore.Html;
using System.IO;
using System.Web.UI;

namespace System.Web
{
    public class MvcHtmlString : IHtmlString
    {
        private readonly string _value;

        public MvcHtmlString(string value)
        {
            _value = value ?? string.Empty;
        }

        public string ToHtmlString()
        {
            return _value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static MvcHtmlString Create(string value)
        {
            return new MvcHtmlString(value);
        }

        public static MvcHtmlString Empty
        {
            get { return new MvcHtmlString(string.Empty); }
        }
    }

    public class HtmlTextWriter : TextWriter
    {
        private readonly TextWriter _inner;

        public HtmlTextWriter(TextWriter writer)
        {
            _inner = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public override void Write(string value)
        {
            _inner.Write(value);
        }

        public override void WriteLine(string value)
        {
            _inner.WriteLine(value);
        }

        public override System.Text.Encoding Encoding => _inner.Encoding;

        protected override void Dispose(bool disposing)
        {
            if (disposing && _inner != null)
            {
                _inner.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
