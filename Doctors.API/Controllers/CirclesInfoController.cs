using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation.Providers;
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
        

        /// <summary>
        /// 获取圈子信息
        /// </summary>
        /// <param name="pageIndex">起始页</param>
        /// <param name="pageSize">每页页数</param>
        /// <param name="city">城市</param>
        /// <param name="dep">科室</param>
        /// <returns></returns>
        //http://localhost:41877/api/CirclesInfo/GetCirclesInfofor?pageIndex=1&&pageSize=2&&city=西安&&dep=内科
        [HttpGet]
        public IHttpActionResult GetCirclesInfofor(int pageIndex,int pageSize,string city,string dep)
        {
            var item = circlesInforService.GetCirclesInfo(pageIndex, pageSize, city, dep);
            SimpleResult result = new SimpleResult();
            result.Resource = item;
            return Json(result);
        }

        /// <summary>
        /// 获取指定圈子的动态
        /// </summary>
        /// <param name="pageIndex">起始页</param>
        /// <param name="pageSize">每页页数</param>
        /// <param name="city">城市</param>
        /// <param name="dep">科室</param>
        /// <returns></returns>
        //http://localhost:41877/api/CirclesInfo/GetCommentsInfo?CircleId=bf0355af-83b4-4e8c-a019-64ef39da7f66
        [HttpGet]
        public IHttpActionResult GetCommentsInfo( string CircleId)
        {
            var item = circlesInforService.GetCommentsInfo(CircleId);
            
            SimpleResult result = new SimpleResult();
            result.Resource = item;
            return Json(result);
        }

    }
}