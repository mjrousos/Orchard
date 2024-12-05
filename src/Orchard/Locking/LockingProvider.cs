using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Threading;
using Orchard.Logging;

namespace Orchard.Locking {
    public class LockingProvider : ILockingProvider {
        public LockingProvider() {
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }
        public void Lock(
            object lockOn,
            Action criticalCode,
            Action<Exception> innerHandler = null,
            Action<Exception> outerHandler = null) {
            LockInternal(lockOn, criticalCode, innerHandler, outerHandler);
            string lockOn,
            LockInternal(String.Intern(lockOn), criticalCode, innerHandler, outerHandler);
        public bool TryLock(
            return TryLockInternal(lockOn, TimeSpan.Zero, criticalCode, innerHandler, outerHandler);
            return TryLockInternal(String.Intern(lockOn), TimeSpan.Zero, criticalCode, innerHandler, outerHandler);
           object lockOn,
           TimeSpan timeout,
           Action criticalCode,
           Action<Exception> innerHandler = null,
           Action<Exception> outerHandler = null) {
            return TryLockInternal(lockOn, timeout, criticalCode, innerHandler, outerHandler);
            TimeSpan timeout,
            return TryLockInternal(String.Intern(lockOn), timeout, criticalCode, innerHandler, outerHandler);
            int millisecondsTimeout,
            return TryLockInternal(lockOn, millisecondsTimeout, criticalCode, innerHandler, outerHandler);
            return TryLockInternal(String.Intern(lockOn), millisecondsTimeout, criticalCode, innerHandler, outerHandler);
        private void LockInternal(
            bool taken = false;
            var tmp = lockOn;
            Exception outerException = null;
            try {
                Monitor.Enter(tmp, ref taken);
                criticalCode?.Invoke();
            }
            catch (Exception ex) {
                outerException = ex;
                CleanLog(ex);
                if (innerHandler != null) {
                    innerHandler.Invoke(ex);
                }
                else {
                    if (outerHandler == null) {
                        // if both the handlers are null, the methods should behave like lock(tmp){}
                        // and only bubble out the exception while holding the lock.
                        outerException = null;
                    }
                    throw ex;
            finally {
                if (taken) {
                    Monitor.Exit(tmp);
            // Even if there was an handler for the exception to be used in the critical section
            // (i.e. innerHandler != null) we have further handling here. This may simply mean throwing
            // the exception out when outerHandler == null
            if (outerException != null) {
                if (outerHandler != null) {
                    outerHandler.Invoke(outerException);
                    throw outerException;
        private bool TryLockInternal(
            if (Monitor.TryEnter(tmp, timeout)) {
                try {
                    criticalCode?.Invoke();
                catch (Exception ex) {
                    outerException = ex;
                    CleanLog(ex);
                    if (innerHandler != null) {
                        innerHandler.Invoke(ex);
                    else {
                        if (outerHandler == null) {
                            // if both the handlers are null, the methods should behave like lock(tmp){}
                            // and only bubble out the exception while holding the lock.
                            outerException = null;
                        }
                        throw ex;
                finally {
                // Even if there was an handler for the exception to be used in the critical section
                // (i.e. innerHandler != null) we have further handling here. This may simply mean throwing
                // the exception out when outerHandler == null
                if (outerException != null) {
                    if (outerHandler != null) {
                        outerHandler.Invoke(outerException);
                        throw outerException;
                return true;
            return false;
            if (Monitor.TryEnter(tmp, millisecondsTimeout)) {
        private void CleanLog(Exception ex) {
                Logger.Log(Logging.LogLevel.Error, ex, T("Exception while running critical code").Text);
            catch (Exception) {
                // prevent messing things up if the logger fails
    }
}
