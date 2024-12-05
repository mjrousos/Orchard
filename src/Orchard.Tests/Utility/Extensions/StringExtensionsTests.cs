using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using NUnit.Framework;
using Orchard.Utility.Extensions;

namespace Orchard.Tests.Utility.Extensions {
    [TestFixture]
    public class StringExtensionsTests {
        [Test]
        public void CamelFriendly_CamelCasedStringMadeFriendly() {
            const string aCamel = "aCamel";
            Assert.That(aCamel.CamelFriendly(), Is.StringMatching("a Camel"));
        }
        public void CamelFriendly_PascalCasedStringMadeFriendly() {
            const string aCamel = "ACamel";
            Assert.That(aCamel.CamelFriendly(), Is.StringMatching("A Camel"));
        public void CamelFriendly_LowerCasedStringMadeFriendly() {
            const string aCamel = "acamel";
            Assert.That(aCamel.CamelFriendly(), Is.StringMatching("acamel"));
        public void CamelFriendly_EmptyStringReturnsEmptyString() {
            const string aCamel = "";
            Assert.That(aCamel.CamelFriendly(), Is.StringMatching(""));
        public void CamelFriendly_NullValueReturnsEmptyString() {
            const string aCamel = null;
        public void Ellipsize_ShouldTuncateToTheExactNumber() {
            const string toEllipsize = "Lorem ipsum";
            Assert.That(toEllipsize.Ellipsize(2, ""), Is.EqualTo("Lo"));
            Assert.That(toEllipsize.Ellipsize(1, ""), Is.EqualTo("L"));
            Assert.That(toEllipsize.Ellipsize(0, ""), Is.EqualTo(""));
        
        public void Ellipsize_TruncatedToWordBoundary() {
            Assert.That(toEllipsize.Ellipsize(8, ""), Is.EqualTo("Lorem"));
            Assert.That(toEllipsize.Ellipsize(6, ""), Is.EqualTo("Lorem"));
            Assert.That(toEllipsize.Ellipsize(5, ""), Is.EqualTo("Lorem"));
            Assert.That(toEllipsize.Ellipsize(4, ""), Is.EqualTo("Lore"));
        public void Ellipsize_LongStringTruncatedToNearestWord() {
            const string toEllipsize = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed purus quis purus orci aliquam.";
            Assert.That(toEllipsize.Ellipsize(46), Is.StringMatching("Lorem ipsum dolor sit amet, consectetur\u00A0\u2026"));
        public void Ellipsize_ShortStringReturnedAsSame() {
            Assert.That(toEllipsize.Ellipsize(45), Is.StringMatching("Lorem ipsum"));
        public void Ellipsize_EmptyStringReturnsEmptyString() {
            const string toEllipsize = "";
            Assert.That(toEllipsize.Ellipsize(45), Is.StringMatching(""));
        public void Ellipsize_NullValueReturnsEmptyString() {
            const string toEllipsize = null;
        public void Ellipsize_CustomEllipsisStringIsUsed() {
            Assert.That(toEllipsize.Ellipsize(45, "........"), Is.StringMatching("Lorem ipsum dolor sit amet, consectetur........"));
        public void Ellipsize_WordBoundary() {
            Assert.That(toEllipsize.Ellipsize(43, "..."), Is.StringMatching("Lorem ipsum dolor sit amet, consectet..."));
            Assert.That(toEllipsize.Ellipsize(43, "...", true), Is.StringMatching("Lorem ipsum dolor sit amet, ..."));
        public void HtmlClassify_ValidReallySimpleClassNameReturnsSame() {
            const string toClassify = "someclass";
            Assert.That(toClassify.HtmlClassify(), Is.StringMatching(toClassify));
        public void HtmlClassify_NumbersAreMaintainedIfNotAtStart() {
            const string toClassify = "some4class5";
        public void HtmlClassify_NumbersAreStrippedAtStart() {
            const string toClassify = "5someClass";
            Assert.That(toClassify.HtmlClassify(), Is.StringMatching("some-class"));
        public void HtmlClassify_ValidSimpleClassNameReturnsSame() {
            const string toClassify = "some-class";
        public void HtmlClassify_SimpleStringReturnsSimpleClassName() {
            const string toClassify = "this is something";
            Assert.That(toClassify.HtmlClassify(), Is.StringMatching("this-is-something"));
        public void HtmlClassify_ValidComplexClassNameReturnsSimpleClassName() {
            const string toClassify = @"some-class\&some.other.class";
            Assert.That(toClassify.HtmlClassify(), Is.StringMatching("some-class-some-other-class"));
        public void HtmlClassify_CompletelyInvalidClassNameReturnsEmptyString() {
            const string toClassify = @"0_1234_12";
            Assert.That(toClassify.HtmlClassify(), Is.StringMatching(""));
        public void HtmlClassify_LowerCamelCasedStringReturnsLowerHyphenatedClassName() {
            const string toClassify = "camelCased";
            Assert.That(toClassify.HtmlClassify(), Is.StringMatching("camel-cased"));
        public void HtmlClassify_PascalCasedStringReturnsLowerHyphenatedClassName() {
            const string toClassify = "PascalCased";
            Assert.That(toClassify.HtmlClassify(), Is.StringMatching("pascal-cased"));
        public void HtmlClassify_EmptyStringReturnsEmptyString() {
            const string toClassify = "";
        public void HtmlClassify_NullValueReturnsEmptyString() {
            const string toClassify = null;
        public void OrDefault_ReturnsDefaultForNull() {
            const string s = null;
            var def = new LocalizedString("test");
            Assert.That(s.OrDefault(def).Text, Is.SameAs("test"));
        public void OrDefault_ReturnsDefaultIfEmpty() {
            Assert.That("".OrDefault(def).Text, Is.SameAs("test"));
        public void OrDefault_ReturnsDefaultIfNull() {
            Assert.That(((string)null).OrDefault(def).Text, Is.SameAs("test"));
        public void OrDefault_ReturnsString() {
            Assert.That("bar".OrDefault(def).Text, Is.SameAs("bar"));
        public void RemoveTags_StringWithNoTagsReturnsSame() {
            const string fullOfTags = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed purus quis purus orci aliquam.";
            Assert.That(fullOfTags.RemoveTags(), Is.StringMatching("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed purus quis purus orci aliquam."));
        public void RemoveTags_SimpleWellFormedTagsAreRemoved() {
            const string fullOfTags = @"<p><em>Lorem ipsum</em> dolor sit amet, consectetur <a href=""#"">adipiscing</a> elit. Maecenas sed purus quis purus orci aliquam.</p>";
        public void RemoveTags_EmptyStringReturnsEmptyString() {
            const string fullOfTags = "";
            Assert.That(fullOfTags.RemoveTags(), Is.StringMatching(""));
        public void RemoveTags_NullValueReturnsEmptyString() {
            const string fullOfTags = null;
        public void ReplaceNewLinesWith_ReplaceCRLFWithHtmlBR() {
            const string lotsOfLineFeeds = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.\r\nMaecenas sed purus quis purus orci aliquam.";
            Assert.That(lotsOfLineFeeds.ReplaceNewLinesWith("<br />"), Is.StringMatching("Lorem ipsum dolor sit amet, consectetur adipiscing elit.<br />Maecenas sed purus quis purus orci aliquam."));
        public void ReplaceNewLinesWith_ReplaceCRLFWithHtmlPsAndCRLF() {
            Assert.That(lotsOfLineFeeds.ReplaceNewLinesWith(@"</p>{0}<p>"), Is.StringMatching("Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>\r\n<p>Maecenas sed purus quis purus orci aliquam."));
        public void ReplaceNewLinesWith_EmptyStringReturnsEmptyString() {
            const string lotsOfLineFeeds = "";
            Assert.That(lotsOfLineFeeds.ReplaceNewLinesWith("<br />"), Is.StringMatching(""));
        public void ReplaceNewLinesWith_NullValueReturnsEmptyString() {
            const string lotsOfLineFeeds = null;
        public void StripShouldRemoveStart() {
            Assert.That("abc".Strip('a'), Is.StringMatching("bc"));
            Assert.That("abc".Strip("ab".ToCharArray()), Is.StringMatching("c"));
        public void StripShouldRemoveInside() {
            Assert.That("abc".Strip('b'), Is.StringMatching("ac"));
            Assert.That("abc".Strip("abc".ToCharArray()), Is.StringMatching(""));
        public void StripShouldRemoveEnd() {
            Assert.That("abc".Strip('c'), Is.StringMatching("ab"));
            Assert.That("abc".Strip("bc".ToCharArray()), Is.StringMatching("a"));
        public void StripShouldReturnIfEmpty() {
            Assert.That("".Strip('a'), Is.StringMatching(""));
            Assert.That("a".Strip("".ToCharArray()), Is.StringMatching("a"));
        public void AnyShouldReturnTrueAtStart() {
            Assert.That("abc".Any('a'), Is.True);
            Assert.That("abc".Any("ab".ToCharArray()), Is.True);
        public void AnyShouldReturnTrueAtEnd() {
            Assert.That("abc".Any('c'), Is.True);
            Assert.That("abc".Any("bc".ToCharArray()), Is.True);
        public void AnyShouldReturnTrueAtMiddle() {
            Assert.That("abc".Any('b'), Is.True);
            Assert.That("abc".Any("abc".ToCharArray()), Is.True);
        public void AnyShouldReturnFalseIfNotPresent() {
            Assert.That("abc".Any("".ToCharArray()), Is.False);
            Assert.That("abc".Any("d".ToCharArray()), Is.False);
        public void AllShouldReturnTrueIfAllArePresent() {
            Assert.That("abc".All("abc".ToCharArray()), Is.True);
            Assert.That("abc".All("abcd".ToCharArray()), Is.True);
            Assert.That("".All("a".ToCharArray()), Is.True);
        public void AllShouldReturnFalseIfAnyIsNotPresent() {
            Assert.That("abc".All("".ToCharArray()), Is.False);
            Assert.That("abc".All("a".ToCharArray()), Is.False);
        public void TranslateShouldThrowException() {
            Assert.Throws<ArgumentNullException>(() => "a".Translate("".ToCharArray(), "a".ToCharArray()));
            Assert.Throws<ArgumentNullException>(() => "a".Translate("a".ToCharArray(), "".ToCharArray()));
        public void TranslateShouldReturnSource() {
            Assert.That("a".Translate("".ToCharArray(), "".ToCharArray()), Is.StringMatching(""));
            Assert.That("".Translate("abc".ToCharArray(), "abc".ToCharArray()), Is.StringMatching(""));
        public void TranslateShouldReplaceChars() {
            Assert.That("abc".Translate("a".ToCharArray(), "d".ToCharArray()), Is.StringMatching("dbc"));
            Assert.That("abc".Translate("d".ToCharArray(), "d".ToCharArray()), Is.StringMatching("abc"));
            Assert.That("abc".Translate("abc".ToCharArray(), "def".ToCharArray()), Is.StringMatching("def"));
        public void ShouldEncodeToBase64() {
            Assert.That("abc".ToBase64(), Is.EqualTo("YWJj"));
        public void ShouldDecodeFromBase64() {
            Assert.That("YWJj".FromBase64(), Is.EqualTo("abc"));
        public void ShouldRoundtripBase64() {
            Assert.That("abc".ToBase64().FromBase64(), Is.EqualTo("abc"));
            Assert.That("YWJj".FromBase64().ToBase64(), Is.EqualTo("YWJj"));
    }
}
