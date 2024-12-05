using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Workflows.Models;

namespace Orchard.Workflows.Handlers {
    public class WorkflowHandler : ContentHandler {
        public WorkflowHandler(
            IRepository<WorkflowRecord> workflowRepository
            ) {
            // Delete any pending workflow related to a deleted content item
            OnRemoving<ContentPart>(
                (context, part) => {
                    var workflows = workflowRepository.Table.Where(x => x.ContentItemRecord == context.ContentItemRecord).ToList();
                    foreach (var item in workflows) {
                        workflowRepository.Delete(item);
                    }
                });
        }
    }
}
