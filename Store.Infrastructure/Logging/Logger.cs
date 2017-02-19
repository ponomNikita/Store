using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Store.Domain.Contracts;

namespace Store.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        private static ILog _logger;

        public Logger(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }
        public void Info(string log)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Info(log);
            }
        }

        public void Error(string log)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(log);
            }
        }

        public void Debug(string log)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(log);
            }
        }

        public void InfoFormat(string log, params object[] args)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.InfoFormat(log, args);
            }
        }

        public void DebugFormat(string log, params object[] args)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.DebugFormat(log, args);
            }
        }

        public void ErrorFormat(string log, params object[] args)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.ErrorFormat(log, args);
            }
        }
    }
}
