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
using Orchard.Logging;
using Orchard.Exceptions;

namespace Orchard {
    public static class InvokeExtensions {
        /// <summary>
        /// Safely invoke methods by catching non fatal exceptions and logging them
        /// </summary>
        public static void Invoke<TEvents>(this IEnumerable<TEvents> events, Action<TEvents> dispatch, ILogger logger) {
            foreach (var sink in events) {
                try {
                    dispatch(sink);
                }
                catch (Exception ex) {
                    if (IsLogged(ex)) {
                        logger.Error(ex, "{2} thrown from {0} by {1}",
                            typeof(TEvents).Name,
                            sink.GetType().FullName,
                            ex.GetType().Name);
                    }
                    if (ex.IsFatal()) {
                        throw;
            }
        }
        public static IEnumerable<TResult> Invoke<TEvents, TResult>(this IEnumerable<TEvents> events, Func<TEvents, TResult> dispatch, ILogger logger) {
            
                TResult result = default(TResult);
                    result = dispatch(sink);
                yield return result;
        private static bool IsLogged(Exception ex) {
            return ex is OrchardSecurityException || !ex.IsFatal();
    }
}
