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
using System.Globalization;
using System.IO;
using System.Linq;
using NHibernate;
using NUnit.Framework;
using Orchard.Data;
using Orchard.Tests.ContentManagement;
using Orchard.Tests.Records;

namespace Orchard.Tests.Data {
    [TestFixture]
    public class RepositoryTests {
        #region Setup/Teardown
        [TestFixtureSetUp]
        public void InitFixture() {
        }
        [SetUp]
        public void Init() {
            _databaseFilePath = Path.GetTempFileName();
            _sessionFactory = DataUtility.CreateSessionFactory(_databaseFilePath, typeof(FooRecord));
            _session = _sessionFactory.OpenSession();
            _fooRepos = new Repository<FooRecord>(new TestTransactionManager(_session));
        [TearDown]
        public void Term() {
            _session.Close();
        [TestFixtureTearDown]
        public void TermFixture() {
            File.Delete(_databaseFilePath);
        #endregion
        private IRepository<FooRecord> _fooRepos;
        private ISession _session;
        private string _databaseFilePath;
        private ISessionFactory _sessionFactory;
        private void CreateThreeFoos() {
            _fooRepos.Create(new FooRecord { Name = "one" });
            _fooRepos.Create(new FooRecord { Name = "two" });
            _fooRepos.Create(new FooRecord { Name = "three" });
        [Test]
        public void GetByIdShouldReturnNullIfValueNotFound() {
            CreateThreeFoos();
            var nofoo = _fooRepos.Get(6655321);
            Assert.That(nofoo, Is.Null);
        public void GetCanSelectSingleBasedOnFields() {
            var two = _fooRepos.Get(f => f.Name == "two");
            Assert.That(two.Name, Is.EqualTo("two"));
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetThatReturnsTwoOrMoreShouldThrowException() {
            _fooRepos.Get(f => f.Name == "one" || f.Name == "three");
        public void GetWithZeroMatchesShouldReturnNull() {
            var nofoo = _fooRepos.Get(f => f.Name == "four");
        public void LinqCanBeUsedToSelectObjects() {
            var foos = from f in _fooRepos.Table
                       where f.Name == "one" || f.Name == "two"
                       select f;
            Assert.That(foos.Count(), Is.EqualTo(2));
            Assert.That(foos, Has.Some.Property("Name").EqualTo("one"));
            Assert.That(foos, Has.Some.Property("Name").EqualTo("two"));
        public void LinqExtensionMethodsCanAlsoBeUsedToSelectObjects() {
            var foos = _fooRepos.Table
                .Where(f => f.Name == "one" || f.Name == "two");
        public void OrderShouldControlResults() {
            var foos = _fooRepos.Fetch(
                f => f.Name == "two" || f.Name == "three",
                o => o.Asc(f => f.Name, f => f.Id));
            Assert.That(foos.First().Name, Is.EqualTo("three"));
            Assert.That(foos.Skip(1).First().Name, Is.EqualTo("two"));
        public void LinqOrderByCanBeUsedToControlResults() {
            IEnumerable<FooRecord> foos =
                        from f in _fooRepos.Table
                        where f.Name == "two" || f.Name == "three"
                        orderby f.Name, f.Id ascending
                        select f;
        public void RangeShouldSliceResults() {
            for (var x = 0; x != 40; ++x) {
                _fooRepos.Create(new FooRecord { Name = x.ToString().PadLeft(8, '0') });
            }
                f => f.Name.StartsWith("000"),
                o => o.Asc(f => f.Name),
                10, 20);
            Assert.That(foos.Count(), Is.EqualTo(20));
            Assert.That(foos.First().Name, Is.EqualTo("00000010"));
            Assert.That(foos.Last().Name, Is.EqualTo("00000029"));
        public void RepositoryCanCreateFetchAndDelete() {
            var foo1 = new FooRecord { Name = "yadda" };
            _fooRepos.Create(foo1);
            var foo2 = _fooRepos.Get(foo1.Id);
            foo2.Name = "blah";            
            Assert.That(foo1, Is.SameAs(foo2));
            _fooRepos.Delete(foo2);
        public void RepositoryFetchTakesCompoundLambdaPredicate() {
            var foos = _fooRepos.Fetch(f => f.Name == "three" || f.Name == "two");
            Assert.That(foos, Has.Some.Property("Name").EqualTo("three"));
        public void RepositoryFetchTakesSimpleLambdaPredicate() {
            var one = _fooRepos.Fetch(f => f.Name == "one").Single();
            var two = _fooRepos.Fetch(f => f.Name == "two").Single();
            Assert.That(one.Name, Is.EqualTo("one"));
        public void StoringDateTimeDoesntRemovePrecision() {
            _fooRepos.Create(new FooRecord { Name = "one", Timespan = DateTime.Parse("2001-01-01 16:28:21.489", CultureInfo.InvariantCulture) });
            Assert.That(one.Timespan.Value.Millisecond, Is.EqualTo(489));
        public void RepositoryFetchTakesExistsPredicate() {
            var array = new[] { "one", "two" };
            var result = _fooRepos.Fetch(f => array.Contains(f.Name)).ToList();
            Assert.That(result.Count(), Is.EqualTo(2));
    }
}
