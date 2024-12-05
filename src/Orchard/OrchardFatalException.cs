using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Runtime.Serialization;

namespace Orchard {
    [Serializable]
    public class OrchardFatalException : Exception {
        private readonly LocalizedString _localizedMessage;
        public OrchardFatalException(LocalizedString message)
            : base(message.Text) {
            _localizedMessage = message;
        }
        public OrchardFatalException(LocalizedString message, Exception innerException)
            : base(message.Text, innerException) {
        protected OrchardFatalException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        public LocalizedString LocalizedMessage { get { return _localizedMessage; } }
    }
}
