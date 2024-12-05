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
using NUnit.Framework;
using Orchard.Scripting.Compiler;

namespace Orchard.Tests.Modules.Scripting {
    public abstract class EvaluatorTestsBase {
        [Test]
        public void EvaluateSimpleConstant() {
            var result = EvaluateSimpleExpression("true and true");
            Assert.That(result.IsError, Is.False);
            Assert.That(result.Value, Is.EqualTo(true));
        }
        public void EvaluateSimpleConstant0() {
            var result = EvaluateSimpleExpression("true && true");
        public void EvaluateConvertingBooleanExpression() {
            var result = EvaluateSimpleExpression("true and 1");
            Assert.That(result.Value, Is.EqualTo(1));
        public void EvaluateConvertingBooleanExpression1() {
            var result = EvaluateSimpleExpression("true && 1");
        public void EvaluateConvertingBooleanExpression2() {
            var result = EvaluateSimpleExpression("true and 0");
            Assert.That(result.Value, Is.EqualTo(0));
        public void EvaluateConvertingBooleanExpression3() {
            var result = EvaluateSimpleExpression("true && 0");
        public void EvaluateConvertingBooleanExpression4() {
            var result = EvaluateSimpleExpression("1 and true");
        public void EvaluateConvertingBooleanExpression5() {
            var result = EvaluateSimpleExpression("0 and true");
        public void EvaluateConvertingBooleanExpression6() {
            var result = EvaluateSimpleExpression("1 && true");
        public void EvaluateConvertingBooleanExpression7() {
            var result = EvaluateSimpleExpression("true and 'boo'");
            Assert.That(result.Value, Is.EqualTo("boo"));
        public void EvaluateConvertingBooleanExpression8() {
            var result = EvaluateSimpleExpression("true && 'boo'");
        public void EvaluateConvertingBooleanExpression9() {
            var result = EvaluateSimpleExpression("'boo' and true");
        public void EvaluateConvertingBooleanExpression10() {
            var result = EvaluateSimpleExpression("'boo' && true");
        public void EvaluateConvertingBooleanExpression11() {
            var result = EvaluateSimpleExpression("true or 1");
        public void EvaluateConvertingBooleanExpression12() {
            var result = EvaluateSimpleExpression("true || 1");
        public void EvaluateConvertingBooleanExpression13() {
            var result = EvaluateSimpleExpression("1 or true");
        public void EvaluateConvertingBooleanExpression14() {
            var result = EvaluateSimpleExpression("1 || true");
        public void EvaluateConvertingBooleanExpression15() {
            var result = EvaluateSimpleExpression("true or 'boo'");
        public void EvaluateConvertingBooleanExpression16() {
            var result = EvaluateSimpleExpression("false or 'boo'");
        public void EvaluateConvertingBooleanExpression17() {
            var result = EvaluateSimpleExpression("nil or 'boo'");
        public void EvaluateConvertingBooleanExpression18() {
            var result = EvaluateSimpleExpression("'boo' or nil");
        public void EvaluateConvertingBooleanExpression19() {
            var result = EvaluateSimpleExpression("true || 'boo'");
        public void EvaluateConvertingBooleanExpression20() {
            var result = EvaluateSimpleExpression("'boo' or true");
        public void EvaluateConvertingBooleanExpression21() {
            var result = EvaluateSimpleExpression("'boo' || true");
        public void EvaluateConvertingBooleanExpression22() {
            var result = EvaluateSimpleExpression("1 and 2");
            Assert.That(result.Value, Is.EqualTo(2));
        public void EvaluateConvertingBooleanExpression23() {
            var result = EvaluateSimpleExpression("false and 2");
            Assert.That(result.Value, Is.EqualTo(false));
        public void EvaluateConvertingBooleanExpression24() {
            var result = EvaluateSimpleExpression("nil and 2");
            Assert.That(result.Value, Is.EqualTo(null));
        public void EvaluateConvertingBooleanExpression25() {
            var result = EvaluateSimpleExpression("nil and false");
        public void EvaluateConvertingBooleanExpression26() {
            var result = EvaluateSimpleExpression("nil and true");
        public void EvaluateBooleanExpression() {
            var result = EvaluateSimpleExpression("not true");
            Assert.That(result.BoolValue, Is.EqualTo(false));
        public void EvaluateBooleanExpression0() {
            var result = EvaluateSimpleExpression("!true");
        public void EvaluateSimpleArithmetic() {
            var result = EvaluateSimpleExpression("1 + 2 * 3 - 6 / 2");
            Assert.That(result.Value, Is.EqualTo(4));
        public void EvaluateRelationalOperators() {
            var result = EvaluateSimpleExpression("1 < 2");
        public void EvaluateRelationalOperators2() {
            var result = EvaluateSimpleExpression("2 <= 2");
        public void EvaluateRelationalOperators3() {
            var result = EvaluateSimpleExpression("1 < 2 or 2 > 3 and !false");
        public void EvaluateRelationalOperators4() {
            var result = EvaluateSimpleExpression("1 > 2 or 2 > 3 and !false");
        public void EvaluateRelationalOperators5() {
            var result = EvaluateSimpleExpression("1 > 2 or 4 > 3 and !false");
        public void EvaluateRelationalOperators6() {
            var result = EvaluateSimpleExpression("!false");
        public void EvaluateRelationalOperators7() {
            var result = EvaluateSimpleExpression("5 || 10 && nil");
            Assert.That(result.Value, Is.EqualTo(5));
        public void EvaluateRelationalOperators8() {
            var result = EvaluateSimpleExpression("true or false and nil");
            Assert.That(result.IsNull, Is.True);
        public void EvaluateRelationalOperators9() {
            var result = EvaluateSimpleExpression("true and nil");
        public void EvaluateRelationalOperators10() {
            var result = EvaluateSimpleExpression("5 and nil");
        public void EvaluateEqualityOperators() {
            var result = EvaluateSimpleExpression("1 == 2");
        public void EvaluateEqualityOperators2() {
            var result = EvaluateSimpleExpression("1 != 2");
        public void EvaluateSimpleMethodCall() {
            var result = EvaluateSimpleExpression("printtoto 1 + 2 * 3 - 6 / 2",
                (m, args) => (m == "printtoto") ? (int)args[0] * 2 : 0);
            Assert.That(result.Value, Is.EqualTo(4 * 2));
        public void EvaluateSimpleMethodCall2() {
            var result = EvaluateSimpleExpression("printtoto(1 + 2 * 3 - 6 / 2)",
        public void EvaluateSimpleMethodCall3() {
            var result = EvaluateSimpleExpression("foo 1 + bar 3",
                (m, args) => 
                    (m == "foo") ? (int)args[0] * 2 : 
                    (m == "bar") ? (int)args[0] : 0);
            Assert.That(result.IsError, Is.True);
        public void EvaluateSimpleMethodCall4() {
            var result = EvaluateSimpleExpression("foo(1 + bar 3)",
        public void EvaluateSimpleMethodCall5() {
            var result = EvaluateSimpleExpression("foo 1 + bar(3)",
                (m, args) =>
                    (m == "foo") ? (int)args[0] * 2 :
            Assert.That(result.Value, Is.EqualTo(2 * (1 + 3)));
        public void EvaluateSimpleMethodCall6() {
            var result = EvaluateSimpleExpression("foo(1) + bar(3)",
            Assert.That(result.Value, Is.EqualTo(2 + 3));
        public void EvaluateSimpleMethodCall7() {
            var result = EvaluateSimpleExpression("foo",
                (m, args) => (m == "foo") ? true : false);
        public void EvaluateSimpleMethodCall8() {
            var result = EvaluateSimpleExpression("foo()",
        public void EvaluateSimpleMethodCall9() {
#if false
            var result = EvaluateSimpleExpression("1 + bar 3",
#endif
        public void EvaluateSimpleMethodCall10() {
            var result = EvaluateSimpleExpression("1 || bar 3",
        public void EvaluateSimpleMethodCall11() {
            var result = EvaluateSimpleExpression("1 * bar 3",
        public void EvaluateSimpleMethodCall12() {
            var result = EvaluateSimpleExpression("1 && bar 3",
        public void EvaluateSimpleMethodCall13() {
            var result = EvaluateSimpleExpression("(1 + bar 3)",
        public void EvaluateSimpleMethodCall14() {
            var result = EvaluateSimpleExpression("1 + bar(3)",
            Assert.That(result.Value, Is.EqualTo(1 + 3));
        public void EvaluateSimpleMethodCall15() {
            var result = EvaluateSimpleExpression("1 + (bar 3)",
        public void EvaluateSimpleMethodCall16() {
            var result = EvaluateSimpleExpression("1 and bar 3",
            Assert.That(result.Value, Is.EqualTo(3));
        public void EvaluateSimpleMethodCall17() {
            var result = EvaluateSimpleExpression("1 or bar 3",
        public void EvaluateComplexMethodCall() {
            var result = EvaluateSimpleExpression("authenticated and url \"~/boo*\"",
                (m, args) => (m == "authenticated") ? true : (m == "url") ? (string)args[0] == "~/boo*" : false);
        public void EvaluateComplexMethodCall2() {
            var result = EvaluateSimpleExpression("(authenticated) and (url \"~/boo*\")",
        public void EvaluateComplexMethodCall3() {
            var result = EvaluateSimpleExpression("(authenticated and url \"~/boo*\")",
        public void EvaluateComplexMethodCall4() {
            var result = EvaluateSimpleExpression("(authenticated) and url \"~/boo*\"",
        public void EvaluateComplexMethodCall5() {
            var result = EvaluateSimpleExpression("(authenticated()) and (url \"~/boo*\")",
        public void EvaluateComplexMethodCall6() {
            var result = EvaluateSimpleExpression("authenticated() and url(\"~/boo*\")",
        private EvaluationResult EvaluateSimpleExpression(string expression) {
            return EvaluateSimpleExpression(expression, (m, args) => null);
        protected abstract EvaluationResult EvaluateSimpleExpression(string expression, Func<string, IList<object>, object> methodInvocationCallback);
    }
}
