using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Scripting.Compiler {
    public abstract class PrimitiveType {
        public static PrimitiveType InstanceFor(object value) {
            if (value == null)
                return NullPrimitiveType.Instance;
            if (value is bool)
                return BooleanPrimitiveType.Instance;
            if (value is int)
                return IntegerPrimitiveType.Instance;
            if (value is string)
                return StringPrimitiveType.Instance;
            if (value is Error)
                return ErrorPrimitiveType.Instance;
            throw new InvalidOperationException(string.Format("Scripting engine internal error: no primitive type for value '{0}'", value));
        }
        public abstract EvaluationResult EqualityOperator(EvaluationResult value, EvaluationResult other);
        public abstract EvaluationResult ComparisonOperator(EvaluationResult value, EvaluationResult other);
        public abstract EvaluationResult LogicalAnd(EvaluationResult value, EvaluationResult other);
        public abstract EvaluationResult LogicalOr(EvaluationResult value, EvaluationResult other);
        protected EvaluationResult Result(object value) {
            return EvaluationResult.Result(value);
        protected EvaluationResult Error(string message) {
            return EvaluationResult.Error(message);
    }
    public class BooleanPrimitiveType : PrimitiveType {
        private static BooleanPrimitiveType _instance;
        public static BooleanPrimitiveType Instance {
            get { return _instance ?? (_instance = new BooleanPrimitiveType()); }
        public override EvaluationResult EqualityOperator(EvaluationResult value, EvaluationResult other) {
            if (value.IsBool && other.IsBool)
                return Result(value.BoolValue == other.BoolValue);
            return Error("Boolean values can only be compared to other boolean values");
        public override EvaluationResult ComparisonOperator(EvaluationResult value, EvaluationResult other) {
        public override EvaluationResult LogicalAnd(EvaluationResult value, EvaluationResult other) {
            if (!value.BoolValue)
                return value;
            return other;
        public override EvaluationResult LogicalOr(EvaluationResult value, EvaluationResult other) {
            if (value.BoolValue)
    public class IntegerPrimitiveType : PrimitiveType {
        private static IntegerPrimitiveType _instance;
        public static IntegerPrimitiveType Instance {
            get { return _instance ?? (_instance = new IntegerPrimitiveType()); }
            if (value.IsInt32 && other.IsInt32)
                return Result(value.Int32Value == other.Int32Value);
            return Error("Integer values can only be compared to other integer values");
                return Result(value.Int32Value.CompareTo(other.Int32Value));
            return value;
    public class StringPrimitiveType : PrimitiveType {
        private static StringPrimitiveType _instance;
        public static StringPrimitiveType Instance {
            get { return _instance ?? (_instance = new StringPrimitiveType()); }
            if (value.IsString && other.IsString)
                return Result(value.StringValue == other.StringValue);
            return Result(false);
            return Error("String values can not be compared");
    public class NullPrimitiveType : PrimitiveType {
        private static NullPrimitiveType _instance;
        public static NullPrimitiveType Instance {
            get { return _instance ?? (_instance = new NullPrimitiveType()); }
            return Result(value.IsNull && other.IsNull);
            return Error("'null' values can not be compared");
    public class ErrorPrimitiveType : PrimitiveType {
        private static ErrorPrimitiveType _instance;
        public static ErrorPrimitiveType Instance {
            get { return _instance ?? (_instance = new ErrorPrimitiveType()); }
}
