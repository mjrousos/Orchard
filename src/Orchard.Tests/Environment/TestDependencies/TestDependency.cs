using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Tests.Environment.TestDependencies {
    
    public interface ITestDependency : IDependency {
        
    }

    public class TestDependency : ITestDependency{
    public interface ITestSingletonDependency : ISingletonDependency {
    public class TestSingletonDependency : ITestSingletonDependency {
    public interface ITestTransientDependency : ITransientDependency {
    public class TestTransientDependency : ITestTransientDependency {
}
