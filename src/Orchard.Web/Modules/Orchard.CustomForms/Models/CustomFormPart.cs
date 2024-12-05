using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Aspects;

namespace Orchard.CustomForms.Models {
    public class CustomFormPart : ContentPart<CustomFormPartRecord> {
        [Required]
        public string ContentType {
            get { return Record.ContentType; }
            set { Record.ContentType = value; }
        }
        public bool UseContentTypePermissions {
            get { return Record.UseContentTypePermissions; }
            set { Record.UseContentTypePermissions = value; }
        public bool SaveContentItem {
            get { return Record.SaveContentItem; }
            set { Record.SaveContentItem = value; }
        public bool SavePublishContentItem {
            get { return Record.SavePublishContentItem; }
            set { Record.SavePublishContentItem = value; }
        
        public bool CustomMessage {
            get { return Record.CustomMessage; }
            set { Record.CustomMessage = value; }
        public string Message {
            get { return Record.Message; }
            set { Record.Message = value; }
        public bool Redirect {
            get { return Record.Redirect; }
            set { Record.Redirect = value; }
        public string RedirectUrl {
            get { return Record.RedirectUrl; }
            set { Record.RedirectUrl = value; }
        public string SubmitButtonText {
            get { return Record.SubmitButtonText; }
            set { Record.SubmitButtonText = value; }
        public string PublishButtonText {
            get { return Record.PublishButtonText; }
            set { Record.PublishButtonText = value; }
        public string Title {
            get { return this.As<ITitleAspect>().Title;  }
    }
}
