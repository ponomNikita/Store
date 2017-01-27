using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Enums;

namespace Store.Domain.Models
{
    public partial class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }
    }

    public partial class Product
    {
        public EProductType ProductType
        {
            get { return (EProductType)Type; }
            set { Type = (int) value; }
        }
    }
}
