using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Moq;
using NHibernate;
using NUnit.Framework;
using Orchard.Caching;
using Orchard.ContentManagement.MetaData;
using Orchard.Data;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.Records;
using Orchard.Data.Providers;
using Orchard.DisplayManagement.Descriptors;
using Orchard.Environment.Configuration;
using Orchard.Environment.Extensions;
using Orchard.Tests.ContentManagement.Handlers;
using Orchard.Tests.ContentManagement.Records;
using Orchard.Tests.ContentManagement.Models;
using Orchard.DisplayManagement.Implementation;
using Orchard.Tests.Stubs;
using Orchard.UI.PageClass;

namespace Orchard.Tests.ContentManagement {
    [TestFixture]
    public class HqlExpressionTests {
        private IContainer _container;
        private IContentManager _manager;
        private ISessionFactory _sessionFactory;
        private ISession _session;
        [TestFixtureSetUp]
        public void InitFixture() {
            var databaseFileName = System.IO.Path.GetTempFileName();
            _sessionFactory = DataUtility.CreateSessionFactory(
                databaseFileName,
                typeof(GammaRecord),
                typeof(DeltaRecord),
                typeof(EpsilonRecord),
                typeof(LambdaRecord),
                typeof(ContentItemVersionRecord),
                typeof(ContentItemRecord),
                typeof(ContentTypeRecord));
        }
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ContentModule());
            builder.RegisterType<DefaultContentManager>().As<IContentManager>().SingleInstance();
            builder.RegisterType<StubCacheManager>().As<ICacheManager>();
            builder.RegisterType<Signals>().As<ISignals>();
            builder.RegisterType<DefaultContentManagerSession>().As<IContentManagerSession>();
            builder.RegisterInstance(new Mock<IContentDefinitionManager>().Object);
            builder.RegisterInstance(new Mock<IContentDisplay>().Object);
            builder.RegisterInstance(new ShellSettings { Name = ShellSettings.DefaultName, DataProvider = "SqlCe" });
            builder.RegisterType<SqlCeStatementProvider>().As<ISqlStatementProvider>();
            builder.RegisterType<MySqlStatementProvider>().As<ISqlStatementProvider>();
            builder.RegisterType<PostgreSqlStatementProvider>().As<ISqlStatementProvider>();
            builder.RegisterType<AlphaPartHandler>().As<IContentHandler>();
            builder.RegisterType<BetaPartHandler>().As<IContentHandler>();
            builder.RegisterType<GammaPartHandler>().As<IContentHandler>();
            builder.RegisterType<DeltaPartHandler>().As<IContentHandler>();
            builder.RegisterType<EpsilonPartHandler>().As<IContentHandler>();
            builder.RegisterType<LambdaPartHandler>().As<IContentHandler>();
            builder.RegisterType<FlavoredPartHandler>().As<IContentHandler>();
            builder.RegisterType<StyledHandler>().As<IContentHandler>();
            builder.RegisterType<DefaultShapeTableManager>().As<IShapeTableManager>();
            builder.RegisterType<ShapeTableLocator>().As<IShapeTableLocator>();
            builder.RegisterType<DefaultShapeFactory>().As<IShapeFactory>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<StubExtensionManager>().As<IExtensionManager>();
            builder.RegisterInstance(new Mock<IPageClassBuilder>().Object); 
            builder.RegisterType<DefaultContentDisplay>().As<IContentDisplay>();
            _session = _sessionFactory.OpenSession();
            builder.RegisterInstance(new TestTransactionManager(_session)).As<ITransactionManager>();
            _session.Delete(string.Format("from {0}", typeof(GammaRecord).FullName));
            _session.Delete(string.Format("from {0}", typeof(DeltaRecord).FullName));
            _session.Delete(string.Format("from {0}", typeof(EpsilonRecord).FullName));
            _session.Delete(string.Format("from {0}", typeof(LambdaRecord).FullName));
            
