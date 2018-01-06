using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSystem.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }

        public ActionResult MemberList()
        {
            return PartialView();
        }
        
        public ActionResult MemberDetail()
        {
            return PartialView();
        }

        public ActionResult MemRank()
        {
            return PartialView();
        }

        public ActionResult AbjustFunding()
        {
            return PartialView();
        }

    }
}
