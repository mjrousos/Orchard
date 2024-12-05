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
using Orchard.DisplayManagement.Descriptors.ShapeTemplateStrategy;

namespace Orchard.Tests.DisplayManagement.Descriptors {
    [TestFixture]
    public class BasicShapeTemplateHarvesterTests {
        private static void VerifyShapeType(string givenSubPath, string givenFileName, string expectedShapeType) {
            var harvester = new BasicShapeTemplateHarvester();
            var harvestShapeHits = harvester.HarvestShape(new HarvestShapeInfo { SubPath = givenSubPath, FileName = givenFileName });
            Assert.That(harvestShapeHits.Count(), Is.EqualTo(1));
            Assert.That(harvestShapeHits.Single().ShapeType, Is.EqualTo(expectedShapeType).IgnoreCase);
        }
        [Test]
        public void BasicFileNamesComeBackAsShapes() {
            VerifyShapeType("Views", "Hello", "Hello");
            VerifyShapeType("Views", "World", "World");
        public void DashBecomesBreakingSeperator() {
            VerifyShapeType("Views", "Hello-World", "Hello__World");
        public void DotBecomesNonBreakingSeperator() {
            VerifyShapeType("Views", "Hello.World", "Hello_World");
        public void DefaultItemsContentTemplate() {
            VerifyShapeType("Views/Items", "Content", "Content");
        public void ImplicitSpecializationOfItemsContentTemplate() {
            VerifyShapeType("Views/Items", "MyType", "MyType");
        public void ExplicitSpecializationOfItemsContentTemplate() {
            VerifyShapeType("Views/Items", "Content-MyType", "Content__MyType");
        public void ContentItemDisplayTypes() {
            VerifyShapeType("Views/Items", "Content.Summary", "Content_Summary");
            VerifyShapeType("Views/Items", "Content.Edit", "Content_Edit");
        public void ExplicitSpecializationMixedWithDisplayTypes() {
            VerifyShapeType("Views/Items", "Content-MyType.Summary", "Content_Summary__MyType");
            VerifyShapeType("Views/Items", "Content-MyType.Edit", "Content_Edit__MyType");
        public void DefaultItemsContentTemplate2() {
            VerifyShapeType("Views", "Content", "Content");
        public void ImplicitSpecializationOfItemsContentTemplate2() {
            VerifyShapeType("Views", "MyType", "MyType");
        public void ExplicitSpecializationOfItemsContentTemplate2() {
            VerifyShapeType("Views", "Content-MyType", "Content__MyType");
        public void ContentItemDisplayTypes2() {
            VerifyShapeType("Views", "Content.Summary", "Content_Summary");
            VerifyShapeType("Views", "Content.Edit", "Content_Edit");
        public void ExplicitSpecializationMixedWithDisplayTypes2() {
            VerifyShapeType("Views", "Content-MyType.Summary", "Content_Summary__MyType");
            VerifyShapeType("Views", "Content-MyType.Edit", "Content_Edit__MyType");
        public void MultipleDotsAreNormalizedToUnderscore() {
            VerifyShapeType("Views/Parts", "Common.Body", "Parts_Common_Body");
            VerifyShapeType("Views/Parts", "Common.Body.Summary", "Parts_Common_Body_Summary");
            VerifyShapeType("Views/Parts", "Localization.ContentTranslations.Summary", "Parts_Localization_ContentTranslations_Summary");
        public void MultipleDotsAreNormalizedToUnderscore2() {
            VerifyShapeType("Views", "Parts.Common.Body", "Parts_Common_Body");
            VerifyShapeType("Views", "Parts.Common.Body.Summary", "Parts_Common_Body_Summary");
            VerifyShapeType("Views", "Parts.Localization.ContentTranslations.Summary", "Parts_Localization_ContentTranslations_Summary");
        public void FieldNamesMayBeInSubfolderOrPrefixed() {
            VerifyShapeType("Views/Fields", "Common.Text", "Fields_Common_Text");
            VerifyShapeType("Views", "Fields.Common.Text", "Fields_Common_Text");
        public void FieldNamesMayHaveLongOrShortAlternates() {
            VerifyShapeType("Views/Fields", "Common.Text-FirstName", "Fields_Common_Text__FirstName");
            VerifyShapeType("Views/Fields", "Common.Text-FirstName.SpecialCase", "Fields_Common_Text_SpecialCase__FirstName");
            VerifyShapeType("Views/Fields", "Common.Text-FirstName-MyContentType", "Fields_Common_Text__FirstName__MyContentType");
            VerifyShapeType("Views", "Fields.Common.Text-FirstName", "Fields_Common_Text__FirstName");
            VerifyShapeType("Views", "Fields.Common.Text-FirstName.SpecialCase", "Fields_Common_Text_SpecialCase__FirstName");
            VerifyShapeType("Views", "Fields.Common.Text-FirstName-MyContentType", "Fields_Common_Text__FirstName__MyContentType");
    }
}
