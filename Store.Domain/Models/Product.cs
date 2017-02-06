using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Models
{
    public class Product : TEntity
    {
        public Product()
        {
            FeatureId = (int) EFeature.Product;
        }

        public override int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        public float Price { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Тип")]
        public int Type { get; set; }
    }
}
