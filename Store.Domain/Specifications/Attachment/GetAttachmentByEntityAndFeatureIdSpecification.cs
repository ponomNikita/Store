using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;
using Store.Domain.Models;

namespace Store.Domain.Specifications
{
    public class GetAttachmentByEntityAndFeatureIdSpecification : ISpecification<Models.Attachment>
    {
        private readonly int _entityId;
        private readonly int _featureId;

        public GetAttachmentByEntityAndFeatureIdSpecification(int entityId, int featureId)
        {
            _entityId = entityId;
            _featureId = featureId;
        }

        public Expression<Func<Models.Attachment, bool>> IsSatisfiedBy
        {
            get { return x => x.entityId == _entityId && x.featureId == _featureId; } 
        }
    }
}
