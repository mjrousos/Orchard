using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Caching.Services;
using Orchard.Environment.Extensions;
using Orchard.Glimpse.Services;
using Orchard.Glimpse.Tabs.Cache;

namespace Orchard.Glimpse.AlternateImplementation {
    [OrchardFeature(FeatureNames.Cache)]
    public class GlimpseCacheServiceDecorator : IDecorator<ICacheService>, ICacheService {
        private readonly ICacheService _decoratedService;
        private readonly IGlimpseService _glimpseService;
        public GlimpseCacheServiceDecorator(ICacheService decoratedService, IGlimpseService glimpseService) {
            _decoratedService = decoratedService;
            _glimpseService = glimpseService;
        }
        public object GetObject<T>(string key) {
            return _glimpseService.PublishTimedAction(() => _decoratedService.GetObject<T>(key),
                (r, t) => new CacheMessage {
                    Action = "Get",
                    Duration = t.Duration,
                    Key = key,
                    Result = r == null ? "Miss" : "Hit",
                    Value = r
                }, TimelineCategories.Cache, r => $"Get ({(r == null ? "Miss" : "Hit")})", r => key).ActionResult;
        public void Put<T>(string key, T value) {
            _glimpseService.PublishTimedAction(() => _decoratedService.Put(key, value),
                t => new CacheMessage {
                    Action = "Put",
                    Value = value
                }, TimelineCategories.Cache, "Put", key);
        public void Put<T>(string key, T value, TimeSpan validFor) {
            _glimpseService.PublishTimedAction(() => _decoratedService.Put(key, value, validFor),
                    Value = value,
                    ValidFor = validFor
        public void Remove(string key) {
            _glimpseService.PublishTimedAction(() => _decoratedService.Remove(key),
                    Action = "Remove",
                    Key = key
                }, TimelineCategories.Cache, "Remove", key);
        public void Clear() {
            _glimpseService.PublishTimedAction(() => _decoratedService.Clear(),
                    Action = "Clear",
                    Duration = t.Duration
                }, TimelineCategories.Cache, "Clear");
    }
}
