using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models
{
    public class TEntity
    {
        [Key]
        public virtual int Id { get; set; }

        [NotMapped]
        public int FeatureId { get; set; }
    }
}
