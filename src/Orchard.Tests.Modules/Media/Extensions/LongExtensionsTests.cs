using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Globalization;
using NUnit.Framework;
using Orchard.Media.Extensions;

namespace Orchard.Tests.Modules.Media.Extensions {
    [TestFixture]
    public class LongExtensionsTests {
        [Test]
        public void BytesAreFriendly() {
            long size = 123;
            string friendly = size.ToFriendlySizeString();
            Assert.That(friendly, Is.EqualTo("123 B"));
        }
        public void KilobytesAreFriendly() {
            long size = 93845;
            Assert.That(friendly, Is.EqualTo("92 KB"));
        public void MegabytesAreFriendly() {
            long size = 6593528;
            Assert.That(friendly, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == "." ?
                Is.EqualTo("6.3 MB") :
                Is.EqualTo("6,3 MB"));
        public void GigabytesAreFriendly() {
            long size = 46896534657;
            Assert.That(friendly, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == "." ? 
                Is.EqualTo("43.68 GB") : 
                Is.EqualTo("43,68 GB"));
        public void TerabytesAreFriendly() {
            long size = 386594723458690;
                Is.EqualTo("351.606 TB") :
                Is.EqualTo("351,606 TB"));
        public void PetabytesAreSlightlyFriendlyAsTerabytes() {
            long size = 56794738495678965;
                Is.EqualTo("51654.514 TB") :
                Is.EqualTo("51654,514 TB"));
        public void VeryLargeSizeDoesNotCauseFailure() {
            long size = 5679473849567896593;
                Is.EqualTo("5165451.375 TB") :
                Is.EqualTo("5165451,375 TB"));
        public void NegativeSizeDoesNotCauseFailure(){
            long size = -2598;
            Assert.That(friendly, Is.EqualTo("-2598 B"));
    }
}
