using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using FluentNHibernate.Conventions.Instances;

namespace Orchard.Data.Conventions {
    public class CascadeAllDeleteOrphanAttribute : Attribute {
    }
    public class CascadeAllDeleteOrphanConvention : 
        AttributeCollectionConvention<CascadeAllDeleteOrphanAttribute> {
        protected override void Apply(CascadeAllDeleteOrphanAttribute attribute, ICollectionInstance instance) {
            instance.Cascade.AllDeleteOrphan();
        }
}
