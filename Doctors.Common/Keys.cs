using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Common
{
    public class Keys
    {
        //验证码的session键
        public const string Vcode = "crmvcode";
        //当前登录成功以后的用户实体的session键
        public const string Uinfo = "crmuinfo";

        //用于记住用户的主键的cookie 键
        public const string IsRemember = "crmIsRemember";

        //用于存放autofac容器的缓存key
        public const string autofaccontainer = "crmautofaccontainer";
    }
}
