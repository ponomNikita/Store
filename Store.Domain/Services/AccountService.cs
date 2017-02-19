using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;
using Store.Domain.Models;

namespace Store.Domain.Services
{
    public class AccountService : BaseEntityService<User>, IAccountService
    {
        public AccountService(IRepository<User> repository, ILogger logger) : base(repository, logger)
        {
        }
    }
}
