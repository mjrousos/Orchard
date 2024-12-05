using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using NUnit.Framework;
using Orchard.DisplayManagement.Shapes;
using Orchard.UI.Zones;

namespace Orchard.Tests.DisplayManagement {
    [TestFixture]
    public class ZoneHoldingTests {
        [Test]
        public void ZonesShouldReturn() {
            Func<dynamic> factory = () => new Shape();
            var foo = new ZoneHolding(factory);
            Assert.That(foo.Zones, Is.InstanceOf<Zones>());
        }
        public void MemberShouldCreateAZone() {
            dynamic foo = new ZoneHolding(factory);
            Assert.That(foo.Header, Is.InstanceOf<ZoneOnDemand>());
        public void IndexShouldCreateAZone() {
            Assert.That(foo.Zones["Header"], Is.InstanceOf<ZoneOnDemand>());
        public void ZonesMemberShouldCreateAZone() {
            Assert.That(foo.Zones.Header, Is.InstanceOf<ZoneOnDemand>());
        public void ZonesShouldBeUnique() {
            var header = foo.Header;
            Assert.That(foo.Zones.Header, Is.EqualTo(header));
            Assert.That(foo.Zones["Header"], Is.EqualTo(header));
            Assert.That(foo.Header, Is.EqualTo(header));
        public void EmptyZonesShouldBeNull() {
            Assert.That(foo.Header == 1, Is.False);
            Assert.That(foo.Header != 1, Is.True);
            dynamic header = foo.Header;
            Assert.That(header == null, Is.True);
            Assert.That(header != null, Is.False);
            Assert.That(header == Nil.Instance, Is.True);
            Assert.That(header != Nil.Instance, Is.False);
        public void NoneEmptyZonesShouldNotBeNull() {
            Assert.That(foo.Header == null, Is.True);
            Assert.That(foo.Header != null, Is.False);
            foo.Header.Add("blah");
            Assert.That(foo.Header == null, Is.False);
            Assert.That(foo.Header != null, Is.True);
            Assert.That(foo.Header == Nil.Instance, Is.False);
            Assert.That(foo.Header != Nil.Instance, Is.True);
    }
}
