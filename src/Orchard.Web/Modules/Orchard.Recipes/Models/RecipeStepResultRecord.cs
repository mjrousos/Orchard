using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Recipes.Models {
    public class RecipeStepResultRecord {
        public virtual int Id { get; set; }
        public virtual string ExecutionId { get; set; }
        public virtual string RecipeName { get; set; }
        public virtual string StepId { get; set; }
        public virtual string StepName { get; set; }
        public virtual bool IsCompleted { get; set; }
        public virtual bool IsSuccessful { get; set; }
        public virtual string ErrorMessage { get; set; }
    }
}
