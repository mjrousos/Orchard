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
    public class EvaluationResult {
        private readonly object _value;
        public EvaluationResult(object value) {
            _value = value;
        }
        public static EvaluationResult Result(object value) {
            if (value is EvaluationResult)
                throw new InvalidOperationException("Internal error: value cannot be an evaluation result.");
            return new EvaluationResult(value);
        public static EvaluationResult Error(string message) {
            return new EvaluationResult(new Error { Message = message });
        public object Value { get { return _value; } }
        public bool IsError { get { return Value is Error; } }
        public bool IsNil { get { return IsNull; } }
        public bool IsNull { get { return Value == null; } }
        public bool IsBool { get { return Value is bool; } }
        public bool IsInt32 { get { return Value is int; } }
        public bool IsString { get { return Value is string; } }
        public Error ErrorValue { get { return (Error)Value; } }
        public bool BoolValue { get { return (bool)Value; } }
        public int Int32Value { get { return (int)Value; } }
        public string StringValue { get { return (string)Value; } }
        public override string ToString() {
            return IsNull ? "<null>" : Value.ToString();
    }
    public class Error {
        public string Message { get; set; }
        public Exception Exception { get; set; }
            return string.Format("Error: {0}", Message);
}
