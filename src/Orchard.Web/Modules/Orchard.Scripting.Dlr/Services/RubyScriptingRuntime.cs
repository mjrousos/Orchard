using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using IronRuby;
using Microsoft.Scripting.Hosting;

namespace Orchard.Scripting.Dlr.Services {
    public class RubyScriptingRuntime : IScriptingRuntime {
        private readonly LanguageSetup _defaultLanguageSetup;
        private readonly ScriptRuntime _scriptingRuntime;
        public RubyScriptingRuntime() {
            _defaultLanguageSetup = Ruby.CreateRubySetup();
            var setup = new ScriptRuntimeSetup();
            setup.LanguageSetups.Add(_defaultLanguageSetup);
            _scriptingRuntime = new ScriptRuntime(setup);
        }
        public ScriptEngine GetDefaultEngine() {
            return _scriptingRuntime.GetEngineByTypeName(_defaultLanguageSetup.TypeName);
        public ScriptScope CreateScope() {
            return _scriptingRuntime.CreateScope();
        public dynamic ExecuteExpression(string expression, ScriptScope scope) {
            var engine = GetDefaultEngine();
            var source = engine.CreateScriptSourceFromString(expression);
            return source.Execute(scope);
        public void ExecuteFile(string fileName, ScriptScope scope) {
            engine.ExecuteFile(fileName, scope);
    }
}
