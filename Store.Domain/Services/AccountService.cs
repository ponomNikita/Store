using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Store.Domain.Contracts;
using Store.Domain.Models;
using Store.Domain.Specifications;

namespace Store.Domain.Services
{
    public class AccountService : BaseEntityService<User>, IAccountService
    {
        public AccountService(IRepository<User> repository, ILogger logger) : base(repository, logger)
        {
        }

        public User Login(string login, string password)
        {
            string hashPassword = GetHashString(password);

            _logger.InfoFormat("password after hash function {0}", hashPassword);

            GetUserByEmailAndPasswordSpecification specification = 
                new GetUserByEmailAndPasswordSpecification(login, hashPassword);

            var currentUser = _repository.GetBySpecification(specification).FirstOrDefault();

            if (currentUser != null)
            {
                _logger.InfoFormat("Setting up cookies");
                FormsAuthentication.SetAuthCookie(currentUser.Email, true);
            }

            return currentUser;
        }

        /// <summary>
        /// Md5 шифрование строки 
        /// </summary>
        private static string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

    }
}
