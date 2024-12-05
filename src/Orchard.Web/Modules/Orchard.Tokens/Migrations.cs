using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Orchard.Tokens {
    [OrchardFeature("Orchard.Tokens.Feeds")]
    public class FeedsMigrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterPartDefinition("RssPart",
                cfg => cfg
                    .Attachable()
                    .WithDescription("Attach to a content type to provide custom values in RSS feeds.")
                );
            return 1;
        }
    }
}
