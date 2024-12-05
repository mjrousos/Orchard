using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using Orchard.Projections.Descriptors.Property;

namespace Orchard.Projections.ViewModels {
    public class PropertyEditViewModel {
        public int Id { get; set; }
        public string Description { get; set; }
        public PropertyDescriptor Property { get; set; }
        public dynamic Form { get; set; }
        public bool ExcludeFromDisplay { get; set; }
        public bool LinkToContent { get; set; }
        // Label
        public bool CreateLabel { get; set; }
        [StringLength(255)]
        public string Label { get; set; }
        // Settings
        public bool CustomizePropertyHtml { get; set; }
        [StringLength(64)]
        public string CustomPropertyTag { get; set; }
        public string CustomPropertyCss { get; set; }
        public bool CustomizeLabelHtml { get; set; }
        public string CustomLabelTag { get; set; }
        public string CustomLabelCss { get; set; }
        public bool CustomizeWrapperHtml { get; set; }
        public string CustomWrapperTag { get; set; }
        public string CustomWrapperCss { get; set; }
        // No Result
        public string NoResultText { get; set; }
        public bool ZeroIsEmpty { get; set; }
        public bool HideEmpty { get; set; }
        public string RewriteOutputCondition { get; set; }
        public string RewriteText { get; set; }
        public bool StripHtmlTags { get; set; }
        public bool TrimLength { get; set; }
        public bool AddEllipsis { get; set; }
        public int MaxLength { get; set; }
        public bool TrimOnWordBoundary { get; set; }
        public bool PreserveLines { get; set; }
        public bool TrimWhiteSpace { get; set; }
    }
}
