using Dapper;
using Doctors.Model;
using Doctors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doctors.Services;
using Doctors.IServices;

namespace Doctors.Controllers
{
    public class HomeController : Controller
    {
        ISysUserInfo sysUserInfo;
        public HomeController(ISysUserInfo user)
        {
            sysUserInfo = user;
        }
        public ActionResult Index()
        {


            sysUserInfo.LogIn("2","2");


            return View();
        }
    }
}
 