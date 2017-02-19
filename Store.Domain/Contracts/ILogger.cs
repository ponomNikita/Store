namespace Store.Domain.Contracts
{
    public interface ILogger
    {
        void Info(string log);

        void Error(string log);

        void Debug(string log);

        void InfoFormat(string log, params object[] args);

        void DebugFormat(string log, params object[] args);

        void ErrorFormat(string log, params object[] args);
    }
}