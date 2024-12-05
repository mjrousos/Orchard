using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Aspects;

namespace Orchard.Widgets.Models {
    public class WidgetPart : ContentPart<WidgetPartRecord>, ITitleAspect {
        /// <summary>
        /// The widget's title.
        /// </summary>
        public string Title {
            get { return Retrieve(x => x.Title); }
            set { Store(x => x.Title, value); }
        }
        /// The zone where the widget is to be displayed.
        [Required]
        public string Zone {
            get { return Retrieve(x => x.Zone); }
            set { Store(x => x.Zone, value); }
        /// Whether or not the Title should be rendered on the front-end.
        public bool RenderTitle {
            get { return Retrieve(x => x.RenderTitle); }
            set { Store(x => x.RenderTitle, value); }
        /// The widget's position within the zone.
        public string Position {
            get { return Retrieve(x => x.Position); }
            set { Store(x => x.Position, value); }
        /// The technical name of the widget.
        public string Name {
            get { return Retrieve(x => x.Name); }
            set { Store(x => x.Name, value); }
        /// The layerPart where the widget belongs.
        public LayerPart LayerPart {
            get { return this.As<ICommonPart>().Container.As<LayerPart>(); }
            set { this.As<ICommonPart>().Container = value; }
        /// The layerPart identifier.
        public int? LayerId {
            get {
                var layerPart = LayerPart;
                return layerPart != null ? layerPart.Id : default(int?);
            }
        /// The available page zones.
        [HiddenInput(DisplayValue = false)]
        public IEnumerable<string> AvailableZones { get; set; }
        /// The available layers.
        public IEnumerable<LayerPart> AvailableLayers { get; set; }
        /// Css classes for the widget.
        public string CssClasses {
            get { return this.Retrieve(x => x.CssClasses); }
            set { this.Store(x => x.CssClasses, value); }
    }
}
