using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Orchard.DisplayManagement.Shapes;

namespace Orchard.UI.Zones {
    /// <summary>
    /// Provides the behavior of shapes that have a Zones property.
    /// Examples include Layout and Item
    /// 
    /// * Returns a fake parent object for zones
    /// Foo.Zones 
    /// * 
    /// Foo.Zones.Alpha : 
    /// Foo.Zones["Alpha"] 
    /// Foo.Alpha :same
    /// </summary>
    public class ZoneHolding : Shape {
        private readonly Func<dynamic> _zoneFactory;
        public ZoneHolding(Func<dynamic> zoneFactory) {
            _zoneFactory = zoneFactory;
        }
        private Zones _zones;
        public Zones Zones {
            get {
                if (_zones == null) {
                    return _zones = new Zones(_zoneFactory, this);
                }
                return _zones;
            }
        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result) {
            var name = binder.Name;
            if (!base.TryGetMember(binder, out result) || (null == result)) {
                // substitute nil results with a robot that turns adds a zone on
                // the parent when .Add is invoked
                result = new ZoneOnDemand(_zoneFactory, this, name);
                TrySetMemberImpl(name, result);
            return true;
    }
    /// <remarks>
    /// InterfaceProxyBehavior()
    /// ZonesBehavior(_zoneFactory, self, _layoutShape) => Create ZoneOnDemand if member access
    /// </remarks>
    public class Zones : Composite {
        private readonly object _parent;
        public Zones(Func<dynamic> zoneFactory, object parent) {
            _parent = parent;
            return TryGetMemberImpl(binder.Name, out result);
        protected override bool TryGetMemberImpl(string name, out object result) {
            var parentMember = ((dynamic)_parent)[name];
            if (parentMember == null) {
                result = new ZoneOnDemand(_zoneFactory, _parent, name);
                return true;
            result = parentMember;
        public override bool TryGetIndex(System.Dynamic.GetIndexBinder binder, object[] indexes, out object result) {
            if (indexes.Count() == 1) {
                var key = Convert.ToString(indexes.Single());
                return TryGetMemberImpl(key, out result);
            return base.TryGetIndex(binder, indexes, out result);
    /// NilBehavior() => return Nil on GetMember and GetIndex in all cases
    /// ZoneOnDemandBehavior(_zoneFactory, _parent, name)  => when a zone (Shape) is 
    /// created, replace itself with the zone so that Layout.ZoneName is no more equal to Nil
    public class ZoneOnDemand : Shape {
        private readonly string _potentialZoneName;
        public ZoneOnDemand(Func<dynamic> zoneFactory, object parent, string potentialZoneName) {
            _potentialZoneName = potentialZoneName;
            // NilBehavior
            result = Nil.Instance;
        public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result) {
            if (!args.Any() && name != "ToString") {
                result = Nil.Instance;    
            
            return base.TryInvokeMember(binder, args, out result);
        public override string ToString() {
            return String.Empty;
        public override bool TryConvert(System.Dynamic.ConvertBinder binder, out object result) {
            if (binder.ReturnType == typeof (string)) {
                result = null;
            else if (binder.ReturnType.IsValueType) {
                result = Activator.CreateInstance(binder.ReturnType);
            else {
        public static bool operator ==(ZoneOnDemand a, object b) {
            // if ZoneOnDemand is compared to null it must return true
            return b == null || ReferenceEquals(b, Nil.Instance);
        public static bool operator !=(ZoneOnDemand a, object b) {
            return !(a == b);
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
            if (ReferenceEquals(this, obj)) {
            return false;
        public override int GetHashCode() {
            unchecked {
                int hashCode = (_parent != null ? _parent.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_potentialZoneName != null ? _potentialZoneName.GetHashCode() : 0);
                return hashCode;
        public override Shape Add(object item, string position = null) {
                if (item == null) {
                    return (Shape)_parent;
                dynamic parent = _parent;
                dynamic zone = _zoneFactory();
                zone.Parent = _parent;
                zone.ZoneName = _potentialZoneName;
                parent[_potentialZoneName] = zone;
                if (position == null) {
                    return zone.Add(item);
                return zone.Add(item, position);
}
