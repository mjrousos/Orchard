using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Caching {
    public interface ISignals : IVolatileProvider {
        void Trigger<T>(T signal);
        IVolatileToken When<T>(T signal);
    }
    public class Signals : ISignals {
        readonly IDictionary<object, Token> _tokens = new Dictionary<object, Token>();
        public void Trigger<T>(T signal) {
            lock (_tokens) {
                Token token;
                if (_tokens.TryGetValue(signal, out token)) {
                    _tokens.Remove(signal);
                    token.Trigger();
                }
            }
        }
        public IVolatileToken When<T>(T signal) {
                if (!_tokens.TryGetValue(signal, out token)) {
                    token = new Token();
                    _tokens[signal] = token;
                return token;
        class Token : IVolatileToken {
            public Token() {
                IsCurrent = true;
            public bool IsCurrent { get; private set; }
            public void Trigger() { IsCurrent = false; }
}
