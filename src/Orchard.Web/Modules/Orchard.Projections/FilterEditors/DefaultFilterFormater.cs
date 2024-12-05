using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Orchard.Projections.FilterEditors {
    public class DefaultFilterFormater : IFilterCoordinator {
        private readonly IEnumerable<IFilterEditor> _filterEditors;
        public DefaultFilterFormater(IEnumerable<IFilterEditor> filterEditors) {
            _filterEditors = filterEditors;
        }
        public string GetForm(Type type) {
            var filterEditor = GetFilterEditor(type);
            if (filterEditor == null) {
                return null;
            }
            return filterEditor.FormName;
        public Action<IHqlExpressionFactory> Filter(Type type, string property, dynamic formState) {
                return x => { };
            return filterEditor.Filter(property, formState);
        public LocalizedString Display(Type type, string property, dynamic formState) {
                return new LocalizedString(property);
            return filterEditor.Display(property, formState);
        private IFilterEditor GetFilterEditor(Type type) {
            return _filterEditors.FirstOrDefault(x => x.CanHandle(type));
    }
}
