using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Core.Common.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Core.Common.Utilities;

namespace Orchard.Core.Common.DateEditor {
    public class DateEditorHandler : ContentHandler {
        public DateEditorHandler() {
            OnPublished<CommonPart>((context, part) => {
                var settings = part.TypePartDefinition.Settings.GetModel<DateEditorSettings>();
                if (!settings.ShowDateEditor) {
                    return;
                }
                var thisIsTheInitialVersionRecord = part.ContentItem.Version < 2;
                var theDatesHaveNotBeenModified = DateUtils.DatesAreEquivalent(part.CreatedUtc, part.VersionCreatedUtc);
                var theContentDateShouldBeUpdated = thisIsTheInitialVersionRecord && theDatesHaveNotBeenModified;
                if (theContentDateShouldBeUpdated) {
                    // "touch" CreatedUtc in ContentItemRecord
                    part.CreatedUtc = part.PublishedUtc;
            });
        }
    }
}
