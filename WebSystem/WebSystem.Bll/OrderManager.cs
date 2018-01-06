using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSystem.Dal;
using WebSystem.Mobel;
using WebSystem.Mobel.ViewModesl;

namespace WebSystem.Bll
{
    public class OrderManager
    {
        OrderService or = new OrderService();
        public List<OrderModel> OrderDetail()
        {
            return or.OrderDetail();
        }



        public List<OrderModel> OrderLiset(int Index,out int OverIndex)
        {
            
            return or.Orderlist(Index, out OverIndex);
        }


        
    }
}
