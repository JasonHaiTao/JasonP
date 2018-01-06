using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSystem.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ProductList()
        {
            return PartialView();
        }

        public ActionResult ProductDetail()
        {
            return PartialView();
        }

        public ActionResult RecycleBin()
        {
            return PartialView();
        }

       
    }
}
