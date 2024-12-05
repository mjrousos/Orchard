using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Configuration;
using Orchard.Environment.Descriptor;
using Orchard.Environment.Descriptor.Models;
using Orchard.Environment.Extensions;

namespace Orchard.MessageBus.Services {
    [OrchardFeature("Orchard.MessageBus.DistributedShellRestart")]
    public class DistributedShellTrigger : IShellDescriptorManagerEventHandler, IShellSettingsManagerEventHandler {
        private readonly IMessageBus _messageBus;
        
        public DistributedShellTrigger(IShellSettingsManager shellSettingsManager, IMessageBus messageBus, IShellSettingsManagerEventHandler shellSettingsManagerEventHandler) {
            _messageBus = messageBus;
        }
        void IShellDescriptorManagerEventHandler.Changed(ShellDescriptor descriptor, string tenant) {
            _messageBus.Publish(DistributedShellStarter.Channel, tenant);
        void IShellSettingsManagerEventHandler.Saved(ShellSettings settings) {
            _messageBus.Publish(DistributedShellStarter.Channel, settings.Name);
    }
}
