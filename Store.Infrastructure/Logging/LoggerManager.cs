﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;

namespace Store.Infrastructure.Logging
{
    public static class LoggerManager
    {
        public static ILogger GetLogger(Type type)
        {
            return new Logger(type);
        }
    }
}
