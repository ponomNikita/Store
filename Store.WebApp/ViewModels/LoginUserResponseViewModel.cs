using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Domain.Models;
using Store.Enums;

namespace Store.ViewModels
{
    public class LoginUserResponseViewModel
    {
        public LoginUserResponseViewModel(User user)
        {
            if (user == null)
            {
                Status = EResponseStatus.Erorr;
            }
            else
            {
                Status = EResponseStatus.Success;
                UserName = user.Email;
            }
        }

        public EResponseStatus Status { get; set; }

        public string UserName { get; set; }
    }
}