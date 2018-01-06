using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using WebSystem.Mobel;
using WebSystem.Mobel.ViewModesl;

namespace WebSystem.Dal
{
    public class OrderService
    {
        travelEntities context = new travelEntities();

        //查询详细信息
        public List<OrderModel> OrderDetail()
        {
            
            var or = (from l in context.OrderDetails
                     join d in context.Orders on l.Odd_Odr_Id equals d.Odr_Id
                     join ar in context.Areas on l.Odd_Ara_Id equals ar.Ara_Id
                     join p in context.Products on l.Odd_Prd_Id equals p.Prd_Id
                     join u in context.Users on d.Odr_Use_Id equals u.Use_Id
                     //join b in context.BxUsers on d.Odr_BxuIds equals b.Bxu_Id
                     orderby l.Odd_CreateDt descending
                     select new OrderModel
                     {

                         Odr_Code = d.Odr_Code,
                         Are_Name = ar.Ara_Name,
                         Use_Name = u.Use_Name,
                         Odr_Status = d.Odr_Status,
                         Odr_Sdt = d.Odr_Sdt,
                         Odr_Amount = d.Odr_Amount

                     }).ToList();
            return or;

        }


        //index为当前浏览的页码
        public List<OrderModel> Orderlist(int Index,out int overIndex)
        {
            
            using (travelEntities context =new travelEntities())
            {
                List<OrderModel> orlist = new List<OrderModel>();

                var or = (from l in context.OrderDetails
                          join d in context.Orders on l.Odd_Odr_Id equals d.Odr_Id
                          join ar in context.Areas on l.Odd_Ara_Id equals ar.Ara_Id
                          join p in context.Products on l.Odd_Prd_Id equals p.Prd_Id
                          join u in context.Users on d.Odr_Use_Id equals u.Use_Id
                          orderby l.Odd_CreateDt descending
                          select new OrderModel
                          {
                              Odr_Code = d.Odr_Code,
                              Are_Name = ar.Ara_Name,
                              Use_Name = u.Use_Name,
                              Odr_Status = d.Odr_Status,
                              Odr_Sdt = d.Odr_Sdt,
                              Odr_Amount = d.Odr_Amount

                          });
                

                //select new { d.Odr_Code, ar.Ara_Name, u.Use_Name, d.Odr_Status, d.Odr_Sdt, d.Odr_Amount });
                //if (or!=null)
                //{
                //    foreach (var item in or)
                //    {
                //        OrderModel ol = new OrderModel();
                //        ol.Odr_Code = item.Odr_Code;
                //        ol.Are_Name = item.Ara_Name;
                //        ol.Use_Name = item.Use_Name;
                //        ol.Odr_Status = item.Odr_Status;
                //        ol.Odr_Sdt = item.Odr_Sdt;
                //        ol.Odr_Amount = item.Odr_Amount.ToString();
                //        orlist.Add(ol);
                //    }


                //}
                overIndex = (int)Math.Ceiling(or.Count() / 100.00);
                //double count = or.Count() / 100;
                //overIndex = Convert.ToInt32(Math.Truncate(count));
                return or.Skip((Index-1)*100).Take(100).ToList();
            }
            
        }
    }
}
