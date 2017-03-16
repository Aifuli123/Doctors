using Doctors.API.Controllers.BaseContolles;
using Doctors.Common;
using Doctors.IServices;
using Doctors.Model;
using Doctors.Model.BaseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Doctors.API.Controllers
{
    public class DoctorInforController : BaseApiController
    {
        IDoctorInforService doctorInforService;
        public DoctorInforController(IDoctorInforService doctors)
        {
            doctorInforService = doctors;
        }
        // GET: DoctorInfor


        //http://localhost:41877/api/DoctorInfor/GetDoctorInfor?id=1
        [HttpGet]
        public IHttpActionResult GetDoctorInfor(string id)
        {
            var item = doctorInforService.GetDoctorInfor(id);
            SimpleResult result = new SimpleResult();
            result.Resource = item;
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Test(string Token)
        {
           
            var c = Token;
           var d = CacheMgr.GetData<DoctorInfor>(c);
            var item = doctorInforService.GetDoctorInfor("1");
            SimpleResult result = new SimpleResult();
            result.Resource = item;
            return Json(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult LogIn(string userName,string password,int type)
        {
            var c = HttpContext.Current.Items["accountID"] as string;
            SimpleResult result = new SimpleResult();
            var item = doctorInforService.GetDoctorInfor(userName,password,type);
            if (userName != "123" && password != "123")
            {
                result.Status = Result.FAILURE;
                result.Msg = "用户名或密码错误";
                return Json(result);
            }
            FormsAuthenticationTicket token = new FormsAuthenticationTicket(0, userName, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", item.accountID, password),
                            FormsAuthentication.FormsCookiePath);
            //返回登录结果、用户信息、用户验证票据信息
            var Token = FormsAuthentication.Encrypt(token);
            //将身份信息保存在session中，验证当前请求是否是有效请求
           
            CacheMgr.Insert(Token, item, CacheType.Token);
            result.Resource = Token;



            return Json(result);

        }
    }
}