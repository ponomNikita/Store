using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Logging
{
    public interface ILogger
    {
        void Info(string log);

        void Error(string log);

        void Debug(string log);
    }
}
