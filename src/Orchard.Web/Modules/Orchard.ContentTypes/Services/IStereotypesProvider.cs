using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.ContentTypes.Services {
    public interface IStereotypesProvider : IDependency {
        IEnumerable<StereotypeDescription> GetStereotypes();
    }
    public class StereotypeDescription {
        public string Stereotype { get; set; }
        public string DisplayName { get; set; }
}
