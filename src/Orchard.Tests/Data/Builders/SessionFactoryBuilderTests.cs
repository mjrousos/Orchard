using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NUnit.Framework;
using Orchard.Environment.ShellBuilders.Models;
using Orchard.Tests.Records;

namespace Orchard.Tests.Data.Builders {
    [TestFixture]
    public class SessionFactoryBuilderTests {
        [Test]
        public void SqlCeSchemaShouldBeGeneratedAndUsable() {
            var recordDescriptors = new[] {
                                              new RecordBlueprint {TableName = "Hello", Type = typeof (FooRecord)}
                                          };
            ProviderUtilities.RunWithSqlCe(recordDescriptors,
                sessionFactory => {
                    var session = sessionFactory.OpenSession();
                    var foo = new FooRecord { Name = "hi there" };
                    session.Save(foo);
                    session.Flush();
                    session.Close();
                    Assert.That(foo, Is.Not.EqualTo(0));
                });
        }
        public void SqlServerSchemaShouldBeGeneratedAndUsable() {
            ProviderUtilities.RunWithSqlServer(recordDescriptors,
    }
}
