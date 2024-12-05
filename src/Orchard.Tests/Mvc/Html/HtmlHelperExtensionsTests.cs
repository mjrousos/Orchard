using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;
using System.Web;
using System.Web.Mvc.Html;
using Moq;
using NUnit.Framework;
using Orchard.Mvc.Html;
using System.Collections.Generic;

namespace Orchard.Tests.Mvc.Html {
    [TestFixture]
    public class HtmlHelperExtensionsTests {
        [Test]
        public void LinkReturnsIHtmlString() {
            //arrange
            var viewContext = new ViewContext();
            var viewDataContainer = new Mock<IViewDataContainer>();
            var html = new HtmlHelper(viewContext, viewDataContainer.Object);
            //act
            var result = html.Link("test", "http://example.com") as IHtmlString;
            //assert
            Assert.IsNotNull(result);
        }
        public void LinkHtmlEncodesLinkText() {
            var result = html.Link("<br />", "http://example.com");
            Assert.AreEqual(@"<a href=""http://example.com"">&lt;br /&gt;</a>", result.ToString());
        public void LinkHtmlAttributeEncodesHref() {
            var result = html.Link("test", "<br />");
            Assert.AreEqual(@"<a href=""&lt;br />"">test</a>", result.ToString());
        public void LinkHtmlAttributeEncodesAttributes() {
            var result = html.Link("linkText", "http://example.com", new { title = "<br />" });
            Assert.AreEqual(@"<a href=""http://example.com"" title=""&lt;br />"">linkText</a>", result.ToString());
        public void LinkOrDefaultReturnsIHtmlString() {
            var result = html.LinkOrDefault("test", "http://example.com") as IHtmlString;
        public void LinkOrDefaultHtmlEncodesLinkText() {
            var result = html.LinkOrDefault("<br />", "http://example.com");
        public void LinkOrDefaultWithoutHrefHtmlEncodesLinkText() {
            var result = html.LinkOrDefault("<br />", null);
            Assert.AreEqual(@"&lt;br /&gt;", result.ToString());
        public void LinkOrDefaultWithHrefHtmlAttributeEncodesHref() {
            var result = html.LinkOrDefault("test", "<br />");
        public void SelectOptionHtmlEncodesText() {
            var result = html.SelectOption("value", false, "<br />");
            Assert.AreEqual(@"<option value=""value"">&lt;br /&gt;</option>", result.ToString());
        public void UnorderedListWithNullItemsReturnsEmptyHtmlString() {
            var result = html.UnorderedList((IEnumerable<string>)null, (a, b) => MvcHtmlString.Create(""), "test");
            Assert.AreEqual(string.Empty, result.ToString());
        public void UnorderedListWithEmptyItemsReturnsEmptyHtmlString() {
            var result = html.UnorderedList(new string[] { }, (a, b) => MvcHtmlString.Create(""), "test");
        public void HtmlHelperForEnablesLocalHelperMethods() {
            var controller = new FooController {
                ControllerContext = new ControllerContext()
            };
            var viewContext = new ViewContext {
                ViewData = new ViewDataDictionary {
                    TemplateInfo = new TemplateInfo {
                        HtmlFieldPrefix = "topprefix"
                    }
                },
                Controller = controller,
                View = new Mock<IView>().Object,
                TempData = new TempDataDictionary(),
                Writer = TextWriter.Null
            viewDataContainer.SetupGet(o => o.ViewData).Returns(() => new ViewDataDictionary());
            var localHelper = html.HtmlHelperFor(new {SomeString = "foo"}, "prefix");
            var result = localHelper.LabelFor(p => p.SomeString, "bar", null);
            Assert.AreEqual(@"<label for=""prefix_SomeString"">bar</label>", result.ToString());
        private class FooController : Controller { }
        public void Ellipsize_DontCutHtmlEncodedChars() {
            var result = html.Ellipsize("foo & bar", 5);
            Assert.AreEqual("foo &amp;&#160;\u2026", result.ToString());
        public void Excerpt_DontCutHtmlEncodedChars() {
            var result = html.Excerpt("<p>foo &amp; bar</p>", 7);
    }
}
