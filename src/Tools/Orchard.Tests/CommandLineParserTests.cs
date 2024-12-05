using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using NUnit.Framework;
using Orchard.Parameters;

namespace Orchard.Tests {
    [TestFixture]
    public class CommandLineParseTests {
        [Test]
        public void ParserUnderstandsSimpleArguments() {
            // a b cdef
            // => a
            // => b
            // => cdef
            var result = new CommandLineParser().Parse("a b cdef").ToList();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result[0], Is.EqualTo("a"));
            Assert.That(result[1], Is.EqualTo("b"));
            Assert.That(result[2], Is.EqualTo("cdef"));
        }
        public void ParserIgnoresExtraSpaces() {
            //  a    b    cdef   
            var result = new CommandLineParser().Parse("  a    b    cdef   ").ToList();
        public void ParserGroupsQuotedArguments() {
            // feature enable "a b cdef"
            // => feature
            // => enable
            // => a b cdef
            var result = new CommandLineParser().Parse("feature enable \"a b cdef\"").ToList();
            Assert.That(result[0], Is.EqualTo("feature"));
            Assert.That(result[1], Is.EqualTo("enable"));
            Assert.That(result[2], Is.EqualTo("a b cdef"));
        public void ParserUnderstandsQuotesInsideArgument() {
            // feature enable /foo:"a b cdef"
            // => /foo:a b cdef
            var result = new CommandLineParser().Parse("feature enable /foo:\"a b cdef\"").ToList();
            Assert.That(result[2], Is.EqualTo("/foo:a b cdef"));
        public void ParserBackslashEscapesQuote() {
            // feature enable \"a b cdef\"
            // => "a
            // => cdef"
            var result = new CommandLineParser().Parse("feature enable \\\"a b cdef\\\"").ToList();
            Assert.That(result, Has.Count.EqualTo(5));
            Assert.That(result[2], Is.EqualTo("\"a"));
            Assert.That(result[3], Is.EqualTo("b"));
            Assert.That(result[4], Is.EqualTo("cdef\""));
        public void ParserBackslashDoesnotEscapeBackslash() {
            // feature enable \\a
            // => \\a
            var result = new CommandLineParser().Parse("feature enable \\\\a").ToList();
            Assert.That(result[2], Is.EqualTo("\\\\a"));
        public void ParserBackslashDoesnotEscapeOtherCharacters() {
            // feature enable \a
            // => \a
            var result = new CommandLineParser().Parse("feature enable \\a").ToList();
            Assert.That(result[2], Is.EqualTo("\\a"));
        public void ParserUnderstandsTrailingBackslash() {
            // feature enable \
            // => \
            var result = new CommandLineParser().Parse("feature enable \\").ToList();
            Assert.That(result[2], Is.EqualTo("\\"));
        public void ParserUnderstandsTrailingBackslash2() {
            // feature enable b\
            // => b\
            var result = new CommandLineParser().Parse("feature enable b\\").ToList();
            Assert.That(result[2], Is.EqualTo("b\\"));
        public void ParserUnderstandsEmptyArgument() {
            // feature enable ""
            // => <empty arg>
            var result = new CommandLineParser().Parse("feature enable \"\"").ToList();
            Assert.That(result[2], Is.EqualTo(""));
        public void ParserUnderstandsTrailingQuote() {
            // feature enable "
            var result = new CommandLineParser().Parse("feature enable \"").ToList();
        public void ParserUnderstandsEmptyArgument2() {
            // "
            var result = new CommandLineParser().Parse("\"").ToList();
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(""));
        public void ParserUnderstandsEmptyArgument3() {
            // ""
            var result = new CommandLineParser().Parse("\"\"").ToList();
    }
}