            _session.Delete(string.Format("from {0}", typeof(ContentItemVersionRecord).FullName));
            _session.Delete(string.Format("from {0}", typeof(ContentItemRecord).FullName));
            _session.Delete(string.Format("from {0}", typeof(ContentTypeRecord).FullName));
            _session.Flush();
            _session.Clear();
            _container = builder.Build();
            _manager = _container.Resolve<IContentManager>();
        [TearDown]
        public void Cleanup() {
            if (_container != null)
                _container.Dispose();
        [Test]
        public void AllDataTypesCanBeQueried() {
            var now = DateTime.Now;
            // NHibernate stores DateTime values with seconds-precision, so everything below that needs to be truncated
            // so that the query works correctly. Thanks to https://stackoverflow.com/a/1005222 for elegant solution.
            now = now.AddTicks(-(now.Ticks % TimeSpan.TicksPerSecond));
            _manager.Create<LambdaPart>("lambda", init => {
                init.Record.BooleanStuff = true;
                init.Record.DecimalStuff = 0;
                init.Record.DoubleStuff = 0;
                init.Record.FloatStuff = 0;
                init.Record.IntegerStuff = 0;
                init.Record.LongStuff = 0;
                init.Record.StringStuff = "0";
                init.Record.DateTimeStuff = now;
            });
            var lambda = _manager.HqlQuery().ForType("lambda").List();
            Assert.That(lambda.Count(), Is.EqualTo(1));
            lambda = _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), x => x.Eq("BooleanStuff", true)).List();
            lambda = _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), x => x.Eq("DecimalStuff", (decimal)0.0)).List();
            lambda = _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), x => x.Eq("DoubleStuff", 0.0)).List();
            lambda = _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), x => x.Eq("FloatStuff", (float)0.0)).List();
            lambda = _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), x => x.Eq("IntegerStuff", 0)).List();
            lambda = _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), x => x.Eq("LongStuff", (long)0)).List();
            lambda = _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), x => x.Eq("StringStuff", "0")).List();
            lambda = _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), x => x.Eq("DateTimeStuff", now)).List();
        public void ShouldQueryUsingOperatorLike() {
                init.Record.StringStuff = "abcdef";
            var result = _manager.HqlQuery().ForType("lambda").List();
            Assert.That(result.Count(), Is.EqualTo(1));
            Func<Action<IHqlExpressionFactory>, IEnumerable<ContentItem>> queryWhere = predicate => _manager.HqlQuery().Where(alias => alias.ContentPartRecord<LambdaRecord>(), predicate).List();
            result = queryWhere(x => x.Like("StringStuff", "bc", HqlMatchMode.Anywhere));
            result = queryWhere(x => x.Like("StringStuff", "bc'", HqlMatchMode.Anywhere));
            Assert.That(result.Count(), Is.EqualTo(0));
            result = queryWhere(x => x.Like("StringStuff", "ab", HqlMatchMode.Anywhere));
            result = queryWhere(x => x.Like("StringStuff", "ef", HqlMatchMode.Anywhere));
            result = queryWhere(x => x.Like("StringStuff", "gh", HqlMatchMode.Anywhere));
            result = queryWhere(x => x.Like("StringStuff", "ab", HqlMatchMode.Start));
            result = queryWhere(x => x.Like("StringStuff", "ef", HqlMatchMode.End));
            result = queryWhere(x => x.Like("StringStuff", "abcdef", HqlMatchMode.Exact));
            result = queryWhere(x => x.Like("StringStuff", "abcde", HqlMatchMode.Exact));
            // default collation in SQL Ce/Server but can be changed during db creation
            result = queryWhere(x => x.Like("StringStuff", "EF", HqlMatchMode.Anywhere));
        public void ShouldQueryUsingOperatorInsensitiveLike() {
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "bc", HqlMatchMode.Anywhere));
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "ab", HqlMatchMode.Anywhere));
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "ef", HqlMatchMode.Anywhere));
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "gh", HqlMatchMode.Anywhere));
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "ab", HqlMatchMode.Start));
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "ef", HqlMatchMode.End));
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "abcdef", HqlMatchMode.Exact));
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "abcde", HqlMatchMode.Exact));
            result = queryWhere(x => x.InsensitiveLike("StringStuff", "EF", HqlMatchMode.Anywhere));
        public void ShouldQueryUsingOperatorGt() {
            var dt = new DateTime(1980,1,1);
                init.Record.DateTimeStuff = dt;
            result = queryWhere(x => x.Gt("BooleanStuff", true));
            result = queryWhere(x => x.Gt("DecimalStuff", 0));
            result = queryWhere(x => x.Gt("DoubleStuff", 0));
            result = queryWhere(x => x.Gt("FloatStuff", 0));
            result = queryWhere(x => x.Gt("IntegerStuff", 0));
            result = queryWhere(x => x.Gt("LongStuff", 0));
            result = queryWhere(x => x.Gt("StringStuff", "0"));
            result = queryWhere(x => x.Gt("DateTimeStuff", dt));
            result = queryWhere(x => x.Gt("BooleanStuff", false));
            result = queryWhere(x => x.Gt("DecimalStuff", -1));
            result = queryWhere(x => x.Gt("DoubleStuff", -1));
            result = queryWhere(x => x.Gt("FloatStuff", -1));
            result = queryWhere(x => x.Gt("IntegerStuff", -1));
            result = queryWhere(x => x.Gt("LongStuff", -1));
            result = queryWhere(x => x.Gt("StringStuff", ""));
            result = queryWhere(x => x.Gt("DateTimeStuff", dt.AddDays(-1)));
        public void ShouldQueryUsingOperatorLt() {
            var dt = new DateTime(1980, 1, 1);
                init.Record.BooleanStuff = false;
            result = queryWhere(x => x.Lt("BooleanStuff", false));
            result = queryWhere(x => x.Lt("DecimalStuff", 0));
            result = queryWhere(x => x.Lt("DoubleStuff", 0));
            result = queryWhere(x => x.Lt("FloatStuff", 0));
            result = queryWhere(x => x.Lt("IntegerStuff", 0));
            result = queryWhere(x => x.Lt("LongStuff", 0));
            result = queryWhere(x => x.Lt("StringStuff", "0"));
            result = queryWhere(x => x.Lt("DateTimeStuff", dt));
            result = queryWhere(x => x.Lt("BooleanStuff", true));
            result = queryWhere(x => x.Lt("DecimalStuff", 1));
            result = queryWhere(x => x.Lt("DoubleStuff", 1));
            result = queryWhere(x => x.Lt("FloatStuff", 1));
            result = queryWhere(x => x.Lt("IntegerStuff", 1));
            result = queryWhere(x => x.Lt("LongStuff", 1));
            result = queryWhere(x => x.Lt("StringStuff", "00"));
            result = queryWhere(x => x.Lt("DateTimeStuff", dt.AddDays(1)));
        public void ShouldQueryUsingOperatorLe() {
            // equal
            result = queryWhere(x => x.Le("BooleanStuff", false));
            result = queryWhere(x => x.Le("DecimalStuff", 0));
            result = queryWhere(x => x.Le("DoubleStuff", 0));
            result = queryWhere(x => x.Le("FloatStuff", 0));
            result = queryWhere(x => x.Le("IntegerStuff", 0));
            result = queryWhere(x => x.Le("LongStuff", 0));
            result = queryWhere(x => x.Le("StringStuff", "0"));
            result = queryWhere(x => x.Le("DateTimeStuff", dt));
            // greater values
            result = queryWhere(x => x.Le("BooleanStuff", true));
            result = queryWhere(x => x.Le("DecimalStuff", 1));
            result = queryWhere(x => x.Le("DoubleStuff", 1));
            result = queryWhere(x => x.Le("FloatStuff", 1));
            result = queryWhere(x => x.Le("IntegerStuff", 1));
            result = queryWhere(x => x.Le("LongStuff", 1));
            result = queryWhere(x => x.Le("StringStuff", "00"));
            result = queryWhere(x => x.Le("DateTimeStuff", dt.AddDays(1)));
            // lower values
            result = queryWhere(x => x.Le("DecimalStuff", -1));
            result = queryWhere(x => x.Le("DoubleStuff", -1));
            result = queryWhere(x => x.Le("FloatStuff", -1));
            result = queryWhere(x => x.Le("IntegerStuff", -1));
            result = queryWhere(x => x.Le("LongStuff", -1));
            result = queryWhere(x => x.Le("StringStuff", ""));
            result = queryWhere(x => x.Le("DateTimeStuff", dt.AddDays(-1)));
        public void ShouldQueryUsingOperatorGe() {
            result = queryWhere(x => x.Ge("BooleanStuff", false));
            result = queryWhere(x => x.Ge("DecimalStuff", 0));
            result = queryWhere(x => x.Ge("DoubleStuff", 0));
            result = queryWhere(x => x.Ge("FloatStuff", 0));
            result = queryWhere(x => x.Ge("IntegerStuff", 0));
            result = queryWhere(x => x.Ge("LongStuff", 0));
            result = queryWhere(x => x.Ge("StringStuff", "0"));
            result = queryWhere(x => x.Ge("DateTimeStuff", dt));
            result = queryWhere(x => x.Ge("BooleanStuff", true));
            result = queryWhere(x => x.Ge("DecimalStuff", 1));
            result = queryWhere(x => x.Ge("DoubleStuff", 1));
            result = queryWhere(x => x.Ge("FloatStuff", 1));
            result = queryWhere(x => x.Ge("IntegerStuff", 1));
            result = queryWhere(x => x.Ge("LongStuff", 1));
            result = queryWhere(x => x.Ge("StringStuff", "00"));
            result = queryWhere(x => x.Ge("DateTimeStuff", dt.AddDays(1)));
            result = queryWhere(x => x.Ge("DecimalStuff", -1));
            result = queryWhere(x => x.Ge("DoubleStuff", -1));
            result = queryWhere(x => x.Ge("FloatStuff", -1));
            result = queryWhere(x => x.Ge("IntegerStuff", -1));
            result = queryWhere(x => x.Ge("LongStuff", -1));
            result = queryWhere(x => x.Ge("StringStuff", ""));
            result = queryWhere(x => x.Ge("DateTimeStuff", dt.AddDays(-1)));
        public void ShouldQueryUsingOperatorBetween() {
            // include
            result = queryWhere(x => x.Between("DecimalStuff", 0, 1));
            result = queryWhere(x => x.Between("DoubleStuff", 0, 1));
            result = queryWhere(x => x.Between("FloatStuff", 0, 1));
            result = queryWhere(x => x.Between("IntegerStuff", 0, 1));
            result = queryWhere(x => x.Between("LongStuff", 0, 1));
            result = queryWhere(x => x.Between("StringStuff", "0", "1"));
            result = queryWhere(x => x.Between("DateTimeStuff", dt, dt.AddDays(1)));
            // exclude
            result = queryWhere(x => x.Between("DecimalStuff", 1, 2));
            result = queryWhere(x => x.Between("DoubleStuff", 1, 2));
            result = queryWhere(x => x.Between("FloatStuff", 1, 2));
            result = queryWhere(x => x.Between("IntegerStuff", 1, 2));
            result = queryWhere(x => x.Between("LongStuff", 1, 2));
            result = queryWhere(x => x.Between("StringStuff", "1", "2"));
            result = queryWhere(x => x.Between("DateTimeStuff", dt.AddDays(1), dt.AddDays(2)));
        public void ShouldQueryUsingOperatorIn() {
            result = queryWhere(x => x.In("BooleanStuff", new[] { false }));
            result = queryWhere(x => x.In("DecimalStuff", new[] { 0, 1 }));
            result = queryWhere(x => x.In("DoubleStuff", new[] { 0, 1 }));
            result = queryWhere(x => x.In("FloatStuff", new[] { 0, 1 }));
            result = queryWhere(x => x.In("IntegerStuff", new[] { 0, 1 }));
            result = queryWhere(x => x.In("LongStuff", new[] { 0, 1 }));
            result = queryWhere(x => x.In("StringStuff", new[] { "0", "1" }));
            result = queryWhere(x => x.In("DateTimeStuff", new [] {dt, dt.AddDays(1)}));
            result = queryWhere(x => x.In("BooleanStuff", new[] { true }));
            result = queryWhere(x => x.In("DecimalStuff", new[] { 1, 2 }));
            result = queryWhere(x => x.In("DoubleStuff", new[] { 1, 2 }));
            result = queryWhere(x => x.In("FloatStuff", new[] { 1, 2 }));
            result = queryWhere(x => x.In("IntegerStuff", new[] { 1, 2 }));
            result = queryWhere(x => x.In("LongStuff", new[] { 1, 2 }));
            result = queryWhere(x => x.In("StringStuff", new[] { "1", "2" }));
            result = queryWhere(x => x.In("DateTimeStuff", new [] {dt.AddDays(1), dt.AddDays(2)}));
        public void ShouldQueryUsingOperatorIsNull() {
                init.Record.StringStuff = null;
            result = queryWhere(x => x.IsNull("BooleanStuff"));
            result = queryWhere(x => x.IsNull("StringStuff"));
        public void ShouldQueryUsingOperatorIsNotNull() {
            result = queryWhere(x => x.IsNotNull("BooleanStuff"));
            result = queryWhere(x => x.IsNotNull("StringStuff"));
        public void ShouldQueryUsingOperatorEqProperty() {
            result = queryWhere(x => x.EqProperty("BooleanStuff", "LongStuff"));
            result = queryWhere(x => x.EqProperty("DateTimeStuff", "LongStuff"));
        public void ShouldQueryUsingOperatorNotEqProperty() {
            result = queryWhere(x => x.NotEqProperty("BooleanStuff", "LongStuff"));
            result = queryWhere(x => x.NotEqProperty("DateTimeStuff", "LongStuff"));
        public void ShouldQueryUsingOperatorGtProperty() {
                init.Record.IntegerStuff = 1;
                init.Record.LongStuff = 2;
            // equal 
            result = queryWhere(x => x.GtProperty("DoubleStuff", "FloatStuff"));
            // lesser
            result = queryWhere(x => x.GtProperty("FloatStuff", "IntegerStuff"));
            // greater
            result = queryWhere(x => x.GtProperty("IntegerStuff", "FloatStuff"));
        public void ShouldQueryUsingOperatorGeProperty() {
            result = queryWhere(x => x.GeProperty("DoubleStuff", "FloatStuff"));
            result = queryWhere(x => x.GeProperty("FloatStuff", "IntegerStuff"));
            result = queryWhere(x => x.GeProperty("IntegerStuff", "FloatStuff"));
        public void ShouldQueryUsingOperatorLeProperty() {
            result = queryWhere(x => x.LeProperty("DoubleStuff", "FloatStuff"));
            result = queryWhere(x => x.LeProperty("FloatStuff", "IntegerStuff"));
            result = queryWhere(x => x.LeProperty("IntegerStuff", "FloatStuff"));
        public void ShouldQueryUsingOperatorLtProperty() {
            result = queryWhere(x => x.LtProperty("DoubleStuff", "FloatStuff"));
            result = queryWhere(x => x.LtProperty("FloatStuff", "IntegerStuff"));
            result = queryWhere(x => x.LtProperty("IntegerStuff", "FloatStuff"));
        // This is a potentially flaky test, but failure due to randomness is extremely unlikely.
        public void ShouldSortRandomly() {
            var itemCount = 10;
            for (int i = 0; i < itemCount; i++) {
                _manager.Create<LambdaPart>("lambda", init => {
                    init.Record.IntegerStuff = i;
                });
            }
            var items = _manager.HqlQuery().ForType("lambda").List();
            Assert.That(items.Count(), Is.EqualTo(itemCount));
            var results = new List<string>();
            for (int i = 0; i < 10; i++) {
                items = _manager.HqlQuery().Join(alias =>
                    alias.ContentPartRecord<LambdaRecord>()).OrderBy(x => x.Named("civ"), order => order.Random()).List();
                results.Add(string.Join("", items.Select(item => item.As<LambdaPart>().Record.IntegerStuff)));
            Assert.That(results.Distinct().Count(), Is.GreaterThan(1));
        public void ShouldPageResults() {
                init.Record.IntegerStuff = 2;
                init.Record.IntegerStuff = 3;
            var results = _manager.HqlQuery().Join(alias => alias.ContentPartRecord<LambdaRecord>()).OrderBy(x => x.ContentPartRecord<LambdaRecord>(), order => order.Asc("IntegerStuff")).Slice(1,1);
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(results.Single().As<LambdaPart>().Record.IntegerStuff, Is.EqualTo(2));
        public void ShouldSortByProperty() {
            var results =_manager.HqlQuery().Join(alias => alias.ContentPartRecord<LambdaRecord>()).OrderBy(x => x.ContentPartRecord<LambdaRecord>(), order => order.Asc("IntegerStuff")).List();
            Assert.That(results.Count(), Is.EqualTo(3));
            Assert.That(results.Skip(0).First().As<LambdaPart>().Record.IntegerStuff, Is.EqualTo(1));
            Assert.That(results.Skip(1).First().As<LambdaPart>().Record.IntegerStuff, Is.EqualTo(2));
            Assert.That(results.Skip(2).First().As<LambdaPart>().Record.IntegerStuff, Is.EqualTo(3));
        public void ShouldQueryUsingOperatorNot() {
            result = queryWhere(x => x.Not(y => y.LtProperty("DoubleStuff", "FloatStuff")));
    }
}
