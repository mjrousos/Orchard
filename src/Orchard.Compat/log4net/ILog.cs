using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace log4net
{
    public interface ILog
    {
        void Debug(object message);
        void Info(object message);
        void Warn(object message);
        void Error(object message);
        void Fatal(object message);
        void Trace(string message);
        void Trace(Func<string> messageFactory);
        void Trace(string message, Exception exception);
        void TraceFormat(string format, params object[] args);
        void TraceFormat(Exception exception, string format, params object[] args);
        void TraceFormat(IFormatProvider provider, string format, params object[] args);
        void TraceFormat(Exception exception, IFormatProvider provider, string format, params object[] args);
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsTraceEnabled { get; }
    }

    public class Log4NetLogger : ILog
    {
        private readonly ILogger _logger;

        public Log4NetLogger(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsDebugEnabled => _logger.IsEnabled(LogLevel.Debug);
        public bool IsInfoEnabled => _logger.IsEnabled(LogLevel.Information);
        public bool IsWarnEnabled => _logger.IsEnabled(LogLevel.Warning);
        public bool IsErrorEnabled => _logger.IsEnabled(LogLevel.Error);
        public bool IsFatalEnabled => _logger.IsEnabled(LogLevel.Critical);
        public bool IsTraceEnabled => _logger.IsEnabled(LogLevel.Trace);

        public void Debug(object message) => _logger.LogDebug(message?.ToString());
        public void Info(object message) => _logger.LogInformation(message?.ToString());
        public void Warn(object message) => _logger.LogWarning(message?.ToString());
        public void Error(object message) => _logger.LogError(message?.ToString());
        public void Fatal(object message) => _logger.LogCritical(message?.ToString());
        public void Trace(string message) => _logger.LogTrace(message);
        public void Trace(Func<string> messageFactory) => _logger.LogTrace(messageFactory());
        public void Trace(string message, Exception exception) => _logger.LogTrace(exception, message);
        public void TraceFormat(string format, params object[] args) => _logger.LogTrace(format, args);
        public void TraceFormat(Exception exception, string format, params object[] args) => _logger.LogTrace(exception, format, args);
        public void TraceFormat(IFormatProvider provider, string format, params object[] args) => _logger.LogTrace(string.Format(provider, format, args));
        public void TraceFormat(Exception exception, IFormatProvider provider, string format, params object[] args) => _logger.LogTrace(exception, string.Format(provider, format, args));
    }
}
