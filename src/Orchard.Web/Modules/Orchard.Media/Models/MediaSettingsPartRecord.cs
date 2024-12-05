using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Records;

namespace Orchard.Media.Models {
    public class MediaSettingsPartRecord : ContentPartRecord {
        internal const string DefaultWhitelist = "jpg jpeg gif png txt doc docx xls xlsx pdf ppt pptx pps ppsx odt ods odp";
        private string _whitelist = DefaultWhitelist;
        [StringLength(255)]
        public virtual string UploadAllowedFileTypeWhitelist {
            get { return _whitelist; }
            set { _whitelist = value; }
        }
    }
}
