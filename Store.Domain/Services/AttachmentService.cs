using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;
using Store.Domain.Models;

namespace Store.Domain.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IRepository<Attachment> _attachmentRepository;

        public AttachmentService(IRepository<Attachment> attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public List<Attachment> GetBySpecification(ISpecification<Attachment> specification)
        {
            return _attachmentRepository.GetBySpecification(specification).ToList();
        }
    }
}
