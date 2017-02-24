
using System;
using System.Linq.Expressions;
using Store.Domain.Contracts;
using Store.Domain.Models;

namespace Store.Domain.Specifications
{
    public class GetUserByEmailAndPasswordSpecification : ISpecification<User>
    {
        private string _email;
        private string _password;

        public GetUserByEmailAndPasswordSpecification(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public Expression<Func<User, bool>> IsSatisfiedBy
        {
            get
            {
                return u => u.Email.ToUpper().Equals(_email.ToUpper())
                            && u.Password.Equals(_password);
            }
        }
    }
}
