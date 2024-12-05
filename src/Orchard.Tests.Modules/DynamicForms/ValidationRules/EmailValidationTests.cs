using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using NUnit.Framework;
using Orchard.DynamicForms.Services.Models;
using Orchard.DynamicForms.ValidationRules;

namespace Orchard.Tests.Modules.DynamicForms.ValidationRules {
    [TestFixture]
    public class EmailValidationTests {
        [SetUp]
        public void Init() {
            _context = new ValidateInputContext {ModelState = new ModelStateDictionary(), FieldName = "Email Address"};
            _validator = new EmailAddress();
        }

        [Test]
        public void InvalidateDoubleDotDomain() {
            _context.AttemptedValue = "x@example..com";
            _validator.Validate(_context);
            Assert.That(_context.ModelState.IsValid, Is.False);
        public void InvalidateMissingAt() {
            _context.AttemptedValue = "x.example.com";
        public void InvalidateMissingDomain() {
            _context.AttemptedValue = "x@";
        public void InvalidateMissingLocalPart() {
            _context.AttemptedValue = "@example.com";
        public void ValidateMissingTLD() {
            _context.AttemptedValue = "something@localhost";
            Assert.That(_context.ModelState.IsValid, Is.True);
        public void ValidateOneLetterTLD() {
            _context.AttemptedValue = "something@example.x";
        public void ValidateTenLetterTLD() {
            _context.AttemptedValue = "something@example.accountant";
        public void ValidateThreeLetterTLD() {
            _context.AttemptedValue = "something@example.com";
        public void ValidateTwoLetterTLD() {
            _context.AttemptedValue = "something@example.io";
    }
}

        private ValidateInputContext _context;
        private EmailAddress _validator;

