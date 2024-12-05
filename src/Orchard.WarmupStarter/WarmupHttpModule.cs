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
using System.Threading;
using System.Web;

namespace Orchard.WarmupStarter {
    public class WarmupHttpModule : IHttpModule {
        private HttpApplication _context;
        private static object _synLock = new object();
        private static IList<Action> _awaiting = new List<Action>();
        public void Init(HttpApplication context) {
            _context = context;
            context.AddOnBeginRequestAsync(BeginBeginRequest, EndBeginRequest, null);
        }
        public void Dispose() {
        private static bool InWarmup() {
            lock (_synLock) {
                return _awaiting != null;
            }
        /// <summary>
        /// Warmup code is about to start: Any new incoming request is queued 
        /// until "SignalWarmupDone" is called.
        /// </summary>
        public static void SignalWarmupStart() {
                if (_awaiting == null) {
                    _awaiting = new List<Action>();
                }
        /// Warmup code just completed: All pending requests in the "_await" queue are processed, 
        /// and any new incoming request is now processed immediately.
        public static void SignalWarmupDone() {
            IList<Action> temp;
                temp = _awaiting;
                _awaiting = null;
            if (temp != null) {
                foreach (var action in temp) {
                    action();
        /// Enqueue or directly process action depending on current mode.
        private void Await(Action action) {
            Action temp = action;
                if (_awaiting != null) {
                    temp = null;
                    _awaiting.Add(action);
                temp();
        private IAsyncResult BeginBeginRequest(object sender, EventArgs e, AsyncCallback cb, object extradata) {
            // host is available, process every requests, or file is processed
            if (!InWarmup() || WarmupUtility.DoBeginRequest(_context)) {
                var asyncResult = new DoneAsyncResult(extradata);
                cb(asyncResult);
                return asyncResult;
            else {
                // this is the "on hold" execution path
                var asyncResult = new WarmupAsyncResult(cb, extradata);
                Await(asyncResult.Completed);
        private static void EndBeginRequest(IAsyncResult ar) {
        /// AsyncResult for "on hold" request (resumes when "Completed()" is called)
        private class WarmupAsyncResult : IAsyncResult {
            private readonly EventWaitHandle _eventWaitHandle = new AutoResetEvent(false/*initialState*/);
            private readonly AsyncCallback _cb;
            private readonly object _asyncState;
            private bool _isCompleted;
            public WarmupAsyncResult(AsyncCallback cb, object asyncState) {
                _cb = cb;
                _asyncState = asyncState;
                _isCompleted = false;
            public void Completed() {
                _isCompleted = true;
                _eventWaitHandle.Set();
                _cb(this);
            bool IAsyncResult.CompletedSynchronously {
                get { return false; }
            bool IAsyncResult.IsCompleted {
                get { return _isCompleted; }
            object IAsyncResult.AsyncState {
                get { return _asyncState; }
            WaitHandle IAsyncResult.AsyncWaitHandle {
                get { return _eventWaitHandle; }
        /// Async result for "ok to process now" requests
        private class DoneAsyncResult : IAsyncResult {
            private static readonly WaitHandle _waitHandle = new ManualResetEvent(true/*initialState*/);
            public DoneAsyncResult(object asyncState) {
                get { return true; }
                get { return _waitHandle; }
    }
}
