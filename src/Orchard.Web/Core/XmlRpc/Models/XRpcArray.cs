using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.Core.XmlRpc.Models {
    public class XRpcArray {
        public XRpcArray() {
            Data = new List<XRpcData>();
        }
        public IList<XRpcData> Data { get; set; }
        public object this[int index] {
            get { return Data[index].Value; }
        public XRpcArray Add<T>(T value) {
            Data.Add(XRpcData.For(value));
            return this;
    }
}
