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
using System.IO;
using System.Linq;
using Autofac;
using Lucene.Services;
using NUnit.Framework;
using Orchard.Environment.Configuration;
using Orchard.FileSystems.AppData;
using Orchard.Indexing;
using Orchard.Tests.FileSystems.AppData;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.Modules.Indexing {
    public class LuceneIndexProviderTests {
        private IContainer _container;
        private IIndexProvider _provider;
        private IAppDataFolder _appDataFolder;
        private ShellSettings _shellSettings;
        private readonly string _basePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        
        [TestFixtureTearDown]
        public void Clean() {
            if (Directory.Exists(_basePath)) {
                Directory.Delete(_basePath, true);
            }
        }
        [SetUp]
        public void Setup() {
            Directory.CreateDirectory(_basePath);
            _appDataFolder = AppDataFolderTests.CreateAppDataFolder(_basePath);
            var builder = new ContainerBuilder();
            builder.RegisterType<StubWorkContextAccessor>().As<IWorkContextAccessor>();
            builder.RegisterType<DefaultLuceneAnalyzerProvider>().As<ILuceneAnalyzerProvider>();
            builder.RegisterType<DefaultLuceneAnalyzerSelector>().As<ILuceneAnalyzerSelector>();
            builder.RegisterType<LuceneIndexProvider>().As<IIndexProvider>();
            builder.RegisterInstance(_appDataFolder).As<IAppDataFolder>();
            // setting up a ShellSettings instance
            _shellSettings = new ShellSettings { Name = "My Site" };
            builder.RegisterInstance(_shellSettings).As<ShellSettings>();
            _container = builder.Build();
            _provider = _container.Resolve<IIndexProvider>();
        private IEnumerable<string> Indexes() {
            return _provider.List();
        [Test]
        public void IndexProviderShouldCreateNewIndex() {
            Assert.That(Indexes().Count(), Is.EqualTo(0));
            _provider.CreateIndex("default");
            Assert.That(Indexes().Count(), Is.EqualTo(1));
        public void IndexProviderShouldCreateMultipleIndexesAndListThem() {
            _provider.CreateIndex("search");
            _provider.CreateIndex("admin");
            Assert.That(Indexes().Count(), Is.EqualTo(3));
            Assert.That(Indexes().Contains("default"));
            Assert.That(Indexes().Contains("search"));
            Assert.That(Indexes().Contains("admin"));
        public void IndexProviderShouldOverwriteAlreadyExistingIndex() {
            _provider.Store("default", _provider.New(1).Add("body", null));
            Assert.That(_provider.IsEmpty("default"), Is.False);
            Assert.That(_provider.IsEmpty("default"), Is.True);
        public void IndexProviderShouldDeleteExistingIndex() {
            _provider.DeleteIndex("default");
        public void IndexProviderShouldListExistingIndexes() {
            
            Assert.That(Indexes().ElementAt(0), Is.EqualTo("default"));
            _provider.CreateIndex("foo");
            Assert.That(Indexes().Count(), Is.EqualTo(2));
        public void ANewIndexShouldBeEmpty() {
            var searchBuilder = _provider.CreateSearchBuilder("default");
            var hits = searchBuilder.Search();
            Assert.That(hits.Count(), Is.EqualTo(0));
        public void DocumentsShouldBeSearchableById() {
            _provider.Store("default", _provider.New(42));
            var hit = searchBuilder.Get(42);
            Assert.IsNotNull(hit);
            Assert.That(hit.ContentItemId, Is.EqualTo(42));
            hit = searchBuilder.Get(1);
            Assert.IsNull(hit);
        public void PropertiesShouldNotBeLost() {
            _provider.Store("default", _provider.New(42)
                .Add("prop1", "value1").Store()
                .Add("prop2", 123).Store()
                .Add("prop3", 123.456).Store()
                .Add("prop4", new DateTime(2001,1,1,1,1,1,1)).Store()
                .Add("prop5", true).Store()
            );
            var hit = _provider.CreateSearchBuilder("default").Get(42);
            Assert.That(hit.GetString("prop1"), Is.EqualTo("value1"));
            Assert.That(hit.GetInt("prop2"), Is.EqualTo(123));
            Assert.That(hit.GetDouble("prop3"), Is.EqualTo(123.456));
            Assert.That(hit.GetDateTime("prop4"), Is.EqualTo(new DateTime(2001, 1, 1, 1, 1, 1, 1)));
            Assert.That(hit.GetBoolean("prop5"), Is.EqualTo(true));            
        public void ShouldHandleMultipleIndexes() {
            _provider.CreateIndex("default1");
            _provider.Store("default1", _provider.New(1));
            _provider.CreateIndex("default2");
            _provider.Store("default2", _provider.New(2));
            _provider.CreateIndex("default3");
            _provider.Store("default3", _provider.New(3));
            Assert.IsNotNull(_provider.CreateSearchBuilder("default1").Get(1));
            Assert.IsNotNull(_provider.CreateSearchBuilder("default2").Get(2));
            Assert.IsNotNull(_provider.CreateSearchBuilder("default3").Get(3));
            Assert.IsNull(_provider.CreateSearchBuilder("default1").Get(2));
            Assert.IsNull(_provider.CreateSearchBuilder("default2").Get(3));
            Assert.IsNull(_provider.CreateSearchBuilder("default3").Get(1));
        public void IdentifierShouldNotCollide() {
            _provider.Store("default", _provider.New(1).Add("field", "value1"));
            _provider.Store("default", _provider.New(11).Add("field", "value11"));
            _provider.Store("default", _provider.New(111).Add("field", "value111"));
            Assert.That(searchBuilder.Get(1).ContentItemId, Is.EqualTo(1));
            Assert.That(searchBuilder.Get(11).ContentItemId, Is.EqualTo(11));
            Assert.That(searchBuilder.Get(111).ContentItemId, Is.EqualTo(111));
        public void TagsShouldBeRemoved() {
            _provider.Store("default", _provider.New(1).Add("body", "<hr>some content</hr>").Analyze());
            _provider.Store("default", _provider.New(2).Add("body", "<hr>some content</hr>").RemoveTags().Analyze());
            Assert.That(searchBuilder.WithField("body", "hr").Search().Count(), Is.EqualTo(1));
            Assert.That(searchBuilder.WithField("body", "hr").Search().First().ContentItemId, Is.EqualTo(1));
        [Test] public void ShouldAllowNullOrEmptyStrings() {
            _provider.Store("default", _provider.New(2).Add("body", ""));
            _provider.Store("default", _provider.New(3).Add("body", "<hr></hr>").RemoveTags());
            Assert.That(searchBuilder.Get(2).ContentItemId, Is.EqualTo(2));
            Assert.That(searchBuilder.Get(3).ContentItemId, Is.EqualTo(3));
        public void IsEmptyShouldBeTrueForNoneExistingIndexes() {
            _provider.IsEmpty("dummy");
        public void IsEmptyShouldBeTrueForJustNewIndexes() {
        public void IsEmptyShouldBeFalseWhenThereIsADocument() {
        public void IsDirtyShouldBeFalseForNewDocuments() {
            IDocumentIndex doc = _provider.New(1);
            Assert.That(doc.IsDirty, Is.False);
        public void IsDirtyShouldBeTrueWhenIndexIsModified() {
            doc.Add("foo", "value");
            Assert.That(doc.IsDirty, Is.True);
            doc = _provider.New(1);
            doc.Add("foo", false);
            doc.Add("foo", (float)1.0);
            doc.Add("foo", 1);
            doc.Add("foo", DateTime.Now);
        public void DocumentsShouldBeDeleted() {
            _provider.Delete("default", 1);
            Assert.That(searchBuilder.Get(1), Is.Null);
            _provider.Delete("default", new [] {1, 11, 111 });
            Assert.That(searchBuilder.Get(11), Is.Null);
            Assert.That(searchBuilder.Get(111), Is.Null);
        public void SameContentItemShouldNotBeIndexedTwice() {
            Assert.That(searchBuilder.WithField("id", "1").Count(), Is.EqualTo(1));
            _provider.Store("default", _provider.New(1).Add("field", "value2"));
        public void IndexProviderShouldDeleteMoreThanMaxTermsCount() {
            var documents = Enumerable.Range(1, 1025).Select(i => _provider.New(i).Add("field", "value1"));
            _provider.Store("default", documents);
            Assert.That(searchBuilder.Count(), Is.EqualTo(1025));
            Assert.That(searchBuilder.Get(1025).ContentItemId, Is.EqualTo(1025));
            _provider.Delete("default", Enumerable.Range(1, 1025));
            Assert.That(searchBuilder.Count(), Is.EqualTo(0));
    }
}
