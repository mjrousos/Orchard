using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.IO;
using ImageResizer;
using Orchard.Forms.Services;
using Orchard.MediaProcessing.Descriptors.Filter;
using Orchard.MediaProcessing.Services;

namespace Orchard.MediaProcessing.Providers.Filters {
    public class FormatFilter : IImageFilterProvider {
        public FormatFilter() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public void Describe(DescribeFilterContext describe) {
            describe.For("Transform", T("Transform"), T("Transform"))
                .Element("Format", T("Format"), T("Change the format of the image."),
                         ApplyFilter,
                         DisplayFilter,
                         "FormatFilter"
                );
        public void ApplyFilter(FilterContext context) {
            string format = context.State.Format;
            int quality = context.State.Quality;
            var settings = new ResizeSettings {
                Quality = quality,
                Format = format
            };
            var result = new MemoryStream();
            if (context.Media.CanSeek) {
                context.Media.Seek(0, SeekOrigin.Begin);
            }
            
            ImageBuilder.Current.Build(context.Media, result, settings);
            context.FilePath = Path.ChangeExtension(context.FilePath, format);
            context.Media = result;
        public LocalizedString DisplayFilter(FilterContext context) {
            return T("Format the image to {0}", (string)context.State.Format);
    }
    public class FormatFilterForms : IFormProvider {
        protected dynamic Shape { get; set; }
        public FormatFilterForms(
            IShapeFactory shapeFactory) {
            Shape = shapeFactory;
        public void Describe(DescribeContext context) {
            Func<IShapeFactory, object> form =
                shape => {
                    var f = Shape.Form(
                        Id: "FormatFilter",
                        _Format: Shape.SelectList(
                            Id: "format", Name: "Format",
                            Title: T("Format"),
                            Description: T("The target format of the image."),
                            Size: 1,
                            Multiple: false),
                        _Quality: Shape.Textbox(
                            Id: "quality", Name: "Quality",
                            Title: T("Quality"),
                            Value: 90,
                            Description: T("JPeg compression quality, from 0 to 100."),
                            Classes: new[] { "text small" })
                        );
                    f._Format.Add(new SelectListItem { Value = "jpg", Text = T("Jpeg").Text });
                    f._Format.Add(new SelectListItem { Value = "gif", Text = T("Gif").Text });
                    f._Format.Add(new SelectListItem { Value = "png", Text = T("Png").Text });
                    return f;
                };
            context.Form("FormatFilter", form);
}
