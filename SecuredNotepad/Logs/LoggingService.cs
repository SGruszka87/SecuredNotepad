using NLog;
using SecuredNotepad.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuredNotepad.Logs
{
    internal class LoggingService : ILoggingService
    {

        public LoggingService()
        {
            InitLogFactory();
            InitLogger();
        }


        private LogFactory _logFactory;
        private LogFactory InitLogFactory()
        {
            if (_logFactory == null)
            {
                var config = new NLog.Config.LoggingConfiguration();


                string filename = Settings.LogFileName;

                string folder = Settings.LogOnDevicePath;
                string filepath = folder + "/" + filename;
                var logFile = new NLog.Targets.FileTarget("logFile") { FileName = filepath };


                config.AddRule(LogLevel.Trace, LogLevel.Fatal, logFile);

                NLog.LogManager.Configuration = config;

                var logger = NLog.LogManager.GetCurrentClassLogger();

                logger.Info("Logger created");
            }
            return _logFactory;
        }

        private ILogger _logger;
        private ILogger InitLogger()
        {
            if (_logger == null)
            {
                _logger = NLog.LogManager.GetCurrentClassLogger();
            }
            return _logger;
        }


        private void Log(AppEventCode code, LogLevel _logLevel, string message)
        {
            string msg = String.Format(message, code);
            _logger.Log(_logLevel, msg);
        }
        private void Log(AppEventCode code, LogLevel _logLevel, string message, Exception exception)
        {
            string msg = String.Format(message, code);
            _logger.Log(_logLevel, msg, exception);
        }

        private void Log(AppEventCode code, LogLevel _logLevel, string message, params object[] args)
        {
            string msg = String.Format(message, code);
            _logger.Log(_logLevel, msg, args);
        }

        //private void Log(AppEventCode code, LogLevel _logLevel, string format, params object[] args)
        //{
        //    string msg = String.Format(format, code);
        //    _logger.Log(_logLevel, msg, args);
        //}
        private void Log(AppEventCode code, LogLevel _logLevel, string format, Exception exception, params object[] args)
        {
            string msg = String.Format(format, code);
            _logger.Log(_logLevel, msg, exception, args);
        }

        #region Error
        public void Error(AppEventCode code, string message) => Log(code, LogLevel.Error, message);
        public void Error(AppEventCode code, Exception e, string message) => Log(code, LogLevel.Error, message, e);
        public void Error(AppEventCode code, string format, params object[] args) => Log(code, LogLevel.Error, format, args);
        public void Error(AppEventCode code, Exception e, string format, params object[] args) => Log(code, LogLevel.Error, format, e, args);
        #endregion

        #region Fatal
        public void Fatal(AppEventCode code, string message) => Log(code, LogLevel.Fatal, message);
        public void Fatal(AppEventCode code, Exception e, string message) => Log(code, LogLevel.Fatal, message, e);
        public void Fatal(AppEventCode code, string format, params object[] args) => Log(code, LogLevel.Fatal, format, args);
        public void Fatal(AppEventCode code, Exception e, string format, params object[] args) => Log(code, LogLevel.Fatal, format, e, args);
        #endregion

        #region Debug
        public void Debug(AppEventCode code, string message) => Log(code, LogLevel.Debug, message);
        public void Debug(AppEventCode code, string format, params object[] args) => Log(code, LogLevel.Debug, format, args);
        #endregion

        #region Info
        public void Info(AppEventCode code, string message) => Log(code, LogLevel.Info, message);
        public void Info(AppEventCode code, string message, params object[] args) => Log(code, LogLevel.Info, message, args);
        #endregion

        #region Trace
        public void Trace(AppEventCode code, string message) => Log(code, LogLevel.Trace, message);
        public void Trace(AppEventCode code, string format, params object[] args) => Log(code, LogLevel.Trace, format, args);
        #endregion

        #region Warn
        public void Warn(AppEventCode code, string message) => Log(code, LogLevel.Warn, message);
        public void Warn(AppEventCode code, string format, params object[] args) => Log(code, LogLevel.Warn, format, args);
        #endregion


    }

}
