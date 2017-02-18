﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Enums;

namespace Store.Domain.Models
{
    public class User : TEntity
    {
        public User()
        {
            FeatureId = (int)EFeature.User;
        }

        public override int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

    }
}
