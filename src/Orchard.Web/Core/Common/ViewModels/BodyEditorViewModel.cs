using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Core.Common.Models;

namespace Orchard.Core.Common.ViewModels {
    public class BodyEditorViewModel {
        public BodyPart BodyPart { get; set; }
        public string Text {
            get { return BodyPart.Text; }
            set { BodyPart.Text = value; }
        }
        public string Format {
            get { return BodyPart.Format; }
            set { BodyPart.Format = value; }
        public string EditorFlavor { get; set; }
        public string AddMediaPath { get; set; }
    }
}
