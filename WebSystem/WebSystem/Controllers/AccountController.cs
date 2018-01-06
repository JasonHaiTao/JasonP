using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Travel.Tools;
using WebSystem.Mobel;
using WebSystem.Mobel.ViewModesl;

namespace WebSystem.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        travelEntities context = new travelEntities();
        
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel,string autoLoign,string retureUrl)
        {
            if (ModelState.IsValid)
            {
                //var user = context.Admins.SingleOrDefault(m => m.Adn_Pwd.Equals(loginModel.Adn_Pwd)); Travel.Tools.Md5.MD5(pwd).ToLower();
                var pwd = Md5.MD5(loginModel.Adn_Pwd).ToLower();
                var user = this.CachedUsrItems.SingleOrDefault(u => u.Adn_LoginName.Equals(loginModel.Adn_Id));

                //创建票证
                if (user!=null && user.Adn_Pwd == pwd)
                {
                    FormsAuthentication.SetAuthCookie(user.Adn_Id.ToString(), autoLoign == null ? false : true);
                    //保持用户状态
                    Session["CurrentUser"] = user;
                    if (string.IsNullOrEmpty(retureUrl))
                    {
                        //重定向到首页
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        //重定向到returnUrl
                        return Redirect(Server.UrlDecode(retureUrl));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码不正确！");
                    return View();
                }
                 
            }
            else
            {
                ModelState.AddModelError("", "用户名或密码不正确！");
                return View();
            }
            
        }
        const string CACHEDUSERS = "MyOffice_RegisterUsers";

        IList<Admin> CachedUsrItems
        {
            get
            {
                IList<Admin> items = HttpContext.Cache[CACHEDUSERS] as IList<Admin>;
                if (items == null)
                {
                    using (context)
                    {
                        items = context.Admins.ToList();
                    }
                }
                HttpContext.Cache[CACHEDUSERS] = items;
                return items;
            }
            set
            {
                HttpContext.Cache[CACHEDUSERS] = value;
            }
        }

        //注销用户
        public ActionResult logOut()
        {
            //删除票证
            FormsAuthentication.SignOut();
            Session["CurrentUser"] = null;
            //返回登录页面
            return RedirectToAction("Login", "Account");
        }
   
        public ActionResult Header()
        {
            Admin admin = Session["CurrentUser"] as Admin;
            if (admin==null)
            {
                return View();
            }
            return PartialView(admin);
        }
        
        protected override void Dispose(bool disposing)
        {
            this.context.Dispose();
            base.Dispose(disposing);
        }
    }
}
