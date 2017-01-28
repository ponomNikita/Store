using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Contracts;
using Store.Infrastructure.Logging;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _logger = LoggerManager.GetLogger(GetType());
            _service = service;
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
            var products = _service.GetAll();
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

    }
}