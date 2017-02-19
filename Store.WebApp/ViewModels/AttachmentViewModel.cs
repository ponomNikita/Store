using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Domain.Contracts;
using Store.Domain.Models;
using Store.Infrastructure.Logging;

namespace Store.ViewModels
{
    public class AttachmentViewModel
    {
        private readonly ILogger _logger = LoggerManager.GetLogger(typeof(AttachmentViewModel));

        public AttachmentViewModel(Attachment attachment)
        {
            Type = attachment.Type;
            Path = GetFullPath(attachment);
        }

        public int Type { get; set; }
        public string Path { get; set; }

        private string GetFullPath(Attachment attachment)
        {
            string soragePath = String.Empty;
            try
            {
                soragePath = System.Configuration.ConfigurationManager.AppSettings["StoragePath"];
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
            }

             
            string path = $"{soragePath}{attachment.RelativePath}{attachment.FileName}";

            return path;
        }
    }
}