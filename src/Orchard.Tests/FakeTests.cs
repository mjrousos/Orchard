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

namespace Orchard.Tests {
    [TestFixture]
    public class FakeTests {
        #region Setup/Teardown
        [SetUp]
        public void Init() {
            _x = 5;
        }
        #endregion
        private int _x;
        [Test]
        [ExpectedException(typeof (ApplicationException), ExpectedMessage = "Boom")]
        public void ExceptionsCanBeVerified() {
            throw new ApplicationException("Boom");
        public void TestShouldRunFromResharper() {
            Assert.That(_x, Is.EqualTo(5));
    }
}
