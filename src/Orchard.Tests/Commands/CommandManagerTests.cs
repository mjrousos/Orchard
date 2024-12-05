using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;
using Autofac;
using NUnit.Framework;
using Orchard.Commands;

namespace Orchard.Tests.Commands {
    [TestFixture]
    public class CommandManagerTests {
        private ICommandManager _manager;
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            builder.RegisterType<DefaultCommandManager>().As<ICommandManager>();
            builder.RegisterType<MyCommand>().As<ICommandHandler>();
            builder.RegisterModule(new CommandModule());
            var container = builder.Build();
            _manager = container.Resolve<ICommandManager>();
        }
        [Test]
        public void ManagerCanRunACommand() {
            var context = new CommandParameters { Arguments = new string[] { "FooBar" }, Output = new StringWriter()};
            _manager.Execute(context);
            Assert.That(context.Output.ToString(), Is.EqualTo("success!"));
        public void ManagerCanRunACompositeCommand() {
            var context = new CommandParameters { Arguments = ("Foo Bar Bleah").Split(' '), Output = new StringWriter() };
            Assert.That(context.Output.ToString(), Is.EqualTo("Bleah"));
        public class MyCommand : DefaultOrchardCommandHandler {
            public string FooBar() {
                return "success!";
            }
            public string Foo_Bar(string bleah) {
                return bleah;
    }
}
