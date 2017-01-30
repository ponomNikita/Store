using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Enums;

namespace Store.Domain.Models
{
    public class Product : TEntity
    {
        public Product()
        {
            FeatureId = (int) EFeature.Product;
        }

        public override int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }
    }
}
