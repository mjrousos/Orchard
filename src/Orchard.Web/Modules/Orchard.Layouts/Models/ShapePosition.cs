using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Layouts.Models {
    public class ShapePosition {
        public int Position { get; set; }
        public string Name { get; set; }
        public static readonly ShapePosition Empty = new ShapePosition();
        public static ShapePosition Parse(string text) {
            if(String.IsNullOrWhiteSpace(text))
                return Empty;
            var parts = text.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);
            var position = new ShapePosition();
            if (parts.Length > 0)
                position.Name = parts[0];
            if (parts.Length > 1) {
                position.Position = XmlHelper.Parse<int>(parts[1]);
            }
            return position;
        }
    }
}
