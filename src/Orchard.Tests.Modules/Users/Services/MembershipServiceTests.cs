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
using System.Web.Security;
using Autofac;
using Moq;
using NHibernate;
using NUnit.Framework;
using Orchard.Caching;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Services;
using Orchard.ContentManagement.Records;
using Orchard.Core.Settings.Handlers;
using Orchard.Core.Settings.Metadata;
using Orchard.Core.Settings.Services;
using Orchard.Data;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Implementation;
using Orchard.Environment;
using Orchard.Environment.Configuration;
using Orchard.Environment.Extensions;
using Orchard.Settings;
using Orchard.Tests.ContentManagement;
using Orchard.Tests.Stubs;
using Orchard.Tests.Utility;
using Orchard.UI.PageClass;
using Orchard.Users.Handlers;
using Orchard.Users.Models;
using Orchard.Users.Services;

namespace Orchard.Tests.Modules.Users.Services 
{
    [TestFixture]
    public class MembershipServiceTests {
        private IMembershipValidationService _membershipValidationService;
        private IMembershipService _membershipService;
        private ISessionFactory _sessionFactory;
        private ISession _session;
        private IContainer _container;
        private StubClock _clock;
        private Mock<WorkContext> _workContext;
        [TestFixtureSetUp]
        public void InitFixture() {
            var databaseFileName = System.IO.Path.GetTempFileName();
            _sessionFactory = DataUtility.CreateSessionFactory(
                databaseFileName,
                typeof(UserPartRecord),
                typeof(ContentItemVersionRecord),
                typeof(ContentItemRecord),
                typeof(ContentTypeRecord));
        }
        [TestFixtureTearDown]
        public void TermFixture() {
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            //builder.RegisterModule(new ImplicitCollectionSupportModule());
            builder.RegisterType<MembershipValidationService>().As<IMembershipValidationService>();
            builder.RegisterType<MembershipService>().As<IMembershipService>();
            builder.RegisterType<PasswordService>().As<IPasswordService>();
            builder.RegisterType<DefaultContentQuery>().As<IContentQuery>();
            builder.RegisterType<DefaultContentManager>().As<IContentManager>();
            builder.RegisterType<StubCacheManager>().As<ICacheManager>();
            builder.RegisterType<Signals>().As<ISignals>();
            builder.RegisterType(typeof(SettingsFormatter)).As<ISettingsFormatter>();
            builder.RegisterType<ContentDefinitionManager>().As<IContentDefinitionManager>();
            builder.RegisterType<DefaultContentManagerSession>().As<IContentManagerSession>();
            builder.RegisterInstance(new ShellSettings { Name = ShellSettings.DefaultName, DataProvider = "SqlCe" });
            builder.RegisterType<UserPartHandler>().As<IContentHandler>();
            builder.RegisterType<OrchardServices>().As<IOrchardServices>();
            builder.RegisterAutoMocking(MockBehavior.Loose);
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<DefaultShapeTableManager>().As<IShapeTableManager>();
            builder.RegisterType<DefaultShapeFactory>().As<IShapeFactory>();
            builder.RegisterInstance(_clock = new StubClock()).As<IClock>();
            builder.RegisterType<StubExtensionManager>().As<IExtensionManager>();
            builder.RegisterInstance(new Mock<IPageClassBuilder>().Object);
            builder.RegisterType<DefaultContentDisplay>().As<IContentDisplay>();
            builder.RegisterType<InfosetHandler>().As<IContentHandler>();
            builder.RegisterType<SiteService>().As<ISiteService>();
            builder.RegisterType<SiteSettingsPartHandler>().As<IContentHandler>();
            builder.RegisterType<RegistrationSettingsPartHandler>().As<IContentHandler>();
            _session = _sessionFactory.OpenSession();
            builder.RegisterInstance(new TestTransactionManager(_session)).As<ITransactionManager>();
            _workContext = new Mock<WorkContext>();
            _workContext.Setup(w => w.GetState<ISite>(It.Is<string>(s => s == "CurrentSite"))).Returns(() => { return _container.Resolve<ISiteService>().GetSiteSettings(); });
            var _workContextAccessor = new Mock<IWorkContextAccessor>();
            _workContextAccessor.Setup(w => w.GetContext()).Returns(_workContext.Object);
            builder.RegisterInstance(_workContextAccessor.Object).As<IWorkContextAccessor>();
            _container = builder.Build();
            _container.Resolve<IWorkContextAccessor>().GetContext().CurrentSite.ContentItem.Weld(new RegistrationSettingsPart());
            _membershipValidationService = _container.Resolve<IMembershipValidationService>();
            _membershipService = _container.Resolve<IMembershipService>();
        [TearDown]
        public void Cleanup() {
            if (_container != null)
                _container.Dispose();
        [Test]
        public void CreateUserShouldAllocateModelAndCreateRecords() {
            var user = _membershipService.CreateUser(new CreateUserParams("a", "b", "c", null, null, true, false));
            Assert.That(user.UserName, Is.EqualTo("a"));
            Assert.That(user.Email, Is.EqualTo("c"));
        public void DefaultPasswordFormatShouldBeHashedAndHaveSalt() {
            var userRepository = _container.Resolve<IRepository<UserPartRecord>>();
            var userRecord = userRepository.Get(user.Id);
            Assert.That(userRecord.PasswordFormat, Is.EqualTo(MembershipPasswordFormat.Hashed));
            Assert.That(userRecord.Password, Is.Not.EqualTo("b"));
            Assert.That(userRecord.PasswordSalt, Is.Not.Null);
            Assert.That(userRecord.PasswordSalt, Is.Not.Empty);
        public void SaltAndPasswordShouldBeDifferentEvenWithSameSourcePassword() {
            var password = "Password1!";
            var user1 = _membershipService.CreateUser(new CreateUserParams("user1", password, "user1@email.com", null, null, true, false));
            _session.Flush();
            _session.Clear();
            var user2 = _membershipService.CreateUser(new CreateUserParams("user2", password, "user2@email.com", null, null, true, false));
            var user1Record = userRepository.Get(user1.Id);
            var user2Record = userRepository.Get(user2.Id);
            Assert.That(user1Record.PasswordSalt, Is.Not.EqualTo(user2Record.PasswordSalt));
            Assert.That(user1Record.Password, Is.Not.EqualTo(user2Record.Password));
            List<LocalizedString> validationErrors;
            Assert.That(_membershipService.ValidateUser("user1", password, out validationErrors), Is.Not.Null);
            Assert.That(_membershipService.ValidateUser("user2", password, out validationErrors), Is.Not.Null);
        public void ValidateUserShouldReturnNullIfUserOrPasswordIsIncorrect() {
            _membershipService.CreateUser(new CreateUserParams("test-user", "test-password", "c", null, null, true, false));
            var validate1 = _membershipService.ValidateUser("test-user", "bad-password", out validationErrors);
            var validate2 = _membershipService.ValidateUser("bad-user", "test-password", out validationErrors);
            var validate3 = _membershipService.ValidateUser("test-user", "test-password", out validationErrors);
            Assert.That(validate1, Is.Null);
            Assert.That(validate2, Is.Null);
            Assert.That(validate3, Is.Not.Null);
        public void UsersWhoHaveNeverLoggedInCanBeAuthenticated() {
            var user = (UserPart)_membershipService.CreateUser(new CreateUserParams("a", "b", "c", null, null, true, false));
            Assert.That(_membershipValidationService.CanAuthenticateWithCookie(user), Is.True);
        public void UsersWhoHaveNeverLoggedOutCanBeAuthenticated() {
            user.LastLoginUtc = _clock.UtcNow;
            _clock.Advance(TimeSpan.FromMinutes(1));
        public void UsersWhoHaveLoggedOutCantBeAuthenticated() {
            user.LastLogoutUtc = _clock.UtcNow;
            Assert.That(_membershipValidationService.CanAuthenticateWithCookie(user), Is.False);
        public void UsersWhoHaveLoggedInCanBeAuthenticated() {
        public void PendingUsersCantBeAuthenticated() {
            user.RegistrationStatus = UserStatus.Pending;
        public void ApprovedUsersCanBeAuthenticated() {
            user.RegistrationStatus = UserStatus.Approved;
    }
}
