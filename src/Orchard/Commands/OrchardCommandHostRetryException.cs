using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Runtime.Serialization;

namespace Orchard.Commands {
    [Serializable]
    public class OrchardCommandHostRetryException : OrchardCoreException {
        public OrchardCommandHostRetryException(LocalizedString message)
            : base(message) {
        }
        public OrchardCommandHostRetryException(LocalizedString message, Exception innerException)
            : base(message, innerException) {
        protected OrchardCommandHostRetryException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
    }
}
