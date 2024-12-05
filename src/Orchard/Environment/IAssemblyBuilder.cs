using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.CodeDom;
using System.Reflection;
using System.Web.Compilation;

namespace Orchard.Environment {
    public interface IAssemblyBuilder {
        void AddCodeCompileUnit(CodeCompileUnit compileUnit);
        void AddAssemblyReference(Assembly assembly);
    }
    public class AspNetAssemblyBuilder : IAssemblyBuilder {
        private readonly AssemblyBuilder _assemblyBuilder;
        private readonly BuildProvider _buildProvider;
        public AspNetAssemblyBuilder(AssemblyBuilder assemblyBuilder, BuildProvider buildProvider) {
            _assemblyBuilder = assemblyBuilder;
            _buildProvider = buildProvider;
        }
        public void AddCodeCompileUnit(CodeCompileUnit compileUnit) {
            _assemblyBuilder.AddCodeCompileUnit(_buildProvider, compileUnit);
        public void AddAssemblyReference(Assembly assembly) {
            _assemblyBuilder.AddAssemblyReference(assembly);
}
