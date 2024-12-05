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
using Orchard.Localization.Models;

namespace Orchard.Tests.Localization {
    [TestFixture()]
    public class DateTimePartsTests {
        [Test]
        [Description("Equal instances return equality.")]
        public void EqualsTest01() {
            var target = new DateTimeParts(2014, 5, 31, 10, 0, 0, 0, DateTimeKind.Unspecified, offset: TimeSpan.Zero);
            var other = new DateTimeParts(2014, 5, 31, 10, 0, 0, 0, DateTimeKind.Unspecified, offset: TimeSpan.Zero);
            var result = target.Equals(other);
            Assert.IsTrue(result);
        }
        [Description("Different instances do not return equality.")]
        public void EqualsTest02() {
            var other = new DateTimeParts(2014, 5, 31, 10, 0, 0, 1, DateTimeKind.Unspecified, offset: TimeSpan.Zero);
            Assert.IsFalse(result);
    }
}
