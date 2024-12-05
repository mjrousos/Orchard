using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;

namespace Orchard.Widgets.Models {
    public class LayerPart : ContentPart<LayerPartRecord> {
        
        /// <summary>
        /// The layer's name.
        /// </summary>
        [Required]
        public string Name {
            get { return Retrieve(x => x.Name); }
            set { Store(x => x.Name, value); }
        }
        /// The layer's description.
        public string Description {
            get { return Retrieve(x => x.Description); }
            set { Store(x => x.Description, value); }
        /// The layer's rule. 
        /// The rule defines when the layer is active (should or not be displayed).
        public string LayerRule {
            get { return Retrieve(x => x.LayerRule); }
            set { Store(x => x.LayerRule, value); }
        public static string AllLayersCacheEvictSignal =
            "LayerPart_AllLayers_EvictCache";
        public static string AllLayersCacheKey =
            "LayerPart_AllLayers_CacheKey";
    }
}
