using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Core.XmlRpc.Models {
    public class XRpcData {
        private object _value;
        public object Value {
            get { return _value; }
            set { SetValue(value); }
        }
        protected virtual void SetValue(object value) {
            _value = value;
        public virtual Type Type { get { return typeof(object); } }
        public static XRpcData<T> For<T>(T t) {
            return new XRpcData<T> { Value = t };
    }
    public class XRpcData<T> : XRpcData {
        private T _value;
        public new T Value {
        void SetValue(T value) {
            base.SetValue(value);
        protected override void SetValue(object value) {
            _value = (T)Convert.ChangeType(value, typeof(T));
        public override Type Type { get { return typeof(T); } }
    public class XRpcFault {
        public XRpcFault(int code, string message) {
            Code = code;
            Message = message;
        public string Message { get; set; }
        public int Code { get; set; }
}
