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
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Orchard.Core.XmlRpc.Models;

namespace Orchard.Core.XmlRpc.Services {
    /// <summary>
    /// Abstraction to read XML and convert it to rpc entities.
    /// </summary>
    public class XmlRpcReader : IXmlRpcReader {
        /// <summary>
        /// Provides the mapping function based on a type name.
        /// </summary>
        private readonly IDictionary<string, Func<XElement, XRpcData>> _dispatch;
        /// Initializes a new instance of the <see cref="XmlRpcReader"/> class.
        public XmlRpcReader() {
            _dispatch = new Dictionary<string, Func<XElement, XRpcData>>
                {
                    { "i4", x => new XRpcData<int> { Value = (int)x } },
                    { "int", x => new XRpcData<int> { Value = (int)x } }, 
                    { "boolean", x => new XRpcData<bool> { Value = (string)x == "1" } }, 
                    { "string", x => new XRpcData<string> { Value = (string)x } }, 
                    { "double", x => new XRpcData<double> { Value = (double)x } }, 
                    { "dateTime.iso8601", x => {
                                                DateTime parsedDateTime;
                                                // try parsing a "normal" datetime string then try what live writer gives us
                                                if (!DateTime.TryParse(x.Value, out parsedDateTime)
                                                    && !DateTime.TryParseExact(x.Value, "yyyyMMddTHH:mm:ss", DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, out parsedDateTime)) {
                                                    parsedDateTime = DateTime.Now;
                                                }
                                                return new XRpcData<DateTime> { Value = parsedDateTime };
                                            } },
                    { "base64", x => new XRpcData<byte[]> { Value = Convert.FromBase64String((string)x) } }, 
                    { "struct", x => XRpcData.For(MapToStruct(x)) },
                    { "array", x => XRpcData.For(MapToArray(x)) }, 
                };
        }
        /// Maps an XML element to a rpc method call.
        /// <param name="source">The XML element to be mapped.</param>
        /// <returns>The rpc method call.</returns>
        public XRpcMethodCall MapToMethodCall(XElement source) {
            return new XRpcMethodCall {
                MethodName = (string)source.Element("methodName"),
                Params = source.Elements("params").Elements("param").Select(MapToData).ToList()
            };
        /// Maps an XML element to rpc data.
        /// <returns>The rpc data.</returns>
        public XRpcData MapToData(XElement source) {
            var value = source.Element("value");
            if (value == null) {
                return new XRpcData();
            }
            var element = value.Elements().SingleOrDefault();
            Func<XElement, XRpcData> dispatch;
            if (_dispatch.TryGetValue(element.Name.LocalName, out dispatch) == false) {
                throw new ApplicationException("Unknown XmlRpc value type " + element.Name.LocalName);
            return dispatch(element);
        /// Maps an XML element to a rpc struct.
        /// <returns>The rpc struct.</returns>
        public XRpcStruct MapToStruct(XElement source) {
            var result = new XRpcStruct();
            foreach (var member in source.Elements("member")) {
                result.Members.Add(
                    (string)member.Element("name"),
                    MapValue(member.Element("value")));
            return result;
        /// Maps an XML element to a rpc array.
        /// <returns>The rpc array.</returns>
        public XRpcArray MapToArray(XElement source) {
            var result = new XRpcArray();
            foreach (var value in source.Elements("data").Elements("value")) {
                result.Data.Add(MapValue(value));
        /// Maps an XML container to rpc data.
        /// <param name="source">The XML container to be mapped.</param>
        private XRpcData MapValue(XContainer source) {
            var element = source.Elements().SingleOrDefault();
    }
}
