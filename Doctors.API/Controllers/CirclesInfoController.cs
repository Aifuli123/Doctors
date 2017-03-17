using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Doctors.API.Controllers.BaseContolles;
using Doctors.IServices;
using Doctors.Model.BaseResult;

namespace Doctors.API.Controllers
{
    public class CirclesInfoController : BaseApiController
    {
        ICirclesInfoService circlesInforService;
        public  CirclesInfoController (ICirclesInfoService circles)
        {
            circlesInforService = circles;
        }
        // GET: DoctorInfor


        //http://localhost:41877/api/CirclesInfo/GetCirclesInfofor?pageIndex=1&&pageSize=2&&city=西安&&dep=内科
        [HttpGet]
        public IHttpActionResult GetCirclesInfofor(int pageIndex,int pageSize,string city,string dep)
        {
            var item = circlesInforService.GetCirclesInfo(pageIndex, pageSize, city, dep);
            SimpleResult result = new SimpleResult();
            result.Resource = item;
            return Json(result);
        }

    }
}