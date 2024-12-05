using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NUnit.Framework;
using Orchard.DisplayManagement.Shapes;

namespace Orchard.Tests.DisplayManagement {
    [TestFixture]
    public class NilTests {
        [Test]
        public void NilShouldEqualToNull() {
            var nil = Nil.Instance;
            Assert.That(nil == null, Is.True);
            Assert.That(nil != null, Is.False);
            Assert.That(nil == Nil.Instance, Is.True);
            Assert.That(nil != Nil.Instance, Is.False);
        }
        public void NilShouldBeRecursive() {
            dynamic nil = Nil.Instance;
            Assert.That(nil.Foo == null, Is.True);
            Assert.That(nil.Foo.Bar == null, Is.True);
        public void CallingToStringOnNilShouldReturnEmpty() {
            Assert.That(nil.ToString(), Is.EqualTo(""));
        public void CallingToStringOnDynamicNilShouldReturnEmpty() {
            Assert.That(nil.Foo.Bar.ToString(), Is.EqualTo(""));
        public void ConvertingToStringShouldReturnNullString() {
            Assert.That((string)nil == null, Is.True);
    }
}
