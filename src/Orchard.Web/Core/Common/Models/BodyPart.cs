using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Core.Common.Settings;

namespace Orchard.Core.Common.Models {
    public class BodyPart : ContentPart<BodyPartRecord> {
        public string Text {
            get { return Retrieve(x => x.Text); }
            set { Store(x => x.Text, value); }
        }
        public string Format {
            get { return Retrieve(x => x.Format); }
            set { Store(x => x.Format, value); }
        public string GetFlavor() {
            var typePartSettings = Settings.GetModel<BodyTypePartSettings>();
            return string.IsNullOrWhiteSpace(typePartSettings?.Flavor)
                ? PartDefinition.Settings.GetModel<BodyPartSettings>().FlavorDefault
                : typePartSettings.Flavor;
    }
}
