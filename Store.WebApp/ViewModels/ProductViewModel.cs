using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Domain.Contracts;
using Store.Domain.Models;
using Store.Domain.Specifications.Attachment;

namespace Store.ViewModels
{
    public class ProductViewModel
    {
        private readonly IAttachmentService _attachmentService;

        public ProductViewModel(Product product, IAttachmentService attachmentService)
        {
            Data = product;
            _attachmentService = attachmentService;
        }

        public Product Data { get;}

        private List<Attachment> _attachments;

        public List<Attachment> Attachments
        {
            get
            {
                GetAttachmentByEntityAndFeatureIdSpecification spec =
                    new GetAttachmentByEntityAndFeatureIdSpecification(Data.Id, Data.FeatureId);

                _attachments = _attachments ?? _attachmentService.GetBySpecification(spec);

                return _attachments;
            }
        }
    }
}