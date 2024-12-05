using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Environment.Extensions;
using Orchard.Users.Services;
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace Orchard.Users.Activities {
    [OrchardFeature("Orchard.Users.Workflows")]
    public class VerifyUserUnicityActivity : Task {
        private readonly IUserService _userService;
        public VerifyUserUnicityActivity(IUserService userService) {
            _userService = userService;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public override string Name {
            get { return "VerifyUserUnicity"; }
        public override LocalizedString Category {
            get { return T("User"); }
        public override LocalizedString Description {
            get { return T("Verifies if the specified user name and email address are unique."); }
        public override string Form {
        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] {
                T("Unique"), 
                T("NotUnique")
            };
        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {
            var userName = activityContext.GetState<string>("UserName");
            var email = activityContext.GetState<string>("Email");
            if (_userService.VerifyUserUnicity(userName, email)) {
                yield return T("Unique");
            }
            else {
                yield return T("NotUnique");
    }
}
