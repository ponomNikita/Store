using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Contracts;
using Store.Infrastructure.Logging;
using Store.ViewModels;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductService _service;
        private readonly IAttachmentService _attachmentService;

        public ProductsController(IProductService service, IAttachmentService attachmentService)
        {
            _logger = LoggerManager.GetLogger(GetType());
            _service = service;
            _attachmentService = attachmentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _logger.Info("Index()");
            return View();
        }

        [HttpGet]
        public JsonResult GetContent()
        {
            _logger.Info("GetContent()");
            var items = _service.GetAll();

            List<ProductViewModel> products = new List<ProductViewModel>();

            items.ForEach(product =>
            {
                products.Add(new ProductViewModel(product, _attachmentService));
            });

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Content()
        {
            _logger.Info("Content()");
            return PartialView();
        }

        [HttpGet]
        public ActionResult Details()
        {
            _logger.Info("Details()");
            return PartialView();
        }

        [HttpGet]
        public ActionResult CartList()
        {
            _logger.Info("CartList()");

            return PartialView();
        }

    }
}