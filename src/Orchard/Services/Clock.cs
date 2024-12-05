using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Caching;

namespace Orchard.Services {
    public class Clock : IClock {
        public DateTime UtcNow {
            get { return DateTime.UtcNow; }
        }
        public IVolatileToken When(TimeSpan duration) {
            return new AbsoluteExpirationToken(this, duration);
        public IVolatileToken WhenUtc(DateTime absoluteUtc) {
            return new AbsoluteExpirationToken(this, absoluteUtc);
        public class AbsoluteExpirationToken : IVolatileToken {
            private readonly IClock _clock;
            private readonly DateTime _invalidateUtc;
            public AbsoluteExpirationToken(IClock clock, DateTime invalidateUtc) {
                _clock = clock;
                _invalidateUtc = invalidateUtc;
            }
            public AbsoluteExpirationToken(IClock clock, TimeSpan duration) {
                _invalidateUtc = _clock.UtcNow.Add(duration);
            public bool IsCurrent {
                get {
                    return _clock.UtcNow < _invalidateUtc;
                }
    }
}
