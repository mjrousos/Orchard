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
using System.Web;
using Orchard.Projections.ModelBinding;

namespace Orchard.Projections.PropertyEditors {
    public class DefaultPropertyFormater : IPropertyFormater {
        private readonly IShapeFactory _shapeFactory;
        private readonly IEnumerable<IPropertyEditor> _propertyEditors;
        public DefaultPropertyFormater(
            IShapeFactory shapeFactory,
            IEnumerable<IPropertyEditor> propertyEditors) {
            _shapeFactory = shapeFactory;
            _propertyEditors = propertyEditors;
            
        }
        public string GetForm(Type type) {
            var propertyEditor = GetPropertyEditor(type);
            if(propertyEditor == null) {
                return null;
            }
            return propertyEditor.FormName;
        public dynamic Format(Type type, object value, dynamic formState) {
            if (propertyEditor == null) {
                var stringValue = Convert.ToString(value);
                if (String.IsNullOrEmpty(stringValue)) {
                    return String.Empty;
                }
                return new HtmlString(stringValue);
            return propertyEditor.Format(_shapeFactory, value, formState);
        private IPropertyEditor GetPropertyEditor(Type type) {
            return _propertyEditors.FirstOrDefault(x => x.CanHandle(type));
    }
}
