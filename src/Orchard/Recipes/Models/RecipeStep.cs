using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Xml.Linq;

namespace Orchard.Recipes.Models {
    public class RecipeStep {
        public RecipeStep(string id, string recipeName, string name, XElement step) {
            Id = id;
            RecipeName = recipeName;
            Name = name;
            Step = step;
        }
        public string Id { get; set; }
        public string RecipeName { get; private set; }
        public string Name { get; private set; }
        public XElement Step { get; private set; }
    }
}
