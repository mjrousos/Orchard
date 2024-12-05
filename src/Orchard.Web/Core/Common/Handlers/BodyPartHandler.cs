using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Core.Common.Models;
using Orchard.Data;
using Orchard.ContentManagement.Handlers;

namespace Orchard.Core.Common.Handlers {
    public class BodyPartHandler : ContentHandler {       
        public BodyPartHandler(IRepository<BodyPartRecord> bodyRepository) {
            Filters.Add(StorageFilter.For(bodyRepository));
            OnIndexing<BodyPart>((context, bodyPart) => context.DocumentIndex
                                                                .Add("body", bodyPart.Record.Text).RemoveTags().Analyze()
                                                                .Add("format", bodyPart.Record.Format).Store());
        }
    }
}
