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
using System.Text;
using System.Threading.Tasks;
using Orchard.MessageBus.Models;

namespace Orchard.MessageBus.Services {
    public interface IMessageBus : ISingletonDependency {
        void Subscribe(string channel, Action<string, string> handler);
        void Publish(string channel, string message);
    }
}
