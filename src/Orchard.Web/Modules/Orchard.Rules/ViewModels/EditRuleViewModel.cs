using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Rules.ViewModels {
    public class EditRuleViewModel {
        public int Id { get; set; }
        [Required, StringLength(1024)]
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public IEnumerable<EventEntry> Events { get; set; }
        public IEnumerable<ActionEntry> Actions { get; set; }
    }
    public class ActionEntry {
        public int ActionRecordId { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public LocalizedString DisplayText { get; set; }
    public class EventEntry {
        public int EventRecordId { get; set; }
}
