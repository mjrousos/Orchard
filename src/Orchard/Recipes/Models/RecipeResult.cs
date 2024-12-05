using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;

namespace Orchard.Recipes.Models {
    public class RecipeResult {
        public string ExecutionId { get; set; }
        public IEnumerable<RecipeStepResult> Steps { get; set; }
        public bool IsCompleted {
            get {
                return Steps.All(s => s.IsCompleted);
            }
        }
        public bool IsSuccessful {
                return IsCompleted && Steps.All(s => s.IsSuccessful);
    }
}
