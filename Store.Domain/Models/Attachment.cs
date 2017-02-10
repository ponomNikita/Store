using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Enums;

namespace Store.Domain.Models
{
    public class Attachment : TEntity
    {
        public Attachment()
        {
            FeatureId = (int) EFeature.Attachment;
        }

        public override int Id { get; set; }

        public int Type { get; set; }

        public string RelativePath { get; set; }

        public string FileName { get; set; }

        public int entityId { get; set; }

        public int featureId { get; set; }
    }
}
