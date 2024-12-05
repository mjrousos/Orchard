using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Logging {
    public class CastleLoggerFactory : ILoggerFactory {
        private readonly Castle.Core.Logging.ILoggerFactory _castleLoggerFactory;
        public CastleLoggerFactory(Castle.Core.Logging.ILoggerFactory castleLoggerFactory) {
            _castleLoggerFactory = castleLoggerFactory;
        }
        public ILogger CreateLogger(Type type) {
            return new CastleLogger(_castleLoggerFactory.Create(type));
    }
}
