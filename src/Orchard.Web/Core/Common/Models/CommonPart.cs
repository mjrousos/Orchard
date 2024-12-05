using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Aspects;
using Orchard.ContentManagement.Utilities;

namespace Orchard.Core.Common.Models {
    public class CommonPart : ContentPart<CommonPartRecord>, ICommonPart {
        private readonly LazyField<IUser> _owner = new LazyField<IUser>();
        private readonly LazyField<IContent> _container = new LazyField<IContent>();
        public LazyField<IUser> OwnerField { get { return _owner; } }
        public LazyField<IContent> ContainerField { get { return _container; } }
        public IUser Owner {
            get { return _owner.Value; }
            set { _owner.Value = value; }
        }
        public IContent Container {
            get { return _container.Value; }
            set { _container.Value = value; }
        public DateTime? CreatedUtc {
            get { return Retrieve(x => x.CreatedUtc); }
            set { Store(x => x.CreatedUtc, value); }
        public DateTime? PublishedUtc {
            get { return Retrieve(x => x.PublishedUtc); }
            set { Store(x => x.PublishedUtc, value); }
        public DateTime? ModifiedUtc {
            get { return Retrieve(x => x.ModifiedUtc); }
            set { Store(x => x.ModifiedUtc, value); }
        CommonPartVersionRecord PartVersionRecord {
            get {
                var versionPart = this.As<ContentPart<CommonPartVersionRecord>>();
                return versionPart == null ? null : versionPart.Record;
            }
        public DateTime? VersionCreatedUtc {
                return PartVersionRecord == null ? CreatedUtc : PartVersionRecord.CreatedUtc;
            set {
                if (PartVersionRecord != null)
                    PartVersionRecord.CreatedUtc = value;
        public string VersionModifiedBy {
                return PartVersionRecord == null ? null : PartVersionRecord.ModifiedBy;
                    PartVersionRecord.ModifiedBy = value;
        public DateTime? VersionPublishedUtc {
                return PartVersionRecord == null ? PublishedUtc : PartVersionRecord.PublishedUtc;
                    PartVersionRecord.PublishedUtc = value;
        public DateTime? VersionModifiedUtc {
                return PartVersionRecord == null ? ModifiedUtc : PartVersionRecord.ModifiedUtc;
                    PartVersionRecord.ModifiedUtc = value;
    }
}
