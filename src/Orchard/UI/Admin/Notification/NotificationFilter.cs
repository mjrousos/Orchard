using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;

namespace Orchard.UI.Admin.Notification {
    public class AdminNotificationFilter : FilterProvider, IResultFilter {
        private readonly INotificationManager _notificationManager;
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly dynamic _shapeFactory;
        public AdminNotificationFilter(
            INotificationManager notificationManager, 
            IWorkContextAccessor workContextAccessor, 
            IShapeFactory shapeFactory) {
            _notificationManager = notificationManager;
            _workContextAccessor = workContextAccessor;
            _shapeFactory = shapeFactory;
        }
        public void OnResultExecuting(ResultExecutingContext filterContext) {
            if (!AdminFilter.IsApplied(filterContext.RequestContext))
                return;
            // if it's not a view result, a redirect for example
            if (!(filterContext.Result is ViewResultBase))
            // if it's a child action, a partial view for example
            if (filterContext.IsChildAction)
	             
	
            
            var messageEntries = _notificationManager.GetNotifications().ToList();
            if (!messageEntries.Any())
            var messagesZone = _workContextAccessor.GetContext(filterContext).Layout.Zones["Messages"];
            foreach(var messageEntry in messageEntries)
                messagesZone = messagesZone.Add(_shapeFactory.Message(messageEntry));
        public void OnResultExecuted(ResultExecutedContext filterContext) {}
    }
}
