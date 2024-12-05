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
using System.Linq;
using System.Xml.Linq;
using Orchard.Core.XmlRpc.Models;
using Orchard.Validation;

namespace Orchard.Core.XmlRpc.Services {
    /// <summary>
    /// Abstraction to write XML based on rpc entities.
    /// </summary>
    public class XmlRpcWriter : IXmlRpcWriter {
        /// <summary>
        /// Provides the mapping function based on a type.
        /// </summary>
        private readonly IDictionary<Type, Func<XRpcData, XElement>> _dispatch;
        /// Initializes a new instance of the <see cref="XmlRpcWriter"/> class.
        public XmlRpcWriter() {
            _dispatch = new Dictionary<Type, Func<XRpcData, XElement>>
                {
                    { typeof(int), p => new XElement("int", (int)p.Value) },
                    { typeof(bool), p => new XElement("boolean", (bool)p.Value ? "1" : "0") },
                    { typeof(string), p => new XElement("string", p.Value) },
                    { typeof(double), p => new XElement("double", (double)p.Value) },
                    { typeof(DateTime), p => new XElement("dateTime.iso8601", ((DateTime)p.Value).ToString("yyyyMMddTHH:mm:ssZ")) },
                    { typeof(DateTime?), p => new XElement("dateTime.iso8601", ((DateTime?)p.Value).Value.ToString("yyyyMMddTHH:mm:ssZ")) },
                    { typeof(byte[]), p => new XElement("base64", Convert.ToBase64String((byte[])p.Value)) },
                    { typeof(XRpcStruct), p => MapStruct((XRpcStruct)p.Value) },
                    { typeof(XRpcArray), p => MapArray((XRpcArray)p.Value) },
                };
        }
        /// Maps a method response to XML.
        /// <param name="rpcMethodResponse">The method response to be mapped.</param>
        /// <returns>The XML element.</returns>
        public XElement MapMethodResponse(XRpcMethodResponse rpcMethodResponse) {
            Argument.ThrowIfNull(rpcMethodResponse, "rpcMethodResponse");
            // return a valid fault as per http://xmlrpc.scripting.com/spec.html
            if(rpcMethodResponse.Fault != null) {
                var members = new XRpcStruct();
                members.Set("faultCode", rpcMethodResponse.Fault.Code);
                members.Set("faultString", rpcMethodResponse.Fault.Message);
                return new XElement("methodResponse",
                    new XElement("fault",
                        new XElement("value", MapStruct(members))
                    )
                );
                            
            }
            return new XElement("methodResponse",
                new XElement("params",
                    rpcMethodResponse.Params.Select(
                        p => new XElement("param", MapValue(p)))));
        /// Maps rpc data to XML.
        /// <param name="rpcData">The rpc data.</param>
        public XElement MapData(XRpcData rpcData) {
            Argument.ThrowIfNull(rpcData, "rpcData");
            return new XElement("param", MapValue(rpcData));
        /// Maps a rpc struct to XML.
        /// <param name="rpcStruct">The rpc struct.</param>
        public XElement MapStruct(XRpcStruct rpcStruct) {
            return new XElement(
                "struct",
                rpcStruct.Members.Select(
                    kv => new XElement(
                              "member",
                              new XElement("name", kv.Key),
                              MapValue(kv.Value))));
        /// Maps a rpc array to XML.
        /// <param name="rpcArray">The rpc array.</param>
        public XElement MapArray(XRpcArray rpcArray) {
                "array",
                new XElement(
                    "data",
                    rpcArray.Data.Select(MapValue)));
        private XElement MapValue(XRpcData rpcData) {
            return new XElement("value", _dispatch[rpcData.Type](rpcData));
    }
}
