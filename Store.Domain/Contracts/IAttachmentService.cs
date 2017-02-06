using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Domain.Contracts
{
    public interface IAttachmentService
    {
        List<Attachment> GetBySpecification(ISpecification<Attachment> specification);
    }
}
