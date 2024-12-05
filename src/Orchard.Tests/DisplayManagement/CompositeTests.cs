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
    public class CompositeTests {
        [Test]
        public void CompositesShouldNotOverrideExistingMembers() {
            var composite = new Animal {Color = "Pink"};
            Assert.That(composite.Color, Is.EqualTo("Pink"));
        }
        public void CompositesShouldNotOverrideExistingMembersWhenUsedAsDynamic() {
            dynamic composite = new Animal();
            composite.Color = "Pink";
        public void CompositesShouldAccessUnknownProperties() {
            composite.Fake = 42;
            Assert.That(composite.Fake, Is.EqualTo(42));
        public void CompositesShouldAccessUnknownPropertiesByIndex() {
            composite["Fake"] = 42;
            Assert.That(composite["Fake"], Is.EqualTo(42));
        public void CompositesShouldAccessKnownPropertiesByIndex() {
            composite["Pink"] = "Pink";
            Assert.That(composite["Pink"], Is.EqualTo("Pink"));
        public void ChainProperties() {
            dynamic foo = new Animal();
            foo.Bar("bar");
            Assert.That(foo.Bar, Is.EqualTo("bar"));
            Assert.That(foo.Bar == null, Is.False);
        public void DuckTyping() {
            foo.Size(42);
            ISized sized = foo;
            
            Assert.That(sized.Size, Is.EqualTo(42));
    }
    public class Animal : Composite {
        public string Kind { get; set; }
        public string Color { get; set; }
    public interface ISized {
        int Size { get; set; }
}
