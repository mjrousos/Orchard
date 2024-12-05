using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;

namespace Orchard.MediaProcessing.Descriptors.Filter {
    public class FilterContext {
        public dynamic State { get; set; }
        public Stream Media { get; set; }
        public string FilePath { get; set; }
        /// <summary>
        /// Whether the module should save the altered image or not. 
        /// For instance if a filter saves the media then it should set it to<value>False</value>.
        /// </summary>
        public bool Saved { get; set; }
    }
}
