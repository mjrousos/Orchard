using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Orchard.Security
{
    public interface IAuthorizationService
    {
        bool TryCheckAccess(Permission permission, ClaimsPrincipal user, object resource);
    }

    public class Permission
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IEnumerable<Permission> ImpliedBy { get; set; }
    }

    public class AuthorizationServiceAdapter : IAuthorizationService
    {
        private readonly Microsoft.AspNetCore.Authorization.IAuthorizationService _authorizationService;

        public AuthorizationServiceAdapter(Microsoft.AspNetCore.Authorization.IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public bool TryCheckAccess(Permission permission, ClaimsPrincipal user, object resource)
        {
            var result = _authorizationService.AuthorizeAsync(user, resource, permission.Name).Result;
            return result.Succeeded;
        }
    }
}

namespace Orchard.ContentManagement.MetaData.Builders
{
    public class ContentTypePartDefinitionBuilder
    {
        private readonly string _name;
        private readonly Dictionary<string, string> _settings;

        public ContentTypePartDefinitionBuilder(string name)
        {
            _name = name;
            _settings = new Dictionary<string, string>();
        }

        public ContentTypePartDefinitionBuilder WithSetting(string name, string value)
        {
            _settings[name] = value;
            return this;
        }

        public string Name => _name;
        public IDictionary<string, string> Settings => _settings;
    }

    public class ContentPartDefinitionBuilder
    {
        public ContentPartDefinitionBuilder(string name) { }
        public ContentPartDefinitionBuilder WithSetting(string name, string value) { return this; }
    }
}

namespace Orchard.UI.Admin
{
    public interface IUpdateModel
    {
        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
        void AddModelError(string key, string errorMessage);
    }

    public class TemplateViewModel
    {
        public string DisplayName { get; set; }
    }
}
