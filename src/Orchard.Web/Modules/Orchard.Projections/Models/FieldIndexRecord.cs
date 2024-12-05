using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Projections.Models {
    public abstract class FieldIndexRecord {
        public virtual int Id { get; set; }
        public virtual string PropertyName { get; set; }
    }

    public class StringFieldIndexRecord : FieldIndexRecord {
        public virtual string Value { get; set; }
        public virtual string LatestValue { get; set; }
    public class IntegerFieldIndexRecord : FieldIndexRecord {
        public virtual long? Value { get; set; }
        public virtual long? LatestValue { get; set; }
    public class DoubleFieldIndexRecord : FieldIndexRecord {
        public virtual double? Value { get; set; }
        public virtual double? LatestValue { get; set; }
    public class DecimalFieldIndexRecord : FieldIndexRecord {
        public virtual decimal? Value { get; set; }
        public virtual decimal? LatestValue { get; set; }
}
