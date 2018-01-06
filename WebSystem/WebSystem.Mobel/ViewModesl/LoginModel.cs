using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebSystem.Mobel.ViewModesl
{
    public class LoginModel
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage = "{0}不得为空")]
        //[RegularExpression(@"^\w+$", ErrorMessage = "请输入正确的{0}")]
        public string Adn_Id { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage="{0}不能为空！")]
        public string Adn_Pwd { get; set; }
    }
}
