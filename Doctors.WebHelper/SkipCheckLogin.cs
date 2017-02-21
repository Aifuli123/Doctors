using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WebHelper
{
    /// <summary>
    /// 自定义特性标签，将来类和方法如果有贴的话，则跳过登录验证代码逻辑
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class SkipCheckLoginAttribute : Attribute
    {

    }
}
