using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Glimpse.Interceptors {
    public abstract class GlimpseMessageInterceptor<T> : IGlimpseMessageInterceptor where T : class {
        public void MessageReceived<TMessage>(TMessage message) where TMessage : class {
            var typedMessage = message as T;

            if (typedMessage != null) {
                ProcessMessage(typedMessage);
            }
        }
        public abstract void ProcessMessage(T message);
    }
}
