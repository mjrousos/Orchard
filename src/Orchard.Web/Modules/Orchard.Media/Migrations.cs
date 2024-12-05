using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Migration;
using Orchard.Media.Models;

namespace Orchard.Media {
    public class MediaDataMigration : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("MediaSettingsPartRecord", 
                table => table
                    .ContentPartRecord()
                    .Column<string>("UploadAllowedFileTypeWhitelist", c => c.WithDefault(MediaSettingsPartRecord.DefaultWhitelist).WithLength(255))
                );
            return 1;
        }
    }
}
