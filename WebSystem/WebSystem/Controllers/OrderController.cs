using System.Collections.Generic;
using System.Web.Mvc;
using WebSystem.Bll;
using WebSystem.Mobel;
using WebSystem.Mobel.ViewModesl;

namespace WebSystem.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        travelEntities context = new travelEntities();
        OrderManager or = new OrderManager();
        
        public ActionResult Index()
        {
            return PartialView();
        }

        #region 订单管理
        /// <summary>
        /// 订单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderList(int Index)
        {
            int OverIndex=0;
            ViewBag.Index = Index;           
            var model = or.OrderLiset(Index,out OverIndex);
            ViewBag.OverIndex = OverIndex;

            int i = 1;
            foreach(var item in model)
            {
                item.Id = i++;
            }
            return PartialView(model);
        }



        /// <summary>
        /// 订单详情
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderDetail(string id)
        {
            if (id != null)
            {
                List<OrderModel> ordetail = or.OrderDetail();

                var ord = ordetail.Find(m => m.Odr_Code.Equals(id));

                return PartialView(ord);
            }
            return PartialView();
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteOrder()
        {

            return PartialView();
        }


        
        #endregion


    }
}
