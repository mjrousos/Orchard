using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.UI.Notify {
    public static class NotifierExtensions {
        /// <summary>
        /// Adds a new UI notification of type Information
        /// </summary>
        /// <seealso cref="Orchard.UI.Notify.INotifier.Add()"/>
        /// <param name="message">A localized message to display</param>
        public static void Information(this INotifier notifier, LocalizedString message) {
            notifier.Add(NotifyType.Information, message);
        }
        /// Adds a new UI notification of type Warning
        public static void Warning(this INotifier notifier, LocalizedString message) {
            notifier.Add(NotifyType.Warning, message);
        /// Adds a new UI notification of type Error
        public static void Error(this INotifier notifier, LocalizedString message) {
            notifier.Add(NotifyType.Error, message);
        /// Adds a new UI notification of type Success
        public static void Success(this INotifier notifier, LocalizedString message) {
            notifier.Add(NotifyType.Success, message);
    }
}
