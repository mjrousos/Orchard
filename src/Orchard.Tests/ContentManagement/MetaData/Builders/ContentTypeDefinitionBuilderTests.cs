using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using NUnit.Framework;
using Orchard.ContentManagement.MetaData.Builders;

namespace Orchard.Tests.ContentManagement.MetaData.Builders {
    [TestFixture]
    public class ContentTypeDefinitionBuilderTests {
        [Test]
        public void ContentTypeNameAndSettingsFromScratch() {
            var contentTypeDefinition = new ContentTypeDefinitionBuilder()
                .Named("alpha")
                .WithSetting("a", "1")
                .WithSetting("b", "2")
                .Build();
            Assert.That(contentTypeDefinition.Name, Is.EqualTo("alpha"));
            Assert.That(contentTypeDefinition.Settings.Count(), Is.EqualTo(2));
            Assert.That(contentTypeDefinition.Settings["a"], Is.EqualTo("1"));
            Assert.That(contentTypeDefinition.Settings["b"], Is.EqualTo("2"));
        }
        public void ContentRebuildWithoutModification() {
            var contentTypeDefinition1 = new ContentTypeDefinitionBuilder()
               .Named("alpha")
               .WithSetting("a", "1")
               .WithSetting("b", "2")
               .Build();
            var contentTypeDefinition2 = new ContentTypeDefinitionBuilder(contentTypeDefinition1)
            Assert.That(contentTypeDefinition1, Is.Not.SameAs(contentTypeDefinition2));
            Assert.That(contentTypeDefinition2.Name, Is.EqualTo("alpha"));
            Assert.That(contentTypeDefinition2.Settings.Count(), Is.EqualTo(2));
            Assert.That(contentTypeDefinition2.Settings["a"], Is.EqualTo("1"));
            Assert.That(contentTypeDefinition2.Settings["b"], Is.EqualTo("2"));
        public void ContentRebuildWithModification() {
                .Named("beta")
                .WithSetting("b", "22")
                .WithSetting("c", "3")
            Assert.That(contentTypeDefinition1.Name, Is.EqualTo("alpha"));
            Assert.That(contentTypeDefinition1.Settings.Count(), Is.EqualTo(2));
            Assert.That(contentTypeDefinition1.Settings["a"], Is.EqualTo("1"));
            Assert.That(contentTypeDefinition1.Settings["b"], Is.EqualTo("2"));
            Assert.That(contentTypeDefinition2.Name, Is.EqualTo("beta"));
            Assert.That(contentTypeDefinition2.Settings.Count(), Is.EqualTo(3));
            Assert.That(contentTypeDefinition2.Settings["b"], Is.EqualTo("22"));
            Assert.That(contentTypeDefinition2.Settings["c"], Is.EqualTo("3"));
        public void AddingPartWithSettings() {
                .WithPart("foo", pb => pb.WithSetting("x", "10").WithSetting("y", "11"))
            Assert.That(contentTypeDefinition.Parts.Count(), Is.EqualTo(1));
            Assert.That(contentTypeDefinition.Parts.Single().PartDefinition.Name, Is.EqualTo("foo"));
            Assert.That(contentTypeDefinition.Parts.Single().Settings.Count(), Is.EqualTo(2));
            Assert.That(contentTypeDefinition.Parts.Single().Settings["x"], Is.EqualTo("10"));
            Assert.That(contentTypeDefinition.Parts.Single().Settings["y"], Is.EqualTo("11"));
        public void CanAlterPartSettingsByNameDuringBuild() {
                .WithPart("foo", pb => pb.WithSetting("x", "10"))
                .WithPart("foo", pb => pb.WithSetting("y", "11"))
        public void CanAlterPartSettingsByNameDuringRebuild() {
                .WithPart("foo", pb => pb.WithSetting("x", "12").WithSetting("z", "13"))
            Assert.That(contentTypeDefinition1.Parts.Count(), Is.EqualTo(1));
            Assert.That(contentTypeDefinition1.Parts.Single().PartDefinition.Name, Is.EqualTo("foo"));
            Assert.That(contentTypeDefinition1.Parts.Single().Settings.Count(), Is.EqualTo(2));
            Assert.That(contentTypeDefinition1.Parts.Single().Settings["x"], Is.EqualTo("10"));
            Assert.That(contentTypeDefinition1.Parts.Single().Settings["y"], Is.EqualTo("11"));
            Assert.That(contentTypeDefinition2.Parts.Count(), Is.EqualTo(1));
            Assert.That(contentTypeDefinition2.Parts.Single().PartDefinition.Name, Is.EqualTo("foo"));
            Assert.That(contentTypeDefinition2.Parts.Single().Settings.Count(), Is.EqualTo(3));
            Assert.That(contentTypeDefinition2.Parts.Single().Settings["x"], Is.EqualTo("12"));
            Assert.That(contentTypeDefinition2.Parts.Single().Settings["y"], Is.EqualTo("11"));
            Assert.That(contentTypeDefinition2.Parts.Single().Settings["z"], Is.EqualTo("13"));
        [Test, IgnoreAttribute("Merging not yet implemented")]
        public void ContentMergeOverlaysSettings() {
            Assert.Fail();
    }
}
