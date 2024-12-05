using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.ImportExport.ViewModels {
    public class UploadRecipeViewModel {
        public UploadRecipeViewModel() {
            RecipeExecutionSteps = new List<RecipeExecutionStepViewModel>();
        }
        public bool ResetSite { get; set; }
        public string SuperUserName { get; set; }
        public string SuperUserPassword { get; set; }
        public string SuperUserPasswordConfirmation { get; set; }
        public IList<RecipeExecutionStepViewModel> RecipeExecutionSteps { get; set; }
    }
}
