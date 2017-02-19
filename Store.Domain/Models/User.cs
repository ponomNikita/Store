using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Enums;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

    }
}
