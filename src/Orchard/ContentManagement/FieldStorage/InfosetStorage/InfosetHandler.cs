using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;

namespace Orchard.ContentManagement.FieldStorage.InfosetStorage {
    public class InfosetHandler : ContentHandlerBase {
        public override void Activating(ActivatingContentContext context) {
            context.Builder.Weld<InfosetPart>();
        }
        public override void Creating(CreateContentContext context) {
            var infosetPart = context.ContentItem.As<InfosetPart>();
            if (infosetPart != null) {
                context.ContentItemRecord.Data = infosetPart.Infoset.Data;
                context.ContentItemVersionRecord.Data = infosetPart.VersionInfoset.Data;
                infosetPart.Infoset = context.ContentItemRecord.Infoset;
                infosetPart.VersionInfoset = context.ContentItemVersionRecord.Infoset;
            }
        public override void Loading(LoadContentContext context) {
        public override void Versioning(VersionContentContext context) {
            var infosetPart = context.BuildingContentItem.As<InfosetPart>();
                infosetPart.VersionInfoset = context.BuildingItemVersionRecord.Infoset;
    }
}
