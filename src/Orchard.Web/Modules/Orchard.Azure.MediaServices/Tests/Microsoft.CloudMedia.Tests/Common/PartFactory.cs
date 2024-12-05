using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Microsoft.CloudMedia.Tests.Common {
    public static class PartFactory {
        public static TPart CreatePart<TPart, TRecord>(int id = 1)
            where TPart : ContentPart<TRecord>, new()
            where TRecord : ContentPartRecord, new() {
            return new TPart {
                ContentItem = new ContentItem {
                    VersionRecord = new ContentItemVersionRecord {
                        ContentItemRecord = new ContentItemRecord {
                            Id = id,
                        },
                        Id = id
                    }
                },
                Record = new TRecord() {
                    Id = id
                }
            };
        }
    }
}
