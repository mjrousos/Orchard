using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Framework.Elements;
using Orchard.Layouts.Models;

namespace Orchard.Layouts.Services {
    public interface ILayoutManager : IDependency {
        /// <summary>
        /// Returns all content items with a LayoutPart whose IsTemplate setting is set to true.
        /// </summary>
        IEnumerable<LayoutPart> GetTemplates();
        /// Returns all content items with a LayoutPart.
        IEnumerable<LayoutPart> GetLayouts();
        LayoutPart GetLayout(int id);
        IEnumerable<Element> LoadElements(ILayoutAspect layout);
        /// Renders the specified layout Data into a shape tree.
        /// <param name="data">The layout Data.</param>
        /// <param name="displayType">Optional. The display type to use when rendering the elements.</param>
        /// <param name="content">Optional. Provides additional context to the elements being loaded and rendered.</param>
        /// <returns>A shape representing the layout to be rendered.</returns>
        dynamic RenderLayout(string data, string displayType = null, IContent content = null);
        /// Updates the specified layout with the specified template layout.
        /// <returns>Returns the merged layout Data.</returns>
        IEnumerable<Element> ApplyTemplate(LayoutPart layout, LayoutPart templateLayout);
        /// Updates the specified layout with its selected template layout.
        IEnumerable<Element> ApplyTemplate(LayoutPart layout);
        IEnumerable<Element> ApplyTemplate(IEnumerable<Element> layout, IEnumerable<Element> templateLayout);
        
        /// Updates the specified layout by unmarking all templated elements so that they become normal elements again.
        IEnumerable<Element> DetachTemplate(IEnumerable<Element> elements);
        IEnumerable<LayoutPart> GetTemplateClients(int templateId, VersionOptions versionOptions);
        IEnumerable<Element> CreateDefaultLayout();
        void Exporting(ExportLayoutContext context);
        void Exported(ExportLayoutContext context);
        void Importing(ImportLayoutContext context);
        void Imported(ImportLayoutContext context);
        void ImportCompleted(ImportLayoutContext context);
    }
}
