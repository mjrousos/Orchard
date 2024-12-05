using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Orchard.Workflows.Activities;

namespace Orchard.Tests.Modules.Workflows.Activities {
    [TestFixture]
    public class WebRequestActivityTests {
        private readonly MethodInfo _parseKeyValueString = typeof(WebRequestActivity).GetMethod("ParseKeyValueString", BindingFlags.NonPublic | BindingFlags.Static);
        private IEnumerable<KeyValuePair<string, string>> ParseKeyValueString(string text) {
            return (IEnumerable<KeyValuePair<string, string>>)_parseKeyValueString.Invoke(null, new object[] { text });
        }
        [Test]
        public void ParseKeyValueStringShouldRecognizeNewLinePatterns() {
            Assert.That(ParseKeyValueString("a=b\nc=d\r\ne=f"), Is.EquivalentTo( new Dictionary<string, string> { {"a", "b"}, {"c", "d"}, {"e","f"}}));
        public void ParseKeyValueStringShouldIgnoreComments() {
            Assert.That(ParseKeyValueString("a=b\n#c=d\ne=f"), Is.EquivalentTo(new Dictionary<string, string> { { "a", "b" }, { "e", "f" } }));
        public void ParseKeyValueStringShouldIgnoreEmptyLines() {
            Assert.That(ParseKeyValueString("a=b\n\n\n\n\ne=f"), Is.EquivalentTo(new Dictionary<string, string> { { "a", "b" }, { "e", "f" } }));
        public void ParseKeyValueStringShouldIgnoreMalformedLines() {
            Assert.That(ParseKeyValueString("a=b\nc:d\ne=f"), Is.EquivalentTo(new Dictionary<string, string> { { "a", "b" }, { "e", "f" } }));
    }
}
