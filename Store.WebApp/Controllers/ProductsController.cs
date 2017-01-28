using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Infrastructure.Logging;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger _logger;

        public ProductsController()
        {
            _logger = LoggerManager.GetLogger(GetType());
        }

        // GET: Products
        public ActionResult Index()
        {
            _logger.Info("Index()");
            return View();
        }

    }
}