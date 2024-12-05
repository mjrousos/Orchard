using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;
using Autofac;
using NUnit.Framework;
using Orchard.Tokens.Implementation;
using Orchard.Tokens.Providers;

namespace Orchard.Tokens.Tests {
    [TestFixture]
    public class TextTokenTests {
        private IContainer _container;
        private ITokenizer _tokenizer;
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            builder.RegisterType<Tokenizer>().As<ITokenizer>();
            builder.RegisterType<TokenManager>().As<ITokenManager>();
            builder.RegisterType<TextTokens>().As<ITokenProvider>();
            builder.RegisterType<TestTokenProvider>().As<ITokenProvider>();
            _container = builder.Build();
            _tokenizer = _container.Resolve<ITokenizer>();
        }
        [Test]
        public void TestLimitWhenStringShorterThanLimit() {
            var str = "foo bar baz";
            var result = _tokenizer.Replace("{Text.Limit:" + (str.Length + 1) + "}", new { Text = str });
            Assert.That(result, Is.EqualTo("foo bar baz"));
        public void TestLimitWhenStringLengthEqualsLimit() {
            var result = _tokenizer.Replace("{Text.Limit:" + str.Length + "}", new { Text = str });
        public void TestLimitWhenStringLongerThanLimit() {
            var result = _tokenizer.Replace("{Text.Limit:" + (str.Length - 1) + "}", new { Text = str });
            Assert.That(result, Is.EqualTo("foo bar ba"));
        public void TestLimitWhenStringEmpty() {
            var str = "";
            Assert.That(result, Is.EqualTo(""));
        public void TestLimitWhenEllipsisSpecifed() {
            var result = _tokenizer.Replace("{Text.Limit:" + (str.Length - 1) + ",...}", new { Text = str });
            Assert.That(result, Is.EqualTo("foo bar ba..."));
        public void TestFormat() {
            var str = "bar";
            var result = _tokenizer.Replace("{Text.Format:foo {0} baz}", new { Text = str });
        public void TestTrimEnd() {
            var str = "foo          ";
            var result = _tokenizer.Replace("{Text.TrimEnd: }", new { Text = str });
            Assert.That(result, Is.EqualTo("foo"));
        public void TestTrimEndNumber() {
            var str = "foobarbaz";
            var result = _tokenizer.Replace("{Text.TrimEnd:3}", new { Text = str });
            Assert.That(result, Is.EqualTo("foobar"));
        public void TestTrimEndWhenEmptyArg() {
            var result = _tokenizer.Replace("{Text.TrimEnd:}", new { Text = str });
            Assert.That(result, Is.EqualTo("foobarbaz"));
        [TestCase("foo<bar", "foo%3cbar")]
        [TestCase("foo>bar", "foo%3ebar")]
        [TestCase("foo'bar", "foo%27bar")]
        [TestCase("foo\"bar", "foo%22bar")]
        [TestCase("foo bar", "foo+bar")]
        public void TestUrlEncode(string str, string expected) {
            var result = _tokenizer.Replace("{Text.UrlEncode}", new { Text = str });
            Assert.That(result, Is.EqualTo(expected));
        [TestCase("foo<bar", "foo&lt;bar")]
        [TestCase("foo>bar", "foo&gt;bar")]
        [TestCase("foo&bar", "foo&amp;bar")]
        [TestCase("foo\"bar", "foo&quot;bar")]
        [TestCase("foo'bar", "foo&#39;bar")]
        public void TestHtmlEncode(string str, string expected) {
            var result = _tokenizer.Replace("{Text.HtmlEncode}", new { Text = str }, new ReplaceOptions { Encoding = ReplaceOptions.NoEncode });
        public void TestJavaScriptEncode() {
            var str = "f\"oo<bar>ba'z";
            var result = _tokenizer.Replace("{Text.JavaScriptEncode}", new { Text = str }, new ReplaceOptions { Encoding = ReplaceOptions.NoEncode });
            Assert.That(result, Is.EqualTo(HttpUtility.JavaScriptStringEncode(str)));
        public void TestLineEncode() {
            var str = "foo" + System.Environment.NewLine + "bar" + System.Environment.NewLine + "baz";
            var result = _tokenizer.Replace("{Text.LineEncode}", new { Text = str }, new ReplaceOptions { Encoding = ReplaceOptions.NoEncode });
            Assert.That(result, Is.EqualTo("foo<br />bar<br />baz"));
        [TestCase("foo\nbar", "foo<br />bar")]
        [TestCase("foo\rbar", "foo<br />bar")]
        [TestCase("foo\r\nbar", "foo<br />bar")]
        public void TestLineEncodeWithNonWindowsStyleLineBreaks(string str, string expected) {
    }
}
