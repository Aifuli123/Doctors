using Doctors.IServices;
using Doctors.Model.BaseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Doctors.API.Controllers
{
    public class DoctorInforController : ApiController
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
        public IHttpActionResult Test()
        {
            var item = doctorInforService.GetDoctorInfor("1");
            SimpleResult result = new SimpleResult();
            result.Resource = item;
            return Json(result);
        }
    }
}