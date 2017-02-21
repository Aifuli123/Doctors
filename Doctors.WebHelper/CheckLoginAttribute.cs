using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using CRM.WebHelper;
using System.Web;
using Doctors.Common;
using System.ComponentModel;

namespace Doctors.WebHelper
{

    /// <summary>
    /// 自定义的统一登录验证过滤器
    /// </summary>
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 负责验证Session[Keys.Uinfo]是否为null，如果为null则直接跳转到登录页面
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //0.0 判断控制器类或者action是否有贴SkipCheckLogin标签，如果有贴则阻断下面代码的运行
            if (filterContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<SkipCheckLoginAttribute>().Count==1)
            {
                return;
            }

            if (filterContext.ActionDescriptor.GetCustomAttributes<SkipCheckLoginAttribute>().Count==1)
            {
                return;
            }

            //1.0 判断session如果为空则跳转
            if (HttpContext.Current.Session[Keys.Uinfo] == null)
            {
                //1.0 第一种提醒方式，体验不好，因为会导致页面泛白
                //filterContext.HttpContext.Response.Write("<script>alert('您未登录');window.location='/admin/login/login'</script>");

                //2.0 判断如果cookie中的数据不为空，则应该取出其中的用户主键去sysuserinfo表中再次获取实体
                //存入session
                if (HttpContext.Current.Request.Cookies[Keys.IsRemember] != null)
                {
                    //2.0.1 获取用户主键
                    string userid = HttpContext.Current.Request.Cookies[Keys.IsRemember].Value;

                    //2.0.2 根据userid去访问sysuserinfo获取数据实体
                    //2.0.2.1 从全局缓存中获取autofac的容器对象
                    IContainer autofac = CacheMgr.GetData<IContainer>(Keys.autofaccontainer);
                    //2.0.2.2 从autofac容器中获取IsysUserInfoServices的实现类的对象实例
                    IsysUserInfoServices userSer = autofac.Resolve<IsysUserInfoServices>();

                    int uid = int.Parse(userid);

                    var userinfo = userSer.QueryWhere(c => c.uID == uid).FirstOrDefault();

                    //3.0 判断userinfo是否为null
                    if (userinfo == null)
                    {
                        ToLogin(filterContext);
                    }
                    else
                    {
                        //4.0 将userinfo实体对象存入session
                        filterContext.HttpContext.Session[Keys.Uinfo] = userinfo;
                    }
                }
                else
                {
                    //统一跳转
                    ToLogin(filterContext);
                }
            }
        }

        private void ToLogin(ActionExecutingContext filterContext)
        {
            //2.0 直接使用一个未登录的视图替换当前的结果
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Areas/admin/Views/Shared/nologin.cshtml"
            };
        }
    }
}
