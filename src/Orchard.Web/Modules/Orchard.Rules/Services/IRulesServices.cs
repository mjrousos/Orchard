using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Rules.Models;

namespace Orchard.Rules.Services {
    public interface IRulesServices : IDependency {
        RuleRecord CreateRule(string name);
        RuleRecord GetRule(int id);
        IEnumerable<RuleRecord> GetRules();
        void DeleteRule(int ruleId);
        void DeleteEvent(int eventId);
        void DeleteAction(int actionId);
        void MoveUp(int actionId);
        void MoveDown(int actionId);
    }
}
