using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using Orchard.DisplayManagement.Shapes;

namespace Orchard.MediaLibrary.MediaFileName
{
    public class MediaFileNameEditorViewModel : Shape {
        [Required]
        public string FileName { get; set; }
    }
}
