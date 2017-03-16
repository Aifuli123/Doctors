using Doctors.Common;
using Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;

namespace Doctors.API.Filters
{
    public class AuthorizeFilter: AuthorizeAttribute, IOrderFilter
    {
        public int Order { get { return 1; } }

        //重写基类的验证方式，加入我们自定义的Ticket验证
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //url获取token
            var content = actionContext.Request.Properties["MS_HttpContext"] as HttpContextBase;
            var token = content.Request.QueryString["Token"];
            if (!string.IsNullOrEmpty(token))
            {
                //读取请求上下文中的Controller,Action,Id
                var routes = new RouteCollection();
                RouteConfig.RegisterRoutes(routes);
                RouteData routeData = routes.GetRouteData(content);
                //取出区域的控制器Action,id
                string controller = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string action = actionContext.ActionDescriptor.ActionName;
                //URL路径
                string filePath = HttpContext.Current.Request.FilePath;
                string accountID = "";
                if (LoginUserManage.ValidateTicket(token)/* && ValiddatePermission(token, controller, action, filePath)*/)
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

       


        //public bool ValiddatePermission(string token, string controller, string action, string filePath)
        //{
        //    bool bResult = false;

        //    List<permModel> perm = null;

        //    perm = (List<permModel>)HttpContext.Current.Session[filePath];
        //    if (perm == null)
        //    {
        //        SysUserBLL userBLL = new SysUserBLL()
        //        {
        //            m_Rep = new SysUserRepository(new DBContainer()),
        //            sysRightRep = new SysRightRepository(new DBContainer())
        //        };
        //        {
        //            var userName = LoginUserManage.DecryptToken(token.Trim());
        //            perm = userBLL.GetPermission(userName, controller);//获取当前用户的权限列表
        //            HttpContext.Current.Session[filePath] = perm;//获取的劝降放入会话由Controller调用
        //        }
        //        //查询当前Action 是否有操作权限，大于0表示有，否则没有
        //        int count = perm.Where(a => a.KeyCode.ToLower() == action.ToLower()).Count();
        //        if (count > 0)
        //        {
        //            bResult = true;
        //        }
        //        else
        //        {
        //            bResult = false;
        //            LoginUserManage.RedirectUrl();
        //        }
        //    }
        //    return bResult;
        //}


    }

    public static class LoginUserManage
    {
        //校验用户名密码（对Session匹配，或数据库数据匹配）
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptToken"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public static  bool ValidateTicket(string encryptToken)
        {
            ////解密Ticket
            //var strTicket = FormsAuthentication.Decrypt(encryptToken).UserData;

            ////从Ticket里面获取用户名和密码
            //var index = strTicket.IndexOf("&");
            //string userName = strTicket.Substring(0, index);
            //string password = strTicket.Substring(index + 1);
            var token= CacheMgr.Get<DoctorInfor>(encryptToken);
            if (token != null)
            {
                return true;
            }

            #region 只使用于网站身份验证
            //取得session，不通过说明用户退出，或者session已经过期
            //var token = HttpContext.Current.Session[userName];
            //accountID = "";
            //if (token == null)
            //{
            //    return false;
            //} 
            #endregion
            //对比session中的令牌
           

            return false;

        }
    }

}