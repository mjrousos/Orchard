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

namespace Orchard.Core.Containers.Models {
    public class ContainerWidgetPart : ContentPart<ContainerWidgetPartRecord> {
    }
    public class ContainerWidgetPartRecord : ContentPartRecord {
        public virtual int ContainerId { get; set; }
        public virtual int PageSize { get; set; }
        public virtual string OrderByProperty { get; set; }
        public virtual int OrderByDirection { get; set; }
        public virtual bool ApplyFilter { get; set; }
        public virtual string FilterByProperty { get; set; }
        public virtual string FilterByOperator { get; set; }
        public virtual string FilterByValue { get; set; }
}
