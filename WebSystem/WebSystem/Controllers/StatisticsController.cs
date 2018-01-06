using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSystem.Controllers
{
    public class StatisticsController : Controller
    {
        //
        // GET: /Statistics/
        
        public ActionResult Index()
        {
            return View();
        }
        //流量统计
        public ActionResult DischargeStatistic()
        {
            return PartialView();
        }

        //销售额统计
        public ActionResult SalesVolume()
        {
            return PartialView();
        }

    }
}
