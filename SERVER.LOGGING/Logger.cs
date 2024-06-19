using log4net;
using System;
using System.Reflection;
using SERVER.APPLICATION.Services;

namespace SERVER.LOGGING
{
    public sealed class Logger : ILogger
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Lazy<Logger> _loggerInstance = new Lazy<Logger>(() => new Logger());

        public static Logger Instance => _loggerInstance.Value;

        public void Debug(object message)
        {
            if (_logger.IsDebugEnabled)
                _logger.Debug(message);
        }

        public void Info(object message)
        {
            if (_logger.IsInfoEnabled)
                _logger.Info(message);
        }

        public void Warn(object message)
        {
            if (_logger.IsWarnEnabled)
                _logger.Warn(message);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }

        public void Fatal(object message)
        {
            _logger.Fatal(message);
        }

        public void Debug(object message, Exception exception)
        {
            if (_logger.IsDebugEnabled)
                _logger.Debug(message, exception);
        }

        public void Info(object message, Exception exception)
        {
            if (_logger.IsInfoEnabled)
                _logger.Info(message, exception);
        }

        public void Warn(object message, Exception exception)
        {
            if (_logger.IsWarnEnabled)
                _logger.Warn(message, exception);
        }

        public void Error(object message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        public void Fatal(object message, Exception exception)
        {
            _logger.Fatal(message, exception);
        }

        public void Error(Exception exception)
        {
            _logger.Error(SerializeException(exception, "Exception"));
        }

        public void Fatal(Exception exception)
        {
            _logger.Fatal(SerializeException(exception, "Exception"));
        }

        private static string SerializeException(Exception ex, string exceptionMessage)
        {
            var mesgAndStackTrace = string.Format("{0}{1}: {2}Message: {3}{4}StackTrace: {5}.",
                Environment.NewLine, exceptionMessage, Environment.NewLine, ex.Message, Environment.NewLine, ex.StackTrace);

            if (ex.InnerException != null)
            {
                mesgAndStackTrace = string.Format("{0}{1}{2}",
                    mesgAndStackTrace, Environment.NewLine, SerializeException(ex.InnerException, "Inner Exception"));
            }

            return mesgAndStackTrace + Environment.NewLine;
        }
    }
}