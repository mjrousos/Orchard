using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Xml.Linq;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.ContentManagement.MetaData {
    public interface IContentDefinitionReader : IDependency {
        void Merge(XElement source, ContentTypeDefinitionBuilder builder);
        void Merge(XElement source, ContentPartDefinitionBuilder builder);
    }
    public static class ContentDefinitionReaderExtensions {
        public static ContentTypeDefinition Import(this IContentDefinitionReader reader, XElement source) {
            var target = new ContentTypeDefinitionBuilder();
            reader.Merge(source, target);
            return target.Build();
        }
}
