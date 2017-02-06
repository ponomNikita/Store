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

        private List<AttachmentViewModel> _attachmentViewModels;

        public List<AttachmentViewModel> Attachments
        {
            get
            {
                GetAttachmentByEntityAndFeatureIdSpecification spec =
                    new GetAttachmentByEntityAndFeatureIdSpecification(Data.Id, Data.FeatureId);

                if (_attachmentViewModels != null)
                {
                    return _attachmentViewModels;
                }
                var attachments = _attachmentService.GetBySpecification(spec);

                _attachmentViewModels = new List<AttachmentViewModel>();

                attachments.ForEach(attachment =>
                {
                    _attachmentViewModels.Add(new AttachmentViewModel(attachment));
                });

                return _attachmentViewModels;
            }
        }
    }
}