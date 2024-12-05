using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Tasks.Locking.Services {
    public class DistributedLock : IDistributedLock {
        private readonly string _name;
        private readonly string _internalName;
        private readonly Action _releaseLockAction;
        private int _count;
        internal DistributedLock(string name, string internalName, Action releaseLockAction) {
            _name = name;
            _internalName = internalName;
            _releaseLockAction = releaseLockAction;
            _count = 1;
        }
        string IDistributedLock.Name {
            get {
                return _name;
            }
        internal string InternalName {
                return _internalName;
        internal void Increment() {
            _count++;
        public void Dispose() {
            _count--;
            if (_count == 0)
                _releaseLockAction();
    }
}
