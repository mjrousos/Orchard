using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Xml.Linq;
using Orchard.Core.XmlRpc.Models;

namespace Orchard.Core.XmlRpc.Services {
    /// <summary>
    /// Abstraction to write XML based on rpc entities.
    /// </summary>
    public interface IXmlRpcWriter : IDependency {
        /// <summary>
        /// Maps a method response to XML.
        /// </summary>
        /// <param name="rpcMethodResponse">The method response to be mapped.</param>
        /// <returns>The XML element.</returns>
        XElement MapMethodResponse(XRpcMethodResponse rpcMethodResponse);
        /// Maps rpc data to XML.
        /// <param name="rpcData">The rpc data.</param>
        XElement MapData(XRpcData rpcData);
        /// Maps a rpc struct to XML.
        /// <param name="rpcStruct">The rpc struct.</param>
        XElement MapStruct(XRpcStruct rpcStruct);
        /// Maps a rpc array to XML.
        /// <param name="rpcArray">The rpc array.</param>
        XElement MapArray(XRpcArray rpcArray);
    }
}
