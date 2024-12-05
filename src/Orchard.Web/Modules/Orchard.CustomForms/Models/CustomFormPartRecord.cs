using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.CustomForms.Models {
    public class CustomFormPartRecord : ContentPartRecord {
        [StringLength(255)]
        public virtual string ContentType { get; set; }
        public virtual bool UseContentTypePermissions { get; set; }
        [StringLengthMax]
        public virtual string Message { get; set; }
        public virtual bool CustomMessage { get; set; }
        public virtual bool SaveContentItem { get; set; }
        public virtual bool SavePublishContentItem { get; set; }
        public virtual string RedirectUrl { get; set; }
        public virtual bool Redirect { get; set; }
        public virtual string SubmitButtonText { get; set; }
        public virtual string PublishButtonText { get; set; }
        
    }
}
