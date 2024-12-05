using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Orchard.Environment.ShellBuilders.Models;

namespace Orchard.Data.Conventions {
    public class RecordTableNameConvention : IClassConvention {
        private readonly Dictionary<Type, RecordBlueprint> _descriptors;
        public RecordTableNameConvention(IEnumerable<RecordBlueprint> descriptors) {
            _descriptors = descriptors.ToDictionary(d => d.Type);
        }
        public void Apply(IClassInstance instance) {
            RecordBlueprint desc;
            if (_descriptors.TryGetValue(instance.EntityType, out desc)) {
                instance.Table(desc.TableName);
            }
    }
}
