using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using Orchard.Users.Models;

namespace Orchard.Users.ViewModels {
    public class UserEditViewModel  {
        [Required]
        public string UserName {
            get { return User.As<UserPart>().UserName; }
            set { User.As<UserPart>().UserName = value; }
        }
        public string Email {
            get { return User.As<UserPart>().Email; }
            set { User.As<UserPart>().Email = value; }
        public bool ForcePasswordChange {
            get { return User.As<UserPart>().ForcePasswordChange; }
            set { User.As<UserPart>().ForcePasswordChange = value; }
        public IContent User { get; set; }
    }
}
