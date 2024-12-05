using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Services {
    /// <summary>
    /// Provides services to serialize and deserialize objects to and from
    /// Json documents.
    /// </summary>
    public interface IJsonConverter : IDependency {
        /// <summary>
        /// Serializes an object to Json.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <returns>A string representing the object as Json.</returns>
        string Serialize(object o);

        /// Serializes an object to Json using an optional indentation.
        /// <param name="format">Whether the document should be indented.</param>
        string Serialize(object o, JsonFormat format);
        /// Deserializes a Json document to a dynamic object.
        /// <param name="json">The Json document to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        dynamic Deserialize(string json);
        /// Deserializes a Json document to a specific object.
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        T Deserialize<T>(string json);
    }
    public enum JsonFormat {
        None,
        Indented
}
