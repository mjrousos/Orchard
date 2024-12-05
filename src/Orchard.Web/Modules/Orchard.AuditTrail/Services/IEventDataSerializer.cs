using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.AuditTrail.Services {
    /// <summary>
    /// A service responsible for serializing and deserializing audit trail event data.
    /// </summary>
    public interface IEventDataSerializer : IDependency {
        /// <summary>
        /// Serialize event data.
        /// </summary>
        /// <param name="eventData">eventData to be serialized.</param>
        /// <returns>The serialized data.</returns>
        string Serialize(IDictionary<string, object> eventData);
        /// Deserialize event data.
        /// <param name="eventData">eventData to be deserialized.</param>
        /// <returns>The deserialized generic dictionary</returns>
        IDictionary<string, object> Deserialize(string eventData);
    }
}
