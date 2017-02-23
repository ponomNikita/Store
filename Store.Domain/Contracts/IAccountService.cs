using Store.Domain.Models;

namespace Store.Domain.Contracts
{
    public interface IAccountService : IService<User>
    {
        User Login(string login, string password);
    }
}