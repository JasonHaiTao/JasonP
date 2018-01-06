using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebSystem.Mobel.ViewModesl
{
    //订单类
    public class OrderModel
    {
        public int Id { get; set; }//编号
        public string Odr_Code { get; set; }//订单号
        public string  Are_Name { get; set; }//国家
        public string  Odr_Status { get; set; }//支付状态
        public DateTime? Odr_Sdt { get; set; }//起始时间
        public DateTime? Odr_Edt { get; set; }//中止日期
        public int Odd_Days { get; set; }//天数
        public decimal? Odr_Amount { get; set; }//总价

        //地址信息
        public string  Ads_Name{ get; set; }//收件姓名
        public int Ads_Tel { get; set; }//联系电话
        public string Ads_CardNo { get; set; }//收件人证件号码
        public string  Ads_Sex { get; set; }//收件人性别
        public string Ads_Address { get; set; }//收件人地址

        //保险信息
        public string Bxu_Name { get; set; }//被保人姓名
        public int Bxu_Cardno { get; set; }//被保人证件号码
        public string Bxu_Tel { get; set; }//被保人电话
        public string Buo_BxdNo { get; set; }//被保人保单号码

        //下单人信息
        public string Use_Name { get; set; }//下单人姓名

    }
}
