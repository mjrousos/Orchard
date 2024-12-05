using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Taxonomies.Models {
    /// <summary>
    /// Contrary to what its named states, it's not a part
    /// but a DTO to carry over a TermPart and a Field name
    /// </summary>
    public class TermContentItemPart {
        public string Field { get; set; }
        public TermPart TermPart { get; set; }
    }
}
