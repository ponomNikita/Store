using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Store.Infrastructure.Logging
{
    class Logger : ILogger
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
    }
}
