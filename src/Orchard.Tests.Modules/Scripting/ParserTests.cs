using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Diagnostics;
using NUnit.Framework;
using Orchard.Scripting.Ast;
using Orchard.Scripting.Compiler;

namespace Orchard.Tests.Modules.Scripting {
    [TestFixture]
    public class ParserTests {
        [Test]
        public void ParserShouldUnderstandConstantExpressions() {
            var tree = new Parser("true").Parse();
            CheckTree(tree, new object[] {
                "const", true,
            });
        }
        public void ParserShouldIgnoreWhitespaces() {
            var tree = new Parser("  true \n  ").Parse();
        public void ParserShouldUnderstandBinaryExpressions() {
            var tree = new Parser("true+true").Parse();
                "binop", TokenKind.Plus,
                    "const", true,
        public void ParserShouldUnderstandCommandExpressions() {
            var tree = new Parser("print 'foo', 'bar'").Parse();
                "call", TokenKind.Identifier, "print",
                    "const", "foo",
                    "const", "bar",
        public void ParserShouldUnderstandCallExpressions() {
            var tree = new Parser("print('foo', 'bar')").Parse();
        public void ParserShouldUnderstandCallExpressions2() {
            var tree = new Parser("print 1+2").Parse();
                    "binop", TokenKind.Plus,
                        "const", 1,
                        "const", 2,
        public void ParserShouldUnderstandOperatorPrecedence() {
            var tree = new Parser("1+2*3").Parse();
                    "const", 1,
                    "binop", TokenKind.Mul,
                        "const", 3,
        public void ParserShouldUnderstandOperatorPrecedence2() {
            var tree = new Parser("1*2+3").Parse();
                    "const", 3,
        public void ParserShouldUnderstandOperatorPrecedence3() {
            var tree = new Parser("not true or true").Parse();
                "binop", TokenKind.Or,
                    "unop", TokenKind.Not,
                        "const", true,
        public void ParserShouldUnderstandOperatorPrecedence4() {
            var tree = new Parser("not (true or true)").Parse();
                "unop", TokenKind.Not,
                  "binop", TokenKind.Or,
        public void ParserShouldUnderstandOperatorPrecedence5() {
            var tree = new Parser("1+2+3").Parse();
        public void ParserShouldUnderstandOperatorPrecedence6() {
            var tree = new Parser("1+2-3").Parse();
                "binop", TokenKind.Minus,
        public void ParserShouldUnderstandRelationalOperators() {
            var tree = new Parser("true == true").Parse();
                "binop", TokenKind.EqualEqual,
                  "const", true,
        public void ParserShouldUnderstandRelationalOperators2() {
            var tree = new Parser("1 != 2").Parse();
                "binop", TokenKind.NotEqual,
                  "const", 1,
                  "const", 2,
        public void ParserShouldUnderstandRelationalOperators3() {
            var tree = new Parser("1 < 2").Parse();
                "binop", TokenKind.LessThan,
        public void ParserShouldUnderstandRelationalOperators4() {
            var tree = new Parser("1 <= 2").Parse();
                "binop", TokenKind.LessThanEqual,
        public void ParserShouldUnderstandRelationalOperators5() {
            var tree = new Parser("1 > 2").Parse();
                "binop", TokenKind.GreaterThan,
        public void ParserShouldUnderstandRelationalOperators6() {
            var tree = new Parser("1 >= 2").Parse();
                "binop", TokenKind.GreaterThanEqual,
        public void ParserShouldUnderstandRelationalOperators7() {
            var tree = new Parser("null == null").Parse();
                  "const", null,
        public void ParserShouldUnderstandRelationalOperatorPrecedence() {
            var tree = new Parser("1 < 2 or 2 > 3 and !false").Parse();
                  "binop", TokenKind.And,
                    "binop", TokenKind.Or,
                      "binop", TokenKind.LessThan,
                      "binop", TokenKind.GreaterThan,
                    "unop", TokenKind.NotSign,
                      "const", false,
        public void ParserShouldUnderstandRelationalOperatorPrecedence2() {
            var tree = new Parser("1 < 2 and 2 > 3 or !false").Parse();
                    "binop", TokenKind.LessThan,
        public void ParserShouldUnderstandParenthesis() {
            var tree = new Parser("1*(2+3)").Parse();
                "binop", TokenKind.Mul,
        public void ParserShouldUnderstandComplexExpressions() {
            var tree = new Parser("not 1 * (2 / 4 * 6 + (3))").Parse();
                        "binop", TokenKind.Plus,
                            "binop", TokenKind.Mul,
                                "binop", TokenKind.Div,
                                    "const", 2,
                                    "const", 4,
                                "const", 6,
                            "const", 3,
        public void ParserShouldContainErrorExpressions() {
            var tree = new Parser("1 + not 3").Parse();
                "error",
        public void ParserShouldContainErrorExpressions2() {
            var tree = new Parser("1 +").Parse();
                    "error",
        private void CheckTree(AbstractSyntaxTree tree, object[] objects) {
            Assert.That(tree, Is.Not.Null);
            Assert.That(tree.Root, Is.Not.Null);
            int index = 0;
            CheckExpression(tree.Root, 0, objects, ref index);
            Assert.That(index, Is.EqualTo(objects.Length));
        private void CheckExpression(AstNode astNode, int indent, object[] objects, ref int index) {
            var exprName = (string)objects[index++];
            Type type = null;
            switch (exprName) {
                case "const":
                    type = typeof(ConstantAstNode);
                    break;
                case "binop":
                    type = typeof(BinaryAstNode);
                case "unop":
                    type = typeof(UnaryAstNode);
                case "call":
                    type = typeof(MethodCallAstNode);
                case "error":
                    type = typeof(ErrorAstNode);
                default:
                    throw new InvalidOperationException(string.Format("Test error: unrecognized expression type abbreviation '{0}'", exprName));
            }
            Trace.WriteLine(string.Format("{0}: {1}{2} (Current: {3})", indent, new string(' ', indent * 2), type.Name, astNode));
            Assert.That(astNode.GetType(), Is.EqualTo(type));
            if (exprName == "const") {
                Assert.That((astNode as ConstantAstNode).Value, Is.EqualTo(objects[index++]));
            else if (exprName == "binop") {
                Assert.That((astNode as BinaryAstNode).Operator.Kind, Is.EqualTo(objects[index++]));
            else if (exprName == "unop") {
                Assert.That((astNode as UnaryAstNode).Operator.Kind, Is.EqualTo(objects[index++]));
            else if (exprName == "call") {
                Assert.That((astNode as MethodCallAstNode).Token.Kind, Is.EqualTo(objects[index++]));
                Assert.That((astNode as MethodCallAstNode).Token.Value, Is.EqualTo(objects[index++]));
            foreach (var child in astNode.Children) {
                CheckExpression(child, indent + 1, objects, ref index);
    }
}
