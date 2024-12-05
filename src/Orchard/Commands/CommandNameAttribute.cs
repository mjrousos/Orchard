using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Commands {
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandNameAttribute : Attribute {
        private readonly string _commandAlias;
        public CommandNameAttribute(string commandAlias) {
            _commandAlias = commandAlias;
        }
        public string Command {
            get { return _commandAlias; }
    }
    public class CommandHelpAttribute : Attribute {
        public CommandHelpAttribute(string text) {
            this.HelpText = text;
        public string HelpText { get; set; }
}
