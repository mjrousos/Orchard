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
using Orchard.ContentManagement.Records;

namespace Orchard.Messaging.Services {
    [Obsolete]
    public interface IMessageManager : IDependency {
        /// <summary>
        /// Sends a message to a channel using a content item as the recipient
        /// </summary>
        /// <param name="recipient">A content item to send the message to.</param>
        /// <param name="type">A custom string specifying what type of message is sent. Used in even handlers to define the message.</param>
        /// <param name="service">The name of the channel to use, e.g. "email"</param>
        /// <param name="properties">A set of specific properties for the channel.</param>
        void Send(ContentItemRecord recipient, string type, string service, Dictionary<string, string> properties = null);
        /// Sends a message to a channel using a set of content items as the recipients
        /// <param name="recipients">A set of content items to send the message to. Only one message may be sent if the channel manages it.</param>
        void Send(IEnumerable<ContentItemRecord> recipients, string type, string service, Dictionary<string, string> properties = null);
        /// Sends a message to a channel using a list of recipient addresses
        /// <param name="recipientAddresses">A list of addresses that the channel can process.</param>
        void Send(IEnumerable<string> recipientAddresses, string type, string service, Dictionary<string, string> properties = null);
        /// Whether at least one channel is active on the current site
        bool HasChannels();
        /// Provides a list of all the current available channel services
        IEnumerable<string> GetAvailableChannelServices();
    }
}
