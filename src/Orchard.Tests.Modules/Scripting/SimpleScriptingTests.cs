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
using Orchard.Scripting;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.Modules.Scripting {
    [TestFixture]
    public class SimpleScriptingTests {
        [Test]
        public void EngineThrowsSyntaxErrors() {
            var engine = new ScriptExpressionEvaluator(new StubCacheManager());
            Assert.That(() => engine.Evaluate("true+", Enumerable.Empty<IGlobalMethodProvider>()), Throws.Exception);
        }
        public void EngineUnderstandsPrimitiveValues() {
            Assert.That(engine.Evaluate("true", Enumerable.Empty<IGlobalMethodProvider>()), Is.True);
        public void EngineUnderstandsPrimitiveValues2() {
            Assert.That(engine.Evaluate("true and true", Enumerable.Empty<IGlobalMethodProvider>()), Is.True);
    }
}
